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
using System.Windows.Forms;

namespace PE22A_JAMZ.src.TabRenderer
{
    public partial class ResizeImage : Form
    {
        public ResizeImage()
        {
            InitializeComponent();
        }

        bool IsAspectRatioEnabled;
        private int ImageWidth;
        private int ImageHeight;
        private int QuantityOfImages;
        private string[] FileNames;
        private string[] ImageToolTip;
        private string ImageFormat;
        private FileInfo[] FilesInfo;
        private ToolTip ImgToolTip;

        private OpenFileDialog OpenDialog;
        private SaveFileDialog SaveDialog;
        private DialogResult Result;

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

        private async Task SelectImages()
        {
            OpenDialog = new OpenFileDialog();

            OpenDialog.InitialDirectory = @"C:\";
            OpenDialog.Title = "Escoge imagen(es) a redimensionar";
            OpenDialog.RestoreDirectory = true;
            OpenDialog.Multiselect = true;

            if (ImageFormat == "jpg") OpenDialog.Filter = "JPG Image(.jpg)|*.jpg";
            if (ImageFormat == "png") OpenDialog.Filter = "Png Image(.png)|*.png";

            Result = OpenDialog.ShowDialog();

            if (Result == DialogResult.Cancel ||
                Result == DialogResult.None ||
                Result == DialogResult.No ||
                Result == DialogResult.Abort)
            {
                return;
            }

            if (Result == DialogResult.OK)
            {

                QuantityOfImages = OpenDialog.FileNames.Length;

                FileNames = new string[QuantityOfImages];
                ImageToolTip = new string[QuantityOfImages];
                FilesInfo = new FileInfo[QuantityOfImages];

                for (int i = 0; i < QuantityOfImages; i++)
                {
                    FileNames[i] = OpenDialog.FileNames[i];
                    FilesInfo[i] = new FileInfo(FileNames[i]);
                }

                ShowFilesInfo();

            }

            LblQuantity.Text += $" {QuantityOfImages}";

            await ImagePreview();
        }

        private void ShowFilesInfo()
        {

            RtbFilesInfo.AppendText("Información acerca de las imagenes: " + Environment.NewLine);

            for (int i = 0; i < FilesInfo.Length; i++)
            {

                ImageToolTip[i] = $"Archivo: {FilesInfo[i].Name}, Tamaño: {FilesInfo[i].Length}Bytes, Fecha de cración: {FilesInfo[i].CreationTime} {Environment.NewLine}";

                RtbFilesInfo.AppendText(
                    $"Archivo: {FilesInfo[i].Name}, Tamaño: {FilesInfo[i].Length}Bytes, Fecha de creación: {FilesInfo[i].CreationTime} {Environment.NewLine} {Environment.NewLine}"
                    );
            }

        }

        private void Hover(object sender, EventArgs e)
        {

            PictureBox currentComponent = sender as PictureBox;

            ImgToolTip = new ToolTip();

            int index = Int32.Parse(currentComponent.Name);

            ImgToolTip.SetToolTip(currentComponent, ImageToolTip[index]);
            
        }

        private Task ImagePreview()
        {

            FlpImages.Controls.Clear();

            PictureBox SelectedImage;

            for (int i = 0; i < QuantityOfImages; i++)
            {
                SelectedImage = new PictureBox();
                SelectedImage.Name = $"{i}";
                SelectedImage.Size = new Size(400, 300);
                SelectedImage.BackColor = Color.Transparent;
                SelectedImage.BackgroundImage = Image.FromFile(FileNames[i]);
                SelectedImage.MouseEnter += UiUtils.PaintBorder;
                SelectedImage.MouseHover += Hover;
                SelectedImage.MouseLeave += UiUtils.RemoveBorder;
                SelectedImage.BackgroundImageLayout = ImageLayout.Stretch;
                SelectedImage.Cursor = Cursors.Hand;
                SelectedImage.Margin = new Padding(10, 10, 10, 10);
                SelectedImage.Update();

                FlpImages.Controls.Add(SelectedImage);
                FlpImages.Update();

            }

            return Task.CompletedTask;

        }

        private void ResetUi()
        {
            LblQuantity.Text = "Imagen(es) seleccionada(s):";
        }

        private async Task ValidateInput()
        {
            IsAspectRatioEnabled = CbxAspectRatio.Checked;

            if (TxtWidth.Text.Equals(""))
            {
                MessageBox.Show("El campo esta vació.",
                                "¡Atención!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                TxtWidth.Focus();
                return;
            }

            if (TxtHeight.Text.Equals(""))
            {
                MessageBox.Show("El campo esta vació.",
                                "¡Atención!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                TxtHeight.Focus();
                return;
            }

            if (CbxFormat.SelectedIndex == -1)
            {
                MessageBox.Show("Escoge un formato de imagen", 
                                "¡Atención!", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Warning);
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
            
            ImageWidth = Int32.Parse(TxtWidth.Text);
            ImageHeight = Int32.Parse(TxtHeight.Text);
            ImageFormat = CbxFormat.Text.ToLower();

            BtnSaveImages.Enabled = true;

            await SelectImages();
            
        }

        private async void BtnSelectImages_Click(object sender, EventArgs e)
        {
            ResetUi();
            await ValidateInput();
        }

        private void CalculateAspecRatio(string Target)
        {

            if (!IsAspectRatioEnabled) return;

            if (CmbAspectRatio.SelectedIndex == -1)
            {
                MessageBox.Show("Escoge una relación de aspecto",
                                "¡Atención!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                CmbAspectRatio.Focus();
                return;
            }

            if (TxtHeight.Text.Equals("") && Target == "width") return;
            if (TxtWidth.Text.Equals("") && Target == "height") return;

            double Ratio;

            double Width;
            double Height;

            int NewWidth;
            int NewHeight;

            switch(Target)
            {
                case "width":
                    
                    Ratio = AspectRatioX[CmbAspectRatio.SelectedIndex] / AspectRatioY[CmbAspectRatio.SelectedIndex];
                    Height = Double.Parse(TxtHeight.Text);

                    NewWidth = (int)Math.Round(Ratio * Height, 1);

                    TxtWidth.Text = NewWidth.ToString();

                    break;
                case "height":
                    
                    Ratio = AspectRatioY[CmbAspectRatio.SelectedIndex] / AspectRatioX[CmbAspectRatio.SelectedIndex];
                    Width = Double.Parse(TxtWidth.Text);

                    NewHeight = (int)Math.Round(Ratio * Width, 1);

                    TxtHeight.Text = NewHeight.ToString();

                    break;
            }

        }

        private void ValidateField(KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        #region EVENTOS

        private void TxtWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateField(e);
            
        }

        private void TxtHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateField(e);
            
        }

        private void CbxAspectRatio_Click(object sender, EventArgs e)
        {
            IsAspectRatioEnabled = CbxAspectRatio.Checked;
        }

        private void TxtWidth_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateAspecRatio("height");
        }

        private void TxtHeight_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateAspecRatio("width");
        }

        private void SaveFiles()
        {
            SaveDialog = new SaveFileDialog();

            SaveDialog.Title = "Guardar imagen(es)";
            SaveDialog.InitialDirectory = Application.StartupPath;
            SaveDialog.RestoreDirectory = true;

            if (ImageFormat == "jpg") SaveDialog.Filter = "JPG Image(.jpg)|*.jpg";
            if (ImageFormat == "png") SaveDialog.Filter = "Png Image(.png)|*.png";

            Result = SaveDialog.ShowDialog();

            if (Result == DialogResult.Cancel ||
                Result == DialogResult.None ||
                Result == DialogResult.No ||
                Result == DialogResult.Abort)
            {
                return;
            }

            if (Result == DialogResult.OK)
            {

                SaveDialog.FileName = SaveDialog.FileName.Replace($".{ImageFormat}", "");

                for (int i = 0; i < FileNames.Length; i++)
                {
                    ResizeImg(FileNames[i], ImageWidth, ImageHeight).Save($"{SaveDialog.FileName} {i + 1}.{ImageFormat}");
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
                    Process.Start("explorer.exe", Path.GetDirectoryName(SaveDialog.FileName));
                }


            }

        }

        private Bitmap ResizeImg(string FileName, int Width, int Height)
        {

            Image IImage = Image.FromFile(FileName);

            Rectangle DestRectangle = new Rectangle(0, 0, Width, Height);
            Bitmap DistImage = new Bitmap(Width, Height);

            DistImage.SetResolution(IImage.HorizontalResolution, IImage.VerticalResolution);

            using (Graphics graphics = Graphics.FromImage(DistImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
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

            return DistImage;

        }

        private void BtnSaveImages_Click(object sender, EventArgs e)
        {
            SaveFiles();
        }

        #endregion


    }
}
