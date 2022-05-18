using PE22A_JAMZ.src.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace PE22A_JAMZ.src.TabRenderer
{

    //  +----------------------------------------+
    //  | Diálogo de Redimensionador de imagenes |    
    //  |         JAMZ DATE: 17/05/2022          |
    //  +----------------------------------------+
    public partial class ResizeImage : Form
    {

        #region CLASS CONSTRUCTOR

        //  +----------------------------------------+
        //  |         Constructor de la clase        |
        //  +----------------------------------------+
        public ResizeImage()
        {
            InitializeComponent();

            BtnSaveImages.ForeColor = Color.White;

        }

        #endregion

        #region GLOBAL VARAIABLES
        
        bool IsAspectRatioEnabled; // Saber si se habilitó la opcion de utilizar
                                   // relación de aspecto
        
        private int ImageWidth;    // Ancho que tendra(n) la(s) nueva(s) imagen(es)
        private int ImageHeight;   // Alto que tendra(n) la(s) nueva(s) imagen(es)
        private int QuantityOfImages; // Cantidad de imagenes seleccionadas
        
        private string[] FileNames;  // Ruta de cada imagen seleccionada
        private string[] ImageToolTip; // Tooltip para cada imagen seleccionada
        private string FileFormat; // El nuevo formato de imagen
       
        private FileInfo[] FilesInfo; // Contiene información de la(s) imagen(es) seleccionada(s)
        private ToolTip ImgToolTip; // Permite asignar un ToolTip al (los) picture box creado(s)
        private long ImagesLength; // El tamaño total en bytes de la(s) imagen(es)

        private OpenFileDialog OpenDialog; // Popup gráfico para seleccionar las imagenes a redimensionar
        private SaveFileDialog SaveDialog; // Popup gráfico para seleccionar la ruta y nombre de las imgenes redimensionadas
        private DialogResult Result; // El resultado de utilizar cualquiera de los 2 popups de arriba ^

        // Guardo la relaccion de aspecto en dos variables debido a que para calcular 
        // la relacion de aspecto ocupo dividir, y en base a estos calcular el tamaño nuevo
        private double[] AspectRatioX = new double[]
        {
            16f, 
            4f,
            1f
        };

        private double[] AspectRatioY = new double[]
        {
            9f,
            3f,
            1f
        };

        #endregion

        #region IMAGE RESIZER

        //  +---------------------------------------------------------------------------------+
        //  | Abre un diálogo que nos permite escoger entre dos formatos (png, jpg), para pos |
        //  | -teriormente mostrarle al usuario cuántas eligio, y una previsualización.       |
        //  +---------------------------------------------------------------------------------+
        private async Task SelectImages()
        {
            OpenDialog = new OpenFileDialog();

            OpenDialog.InitialDirectory = @"C:\"; // Asigna un directorio inicial
            
            // Titulo en el popup 
            OpenDialog.Title = "Escoge imagen(es) a redimensionar";
            
            // Filto, en este caso que tipo de formatos puede ver
            OpenDialog.Filter = "JPG Image(.jpg)|*.jpg|PNG Image(.png)|*.png";
            
            // Recuerda el ultimo directorio en el que se abrio
            OpenDialog.RestoreDirectory = true;

            // Habilita la capacidad de seleccionar varias imagenes a la vez
            OpenDialog.Multiselect = true;

            // Abre el diálogo
            Result = OpenDialog.ShowDialog();

            // Valida el diálogo
            if (Result == DialogResult.Cancel ||
                Result == DialogResult.None ||
                Result == DialogResult.No ||
                Result == DialogResult.Abort)
            {
                return;
            }

            // Se seleccionaron una o mas de una imagen
            if (Result == DialogResult.OK) 
            {

                QuantityOfImages = OpenDialog.FileNames.Length; // Se obtiene cuantas fueron

                // Se inicializan en base a las imagenes seleccionadas
                FileNames = new string[QuantityOfImages]; 
                ImageToolTip = new string[QuantityOfImages];
                FilesInfo = new FileInfo[QuantityOfImages];

                // Itera entre los archivos y obtiene su información(es) y nombre(s)
                for (int i = 0; i < QuantityOfImages; i++)
                {
                    FileNames[i] = OpenDialog.FileNames[i];
                    FilesInfo[i] = new FileInfo(FileNames[i]);
                }

                ShowFilesInfo(); // Llamada a la función que muestra su info en la UI

            }

            // Muestra en la UI cuantas imagenes fueron selecciondas
            LblQuantity.Text += $" {QuantityOfImages}";

            // Crea los componente(s) para previsualizar las imagenes
            await ImagePreview(); 
        }

        //  +---------------------------------------------------------------------------------+
        //  | Muestra la información de la(s) imagen(es) seleccionada(s) por el usuario(a)    |
        //  +---------------------------------------------------------------------------------+
        private void ShowFilesInfo()
        {
            // Itera através de los archivos
            for (int i = 0; i < FilesInfo.Length; i++)
            {
                // Obtiene el número de imagen, nombre, Peso en B, KB, MB, GB, entre otros.
                // Y, por último fecha de creación
                ImageToolTip[i] = $"{i + 1} | {FilesInfo[i].Name} | {FileUtils.CalculateSize(FilesInfo[i].Length)} | {FilesInfo[i].CreationTime} {Environment.NewLine}";

                // Acumular el tamaño de la(s) imagenes en disco
                ImagesLength += FilesInfo[i].Length; 

                // Añade la información a una lista en la UI
                LbFIlesInfo.Items.Add(ImageToolTip[i]);
            }

            // Muestra el tamaño en disco en total de las imagenes
            LbFIlesInfo.Items.Add($"Tamaño total: {FileUtils.CalculateSize(ImagesLength)}");
        }

        //  +---------------------------------------------------------------------------------+
        //  | Muestra un texto de descripción con los siguientes datos:                       |
        //  | Numero de imagen, Nombre de archivo, Tamaño en disco, Fecha de creación.        |
        //  +---------------------------------------------------------------------------------+
        private void Hover(object sender, EventArgs e)
        {
            // Obtiene el componente actual
            PictureBox currentComponent = sender as PictureBox;

            // Inicializa el tipo ToolTip
            ImgToolTip = new ToolTip();

            // Se obtiene el índice del componente
            int index = Int32.Parse(currentComponent.Name);

            // Se busca, y añade al componente gráfico una descripción del archivo
            ImgToolTip.SetToolTip(currentComponent, ImageToolTip[index]);
            
        }

        //  +---------------------------------------------------------------------------------+
        //  | Crea los componentes gráficos que le permiten al usuario previsualizar la(s)    |
        //  | imagen(es) que va redimensionar el programa.                                    |
        //  +---------------------------------------------------------------------------------+
        private Task ImagePreview()
        {
            // Limpia el contenedor
            FlpImages.Controls.Clear(); 

            // Declara una Picturebox
            PictureBox SelectedImage;

            // Crea el componente N veces y lo añade al contenedor
            for (int i = 0; i < QuantityOfImages; i++)
            {
                SelectedImage = new PictureBox();
                SelectedImage.Name = $"{i}";             // Nombre = depende del índice
                SelectedImage.Size = new Size(300, 225); // Tamaño Ancho, Alto
                SelectedImage.BackColor = Color.Transparent; // Fondo de color = transparente
                SelectedImage.BackgroundImage = Image.FromFile(FileNames[i]); // Añades la imagen asociada al índice.
                SelectedImage.MouseEnter += UiUtils.PaintBorder;  // Eventos cuando entra el mouse, 
                SelectedImage.MouseHover += Hover;                // cuando sale y cuando pasas encima
                SelectedImage.MouseLeave += UiUtils.RemoveBorder; // del componente
                SelectedImage.BackgroundImageLayout = ImageLayout.Stretch; // Se estira la imagen
                SelectedImage.Cursor = Cursors.Hand; // Se le asigna un cursor de mano
                SelectedImage.Margin = new Padding(10, 10, 10, 10); // Margin hacia dentro
                SelectedImage.Update(); // Actualziar el componente

                FlpImages.Controls.Add(SelectedImage); // Añadirlo al contenedor
                FlpImages.Update(); // Actualizar el contenedor

            }

            // Reportar que la tarea esta completa
            return Task.CompletedTask;

        }

        //  +-------------------------------------------------+
        //  | Regresa la inferfaz gráfica a su estado inicial |
        //  +-------------------------------------------------+
        private void ResetUi()
        {
            LblQuantity.Text = "Imagen(es) seleccionada(s):";
            LbFIlesInfo.Items.Clear();
        }

        //  +---------------------------------------------------------------------------------+
        //  | Valida los campos requeridos antes de permitirle al usuario continuar con       |
        //  | selección de imagen(es).                                                        |
        //  +---------------------------------------------------------------------------------+
        private async Task ValidateInput()
        {
            IsAspectRatioEnabled = CbxAspectRatio.Checked; // Saber si esta marcada la opcion de aspect ratio

            if (TxtWidth.Text.Equals("")) // Si el campo esta vacio
            {
                MessageBox.Show("El campo esta vació.",
                                "¡Atención!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                TxtWidth.Focus();
                return;
            }

            if (TxtHeight.Text.Equals("")) // Si el campo esta vacio
            {
                MessageBox.Show("El campo esta vació.",
                                "¡Atención!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                TxtHeight.Focus();
                return;
            }

            if (CbxFormat.SelectedIndex == -1) // Si no se ha seleccionado ningun formato
            {
                MessageBox.Show("Escoge un formato de imagen", 
                                "¡Atención!", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Warning);
                CbxFormat.Focus();
                return;
            }

            if (IsAspectRatioEnabled && CmbAspectRatio.SelectedIndex == -1)
            {
                MessageBox.Show("Escoge una relación de aspecto",
                                "¡Atención!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
            
            ImageWidth = Int32.Parse(TxtWidth.Text); // Se obtiene el ancho
            ImageHeight = Int32.Parse(TxtHeight.Text); // Se obtiene el alto
            FileFormat = CbxFormat.Text.ToLower(); // Se obtiene el formato 

            BtnSaveImages.Enabled = true; // Habilita el boton que 
                                          // genera las nuevas imagenes

            await SelectImages(); // Llamada a función que genera la previsualizacion
                                  // De las imagenes.
        }

        //  +---------------------------------------------------------------------+
        //  | Redimensiona la imagen utilizando la clase de graficos manteniendo  |
        //  | la calidad lo mas posible, además de contar con la posibilidad de   |
        //  | convertir a otro formato.                                           |
        //  +---------------------------------------------------------------------+
        private Bitmap ResizeImg(string FileName, int Width, int Height)
        {
            // Obtiene la imagen desde la ruta dada como argumento
            Image IImage = Image.FromFile(FileName);

            // Crea un rectangulo en base al ancho y alto recibidos
            Rectangle DestRectangle = new Rectangle(0, 0, Width, Height);

            // Crea un bitmap con el ancho y alto requeridos
            Bitmap DistImage = new Bitmap(Width, Height); 

            // Establecemos la resolución del bitmap obtenido desde la imagen
            DistImage.SetResolution(IImage.HorizontalResolution, IImage.VerticalResolution);

            // Utilizando gráficos aplicamos lo siguiente:
            using (Graphics graphics = Graphics.FromImage(DistImage))
            {
                // Copiamos la imagen de fuente
                graphics.CompositingMode = CompositingMode.SourceCopy;
                
                // Establecemos la calidad de composición en alta
                graphics.CompositingQuality = CompositingQuality.HighQuality;

                // Establecemos la calidad de interpolado en alta
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

                // Aplicamos antialias
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                
                // Y el modo de ajuste de pixel en máxima cálidad
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    // Establecemos el WrapMode "Voltear mosaico"
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    
                    // Dibujamos la imagen con los atributos
                    graphics.DrawImage(IImage,
                                       DestRectangle,
                                       0,
                                       0,
                                       IImage.Width,
                                       IImage.Height,
                                       GraphicsUnit.Pixel,
                                       wrapMode);
                }

            }

            // Retornamos la imagen redimensionada
            return DistImage;

        }

        //  +--------------------------------------------+
        //  | Abre un diálogo donde podemos elegir donde |
        //  | guardar las nuevas imaenes redimensionadas |
        //  +--------------------------------------------+
        private void SaveFiles()
        {
            // Incialziar el diálogo
            SaveDialog = new SaveFileDialog();

            // Propieades
            SaveDialog.Title = "Guardar imagen(es)";
            SaveDialog.InitialDirectory = Application.StartupPath;
            SaveDialog.RestoreDirectory = true;

            // Filtros dependiendo del nuevo formato aplicado
            if (FileFormat == "jpg") SaveDialog.Filter = "JPG Image(.jpg)|*.jpg";
            if (FileFormat == "png") SaveDialog.Filter = "Png Image(.png)|*.png";

            Result = SaveDialog.ShowDialog(); // Invocación del diálogo

            // Validación
            if (Result == DialogResult.Cancel ||
                Result == DialogResult.None ||
                Result == DialogResult.No ||
                Result == DialogResult.Abort)
            {
                return;
            }

            if (Result == DialogResult.OK)
            {
                // Se modifica el nombre del (los) archivos para la ruta
                SaveDialog.FileName = SaveDialog.FileName.Replace($".{FileFormat}", "");

                for (int i = 0; i < FileNames.Length; i++)
                {
                    // Dependiendo del formato escogido se guarda la nueva imagen en la ruta dada por el usuario
                    if (FileFormat == "png") ResizeImg(FileNames[i], ImageWidth, ImageHeight).Save($"{SaveDialog.FileName} {i + 1}.{FileFormat}", ImageFormat.Png);
                    if (FileFormat == "jpg") ResizeImg(FileNames[i], ImageWidth, ImageHeight).Save($"{SaveDialog.FileName} {i + 1}.{FileFormat}", ImageFormat.Jpeg);
                }

                if (FileNames.Length > 1)
                {
                    MessageBox.Show("¡Imagenes generadas correctamente!",
                                    "¡Exito!",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }

                if (FileNames.Length == 1)
                {
                    MessageBox.Show("¡Imagen generada correctamente!",
                                    "¡Exito!",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                }

                DialogResult DResult = MessageBox.Show("¿Desea abrir la carpeta donde están las imagenes?",
                                                       "Pregunta",
                                                       MessageBoxButtons.YesNo,
                                                       MessageBoxIcon.Information);

                if (DResult == DialogResult.Yes)
                {
                    // Ir al directorio donde se están las imagenes redimensionadas
                    Process.Start("explorer.exe", Path.GetDirectoryName(SaveDialog.FileName));
                }


            }

        }

        //  +---------------------------------------------------------------------+
        //  | Calcula la relacción de aspecto de la nueva(s) imagenes que serán   |
        //  | redimensionadas (opcional) formula rescatada de:                    |
        //  | https://andrew.hedges.name/experiments/aspect_ratio/                |
        //  +---------------------------------------------------------------------+
        private void CalculateAspecRatio(string Target)
        {

            if (!IsAspectRatioEnabled) return; // Si la relación de aspecto no
                                               // esta habilitada la funcion no se ejecuta

            if (CmbAspectRatio.SelectedIndex == -1) 
            {
                MessageBox.Show("Escoge una relación de aspecto", // Si no se ha seleccionado una
                                "¡Atención!",                     // relación de aspecto
                                MessageBoxButtons.OK,             // de igual forma no se ejecuta
                                MessageBoxIcon.Warning);

                CmbAspectRatio.Focus();
                return;
            }

            // Evita cambiar el valor del mismo campo y hacer que la función
            // se ejecute varias veces hasta que el tamaño es igual a cero
            if (TxtHeight.Text.Equals("") && Target == "width") return;

            // Evita cambiar el valor del mismo campo y hacer que la función
            // se ejecute varias veces hasta que el tamaño es igual a cero
            if (TxtWidth.Text.Equals("") && Target == "height") return;

            double Ratio; // La relacción de aspecto en formato decimal

            double Width; // Ancho recuperado del componente TxtWidth
            double Height; // Alto recuperado del componente TxtHeight

            int NewWidth; // El nuevo Ancho asignado al TxtWidth respetando el Aspect Ratio
            int NewHeight; // El nuevo Alto asignado al TxtWidth respetando el Aspect Ratio

            switch (Target)
            {
                case "width":
                            // Ejemplo de calculo 16 / 9 = 1.777778
                    Ratio = AspectRatioX[CmbAspectRatio.SelectedIndex] / AspectRatioY[CmbAspectRatio.SelectedIndex];
                    Height = Double.Parse(TxtHeight.Text);

                    NewWidth = (int)Math.Round(Ratio * Height, 1); // Se redondea para evitar decimales

                    TxtWidth.Text = NewWidth.ToString();

                    break;
                case "height":
                            // Ejmplo de calculo 9 / 16 = 0.5625
                    Ratio = AspectRatioY[CmbAspectRatio.SelectedIndex] / AspectRatioX[CmbAspectRatio.SelectedIndex];
                    Width = Double.Parse(TxtWidth.Text);

                    NewHeight = (int)Math.Round(Ratio * Width, 1); // Se redondea para evitar decimales

                    TxtHeight.Text = NewHeight.ToString();

                    break;
            }

        }

        #endregion

        #region EVENTS

        //  +------------------------------------------------+
        //  | Abre un diálogo para escoger las imagenes a    |
        //  | redimensionar.                                 |
        //  +------------------------------------------------+
        private async void BtnSelectImages_Click(object sender, EventArgs e)
        {
            ResetUi();
            await ValidateInput();
        }

        //  +------------------------------------------------+
        //  | Valida los campos para permitir solo números   |
        //  +------------------------------------------------+
        private void ValidateField(KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        //  +------------------------------------------------+
        //  | Este evento se ejecuta cuando presionas una    |
        //  | tecla utilzando el componente                  |
        //  +------------------------------------------------+
        private void TxtWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateField(e);
            
        }

        //  +------------------------------------------------+
        //  | Este evento se ejecuta cuando presionas una    |
        //  | tecla utilzando el componente                  |
        //  +------------------------------------------------+
        private void TxtHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateField(e);
            
        }

        //  +------------------------------------------------+
        //  | Cuando se marca la opción de este componete    |
        //  | Se habilita el que permite seleccionar que     |
        //  | relación de aspecto quieres utilizar.          |
        //  +------------------------------------------------+
        private void CbxAspectRatio_Click(object sender, EventArgs e)
        {
            IsAspectRatioEnabled = CbxAspectRatio.Checked;
            CmbAspectRatio.Enabled = CbxAspectRatio.Checked;
        }

        //  +-------------------------------------------------------------+
        //  | Este evento sucede cuando la tecla es presionada, y esta    |
        //  | tiene un tiempo de espera para regresar a su estado inicial |
        //  +-------------------------------------------------------------+
        private void TxtWidth_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateAspecRatio("height");
        }

        //  +-------------------------------------------------------------+
        //  | Este evento sucede cuando la tecla es presionada, y esta    |
        //  | tiene un tiempo de espera para regresar a su estado inicial |
        //  +-------------------------------------------------------------+
        private void TxtHeight_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateAspecRatio("width");
        }

        //  +-------------------------------------------------------------+
        //  | Evento - disparado cuando es presionado el boton para       |
        //  | generar las nuevas imagenes.                                |
        //  +-------------------------------------------------------------+
        private void BtnSaveImages_Click(object sender, EventArgs e)
        {
            SaveFiles();
        }

        //  +-----------------------------+
        //  | Selector de tema de colores |
        //  +-----------------------------+
        private void TsCmbTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            // REFACTORIZAR ESTE EVENTO, vaya porqueria estoy escribiendoa aquí.
            // Jorge del futuro perdona :C

            int SelectedTheme = TsCmbTheme.SelectedIndex;

            // CASE 0 == CASE DARK
            // CASE 1 == CASE LIGHT

            string DARK_FIRST_BG = "#151515";
            string LIGHT_FIRST_BG = "#FFFFFF";
            string DARK_FG = "#FFFFFF";
            string LIGHT_FG = "#000000";

            switch (SelectedTheme)
            {
                case 0:

                    MsApp.BackColor = UiUtils.GetColor("#151515");
                    MsApp.ForeColor = UiUtils.GetColor("#FFF");


                    ScpResizer.BackColor = UiUtils.GetColor("#303030");

                    UiUtils.StyleLabel(DARK_FIRST_BG, DARK_FG, LblInfo);
                    UiUtils.StyleContainer(DARK_FIRST_BG, DARK_FG, PnlSideBar);
                    UiUtils.StyleContainer(DARK_FIRST_BG, DARK_FG, FlpImages);

                    TxtWidth.BackColor = UiUtils.GetColor("#303030");
                    TxtWidth.ForeColor = UiUtils.GetColor("#FFF");

                    BtnSelectImages.ForeColor = Color.Black;

                    TxtHeight.BackColor = UiUtils.GetColor("#303030");
                    TxtHeight.ForeColor = UiUtils.GetColor("#FFF");

                    LbFIlesInfo.BackColor = UiUtils.GetColor("#303030");
                    LbFIlesInfo.ForeColor = UiUtils.GetColor("#FFF");

                    break;
                case 1:

                    MsApp.BackColor = UiUtils.GetColor("#FFF");
                    MsApp.ForeColor = UiUtils.GetColor("#000");


                    ScpResizer.BackColor = UiUtils.GetColor("#FFF");

                    UiUtils.StyleLabel(LIGHT_FIRST_BG, LIGHT_FG, LblInfo);
                    UiUtils.StyleContainer(LIGHT_FIRST_BG, LIGHT_FG, PnlSideBar);
                    UiUtils.StyleContainer(LIGHT_FIRST_BG, LIGHT_FG, FlpImages);


                    TxtWidth.BackColor = UiUtils.GetColor("#F5F5F5");
                    TxtWidth.ForeColor = UiUtils.GetColor("#000");

                    TxtHeight.BackColor = UiUtils.GetColor("#F5F5F5");
                    TxtHeight.ForeColor = UiUtils.GetColor("#000");

                    LbFIlesInfo.BackColor = UiUtils.GetColor("#F5F5F5");
                    LbFIlesInfo.ForeColor = UiUtils.GetColor("#000");

                    break;
            }
        }

        //  +-------------------------------------------------------------+
        //  | Sobrescribir la vista gráfica del (los) componentes         |
        //  | ComboBox                                                    |
        //  +-------------------------------------------------------------+
        private void CbxFormat_DrawItem(object sender, DrawItemEventArgs e)
        {

            int Index = TsCmbTheme.SelectedIndex;

            switch(Index)
            {

                case -1:
                    UiUtils.DrawItem(sender, e, Index);
                    break;

                case 0:
                    UiUtils.DrawItem(sender, e, Index);
                    break;
                case 1:
                    UiUtils.DrawItem(sender, e, Index);
                    break;
            }


        }

        //  +-----------------------------+
        //  | Cuando se cambia de opción  |
        //  | en el radio de aspecto      |
        //  | re calcular la resolucíón   |
        //  +-----------------------------+
        private void CmbAspectRatio_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateAspecRatio("height");
        }

        #endregion

    }
}
