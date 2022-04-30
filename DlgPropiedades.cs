using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PE22A_JAMZ
{
    // +------------------------------------------------------------------------+
    // |      Diálogo para modificar las propiedades del polígono dibujado      |
    // |                          JAMZ DATE: 01/04/2022                         |
    // +------------------------------------------------------------------------+
    public partial class DlgPropiedades : Form
    {

        // +-------------------------------------------------------------------------+
        // |                    VARIABLES GLOBLABLES DlgPropiedades                  |
        // +-------------------------------------------------------------------------+

        Color colorContorno;
        Color colorContenido;
        Color colorPuntos;

        

        Random rnd;

        public DlgPropiedades()
        {
            InitializeComponent();

            // Centrar el formulario en la pantalla
            this.CenterToScreen();

        }

        private Color applyHexColor(string hexString)
        {
            return ColorTranslator.FromHtml(hexString);
        }

        private const int CP_DISABLE_CLOSE_BUTTON = 0x200;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle = cp.ClassStyle | CP_DISABLE_CLOSE_BUTTON;
                return cp;
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {

            // Validación
            
            if (TxtEscalaX.Text.Equals(""))
            {
                MessageBox.Show("Inserte, un numero valido en el campo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtEscalaX.Focus();
                return;
            }

            if (TxtEscalaY.Text.Equals(""))
            {
                MessageBox.Show("Inserte, un numero valido en el campo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtEscalaY.Focus();
                return;
            }

            if (TxtContorno.Text.Equals(""))
            {
                MessageBox.Show("Inserte, un numero valido en el campo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtContorno.Focus();
                return;
            }


            // ============== Enviar datos hacia DlgProyectos =============



            // Enviar datos autogenerados si los campos están vacios.

            //DlgProyecto.Contorno = applyHexColor("#" + TxtColorContorno.Text);
            //DlgProyecto.Area = applyHexColor("#" + TxtColorContenido.Text);
            //DlgProyecto.Puntos = applyHexColor("#" + TxtColorPuntos.Text);

            DlgProyecto.Contorno = PbxColorContorno.BackColor;
            DlgProyecto.Area = PbxColorContenido.BackColor;
            DlgProyecto.Puntos = PbxColorPuntos.BackColor;

            DlgProyecto.ContornoAncho = Int32.Parse(TxtContorno.Text);
            DlgProyecto.escalaX = Int32.Parse(TxtEscalaX.Text);
            DlgProyecto.escalaY = Int32.Parse(TxtEscalaY.Text);

            // Re píntar el polígono con las nuevas propiedades
            new DlgProyecto().DibujarPoligono();

            this.Dispose();
        }

        // +-------------------------------------------------------------------------+
        // |        Inicializar colores aleatorios cuando se carga el formulario.    |
        // +-------------------------------------------------------------------------+
        private void DlgPropiedades_Load(object sender, EventArgs e)
        {

            // Instanciar random

            rnd = new Random();

            // Obtener colores

            colorContorno = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            colorContenido = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            colorPuntos = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));

            // Ingresarlos en la previsualización antes de aplicarlos

            PbxColorContorno.BackColor = colorContorno;
            PbxColorContenido.BackColor = colorContenido;
            PbxColorPuntos.BackColor = colorPuntos;

        }

        // +--------------------------------------------------------------------------+
        // |     Validar el valor hexadecimal de un color para el campo contorno.     |
        // +--------------------------------------------------------------------------+
        private void TxtColorContorno_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }


        private void ElegirColor(PictureBox pictureBox)
        {
            // Declaración
            ColorDialog colorDialog;
            DialogResult dialogResult;

            // Inicialización
            colorDialog = new ColorDialog();

            // Propiedades del diálogo
            colorDialog.AllowFullOpen = true;

            // Mostrar diálogo
            dialogResult = colorDialog.ShowDialog();

            if (dialogResult == DialogResult.Cancel)
            {
                return;
            }

            if (dialogResult == DialogResult.OK)
            {
                pictureBox.BackColor = colorDialog.Color;
            }

        }

        private void PbxColorContenido_Click(object sender, EventArgs e)
        {
            ElegirColor( (PictureBox) sender);
        }
    }
}
