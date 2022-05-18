using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Net.Http;
using System.Xml;
using System.Net;
using PE22A_JAMZ.src.Utils;
using PE22A_JAMZ.src.TabRenderer;

namespace PE22A_JAMZ
{

    // +------------------------------------------------------------------------+
    // |   Diálogo del proyecto final de la materia Programación Estructurada   |
    // |                          JAMZ DATE: 07/03/2022                         |
    // +------------------------------------------------------------------------+

    public partial class DlgProyecto : Form
    {
        public DlgProyecto()
        {
            InitializeComponent();
        }

        #region UI_STYLES

        private void StyleTabControl(object sender, DrawItemEventArgs e)
        {
            Brush BBrush = new SolidBrush(ApplyHexColor("#303030"));
            Brush TBrush = new SolidBrush(ApplyHexColor("#fff"));

            StringFormat SF = new StringFormat();
            SF.LineAlignment = StringAlignment.Center;
            SF.Alignment = StringAlignment.Center;

            TabPage Page = TbcPrincipal.TabPages[e.Index];

            Rectangle Rect = e.Bounds;
            e.Graphics.FillRectangle(BBrush, Rect);
            e.Graphics.DrawString(
                        Page.Text,
                        Page.Font,
                        TBrush,
                        Rect,
                        SF
                    );
            e.DrawFocusRectangle();

            Page.BorderStyle = BorderStyle.None;

        }

        #endregion

        // +------------------------------------------------------------+
        // |        Carga los aspectos visuales de la aplicación.       |
        // +------------------------------------------------------------+

        private void DlgProyecto_Load(object sender, EventArgs e)
        {

            // Cambiar aspecto visual del datagrid view 
            DgvP3FlujosNetos.EnableHeadersVisualStyles = false;

            // Sobreescribir la vista gráfica de TabPrincipal
            TbcPrincipal.DrawMode = TabDrawMode.OwnerDrawFixed;
            TbcPrincipal.Appearance = TabAppearance.FlatButtons;
            TbcPrincipal.DrawItem += StyleTabControl;

            // Cambiar el color de fondo de PnlP5Derecho
            // PnlP5Derecho.BackColor = ApplyHexColor("#fff");

            // Cambiar el color de fondo de PnlP5Lienzo
            // PnlP5Lienzo.BackColor = ApplyHexColor("#eee");

            // Cambiar el color de la fila cuando es par

            DgvP5DatosEspaciales.AlternatingRowsDefaultCellStyle.BackColor = ApplyHexColor("#f2f2f2");

            // Establecer formato de la imagen a PNG en práctica 5

            CbxFormatoImagen.SelectedIndex = 0; // 0 -> PNG

            #region Configuración práctica 6
            if (Environment.CurrentDirectory.Contains("debug")) MessageBox.Show("Hola");
            Directory.SetCurrentDirectory("..\\..\\..\\");
            LoadEnv();
            #endregion

        }

        // ===========================================================================

        // +-------------------------------------------------------------------------+
        // |                               Practica 2                                |
        // +-------------------------------------------------------------------------+

        // +--------------------------------------------------------------------+
        // |Obtiene un dato de un producto determinado desde la tabla productos.|
        // +--------------------------------------------------------------------+

        private string GetDatoProducto(string Producto, string NombreColumna)
        {
            String Resultado;

            Resultado = null;

            for (int i = 0; i < DgvTblProductos.Rows.Count - 1; i++)
            {
                if (Producto == DgvTblProductos.Rows[i].Cells[0].Value.ToString())
                {
                    Resultado = DgvTblProductos.Rows[i].Cells[NombreColumna].Value.ToString();
                    break;
                }
            }

            return Resultado;
        }

        // +-------------------------------------------------------------------+
        // |         Llenar los datos de prueba del carrito de compras.        |
        // +-------------------------------------------------------------------+
        private void BtnLlenarCarrito_Click(object sender, EventArgs e)
        {
            DgvCarrito.Rows.Clear();
            for (int i = 0; i < 4; i++)
            {
                DgvCarrito.Rows.Add();
                DgvCarrito.Rows[i].Cells[0].Value = "Producto " + (i + 1);
                DgvCarrito.Rows[i].Cells[1].Value = "1";
            }
        }

        // +------------------------------------------------------------------+
        // |               Borra los contenidos de los campos.                |
        // +------------------------------------------------------------------+
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            TbxAlto.Clear();
            TbxAncho.Clear();
            TbxLargo.Clear();
            TbxFragilidad.Clear();
            TbxPeso.Clear();
            DgvCarrito.Rows.Clear();
        }

        // +------------------------------------------------------------------+
        // |         Obtener productos (añadir base de datos después)         |
        // +------------------------------------------------------------------+
        private void BtnLlenarTabla_Click(object sender, EventArgs e)
        {
            Random randomInstance = new Random();

            DgvTblProductos.Rows.Clear();

            for (int i = 0; i < 4; i++)
            {
                DgvTblProductos.Rows.Add();
                DgvTblProductos.Rows[i].Cells[0].Value = "Producto " + (i + 1); // Producto

                switch (i)
                {
                    case 0:

                        DgvTblProductos.Rows[i].Cells[1].Value = "2"; // Alto
                        DgvTblProductos.Rows[i].Cells[2].Value = "2"; // Ancho
                        DgvTblProductos.Rows[i].Cells[3].Value = "2"; // Largo
                        DgvTblProductos.Rows[i].Cells[4].Value = "0.2"; // Peso
                        DgvTblProductos.Rows[i].Cells[5].Value = "3"; // Fragilidad

                        break;
                    case 1:

                        DgvTblProductos.Rows[i].Cells[1].Value = "5"; // Alto
                        DgvTblProductos.Rows[i].Cells[2].Value = "3"; // Ancho
                        DgvTblProductos.Rows[i].Cells[3].Value = "2"; // Largo
                        DgvTblProductos.Rows[i].Cells[4].Value = "0.5"; // Peso
                        DgvTblProductos.Rows[i].Cells[5].Value = "1"; // Fragilidad

                        break;
                    case 2:

                        DgvTblProductos.Rows[i].Cells[1].Value = "1"; // Alto
                        DgvTblProductos.Rows[i].Cells[2].Value = "2"; // Ancho
                        DgvTblProductos.Rows[i].Cells[3].Value = "2"; // Largo
                        DgvTblProductos.Rows[i].Cells[4].Value = "1.0"; // Peso
                        DgvTblProductos.Rows[i].Cells[5].Value = "1"; // Fragilidad

                        break;
                    case 3:

                        DgvTblProductos.Rows[i].Cells[1].Value = "6"; // Alto
                        DgvTblProductos.Rows[i].Cells[2].Value = "8"; // Ancho
                        DgvTblProductos.Rows[i].Cells[3].Value = "10"; // Largo
                        DgvTblProductos.Rows[i].Cells[4].Value = "1.1"; // Peso
                        DgvTblProductos.Rows[i].Cells[5].Value = "2"; // Fragilidad

                        break;
                }

            }
        }

        // +------------------------------------------------------------------+
        // |                          Calcular Caja                           |
        // +------------------------------------------------------------------+
        private void BtnCalcularCaja_Click(object sender, EventArgs e)
        {
            double PesoTotal;
            double LargoTotal;
            double AnchoTotal;
            double AltoTotal;
            double BaseTotal;
            int FragilidadFinal;

            PesoTotal = 0;
            FragilidadFinal = 0;
            LargoTotal = 0;
            AnchoTotal = 0;
            AltoTotal = 0;
            BaseTotal = 0;

            // Validar si las tablas estan vacias :D

            if (DgvCarrito.Rows.Count <= 1)
            {
                MessageBox.Show("El carrito de compras se encuentra vació.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (DgvTblProductos.Rows.Count <= 1)
            {
                MessageBox.Show("La tabla de productos se encuentra vacía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            for (int i = 0; i < DgvCarrito.Rows.Count - 1; i++)
            {
                string Producto;
                int Cantidad;
                double Alto;
                double Ancho;
                double Largo;
                double Peso;
                int Fragilidad;

                // Validación calidad de datos

                if (DgvCarrito.Rows[i].Cells[0].Value == null)
                {
                    DgvCarrito.ClearSelection();
                    MessageBox.Show("Ingrese el nombre del producto");
                    DgvCarrito.Rows[i].Cells[0].Selected = true;
                    return;
                }

                if (DgvCarrito.Rows[i].Cells[1].Value == null)
                {
                    DgvCarrito.ClearSelection();
                    MessageBox.Show("Digite la cantidad de producto");
                    DgvCarrito.Rows[i].Cells[1].Selected = true;
                    return;
                }

                if (!Int32.TryParse(DgvCarrito.Rows[i].Cells[1].Value.ToString(), out Cantidad))
                {
                    DgvCarrito.ClearSelection();
                    MessageBox.Show("Digite la cantidad de producto");
                    DgvCarrito.Rows[i].Cells[1].Selected = true;
                    return;
                }

                // Validación TblProductos

                if (DgvTblProductos.Rows[i].Cells[0].Value == null)
                {
                    DgvTblProductos.ClearSelection();
                    MessageBox.Show("Ingrese el nombre del producto en la celda.");
                    DgvTblProductos.Rows[i].Cells[0].Selected = true;
                    return;
                }

                if (DgvTblProductos.Rows[i].Cells[1].Value == null)
                {
                    DgvTblProductos.ClearSelection();
                    MessageBox.Show("Digite el alto del producto en la celda.");
                    DgvTblProductos.Rows[i].Cells[1].Selected = true;
                    return;
                }

                if (!Double.TryParse(DgvTblProductos.Rows[i].Cells[1].Value.ToString(), out Alto))
                {
                    DgvTblProductos.ClearSelection();
                    MessageBox.Show("Digite un valor numérico en la celda.");
                    DgvTblProductos.Rows[i].Cells[1].Selected = true;
                    return;
                }


                if (DgvTblProductos.Rows[i].Cells[2].Value == null)
                {
                    DgvTblProductos.ClearSelection();
                    MessageBox.Show("Digite el ancho del producto en la celda.");
                    DgvTblProductos.Rows[i].Cells[2].Selected = true;
                    return;
                }

                if (!Double.TryParse(DgvTblProductos.Rows[i].Cells[2].Value.ToString(), out Ancho))
                {
                    DgvTblProductos.ClearSelection();
                    MessageBox.Show("Digite un valor numérico en la celda.");
                    DgvTblProductos.Rows[i].Cells[2].Selected = true;
                    return;
                }

                if (DgvTblProductos.Rows[i].Cells[3].Value == null)
                {
                    DgvTblProductos.ClearSelection();
                    MessageBox.Show("Digite el largo del producto en la celda.");
                    DgvTblProductos.Rows[i].Cells[3].Selected = true;
                    return;
                }

                if (!Double.TryParse(DgvTblProductos.Rows[i].Cells[3].Value.ToString(), out Largo))
                {
                    DgvTblProductos.ClearSelection();
                    MessageBox.Show("Digite un valor numérico en la celda.");
                    DgvTblProductos.Rows[i].Cells[3].Selected = true;
                    return;
                }

                if (DgvTblProductos.Rows[i].Cells[4].Value == null)
                {
                    DgvTblProductos.ClearSelection();
                    MessageBox.Show("Digite el peso del producto en la celda.");
                    DgvTblProductos.Rows[i].Cells[4].Selected = true;
                    return;
                }

                if (!Double.TryParse(DgvTblProductos.Rows[i].Cells[4].Value.ToString(), out Peso))
                {
                    DgvTblProductos.ClearSelection();
                    MessageBox.Show("Digite un valor numérico en la celda.");
                    DgvTblProductos.Rows[i].Cells[4].Selected = true;
                    return;
                }

                if (DgvTblProductos.Rows[i].Cells[5].Value == null)
                {
                    DgvTblProductos.ClearSelection();
                    MessageBox.Show("Digite la fragilidad del producto en la celda.");
                    DgvTblProductos.Rows[i].Cells[5].Selected = true;
                    return;
                }

                if (!Int32.TryParse(DgvTblProductos.Rows[i].Cells[5].Value.ToString(), out Fragilidad))
                {
                    DgvTblProductos.ClearSelection();
                    MessageBox.Show("Digite un valor numérico en la celda.");
                    DgvTblProductos.Rows[i].Cells[5].Selected = true;
                    return;
                }

                Producto = DgvCarrito.Rows[i].Cells[0].Value.ToString();
                Cantidad = Convert.ToInt32(DgvCarrito.Rows[i].Cells[1].Value);

                Alto = Convert.ToDouble(GetDatoProducto(Producto, "ColAlto"));
                Ancho = Convert.ToDouble(GetDatoProducto(Producto, "ColAncho"));
                Largo = Convert.ToDouble(GetDatoProducto(Producto, "ColLargo"));
                Peso = Convert.ToDouble(GetDatoProducto(Producto, "ColPeso"));
                Fragilidad = Convert.ToInt32(GetDatoProducto(Producto, "ColFragilidad"));
                BaseTotal = Ancho * Largo;

                // Calcular las dimensiones de la caja

                if (Alto > Ancho && Alto > Largo)
                {
                    AltoTotal = Alto;
                    AnchoTotal += Ancho * Cantidad;
                    Largo += Largo * Cantidad;
                }

                if (Ancho > Alto && Ancho > Largo)
                {
                    AnchoTotal = Ancho;
                    AltoTotal += Alto * Cantidad;
                    LargoTotal += Largo * Cantidad;
                }

                if (Largo > Alto && Largo > Ancho)
                {
                    LargoTotal = Largo;
                    AnchoTotal += Ancho * Cantidad;
                    AltoTotal += Alto * Cantidad;
                }
                else
                {
                    AltoTotal += Alto * Cantidad;
                    AnchoTotal += Ancho * Cantidad;
                    LargoTotal += Largo * Cantidad;
                }

                PesoTotal = PesoTotal + (Cantidad * Peso);

                if (Fragilidad > FragilidadFinal)
                {
                    FragilidadFinal = Fragilidad;
                }
            }

            TbxAlto.Text = AltoTotal.ToString() + "cm";
            TbxAncho.Text = AnchoTotal.ToString() + "cm";
            TbxLargo.Text = LargoTotal.ToString() + "cm";

            TbxPeso.Text = PesoTotal.ToString() + "kg";
            TbxFragilidad.Text = "Nivel " + FragilidadFinal.ToString();
        }

        // ===========================================================================

        // +-------------------------------------------------------------------------+
        // |                               Practica 3                                |
        // +-------------------------------------------------------------------------+

        // +------------------------------------------------------------------+
        // |            Limpia los datos del carrito de compras.              |
        // +------------------------------------------------------------------+
        private void BtnLimpiarDatosCarrito_Click(object sender, EventArgs e)
        {
            DgvCarrito.Rows.Clear();
        }

        // +------------------------------------------------------------------+
        // |             Limpia los datos de la tabla de productos            |
        // +------------------------------------------------------------------+
        private void BtnLimpiarDatosTblProductos_Click(object sender, EventArgs e)
        {
            DgvTblProductos.Rows.Clear();
        }

        // +-------------------------------------------------------------------+
        // |        Llena los datos de prueba de los flujos de efectivo.       | 
        // +-------------------------------------------------------------------+
        private void BtnLlenarP3_Click(object sender, EventArgs e)
        {
            DgvP3FlujosNetos.Rows.Clear();
            for (int i = 0; i < 5; i++)
            {
                DgvP3FlujosNetos.Rows.Add();
                DgvP3FlujosNetos.Rows[i].Cells[0].Value = "Año " + (i + 1);
                DgvP3FlujosNetos.Rows[i].Cells[1].Value = "1000";
            }
        }

        // +------------------------------------------------------------------+
        // |              Calcula el VP para calcular el VPN                  |
        // +------------------------------------------------------------------+
        private double CalcularValorPresente(double[] ValorFuturo,
                                             int Año,
                                             double TasaDescuento)
        {
            double VP;

            VP = 0;
            TasaDescuento = TasaDescuento * 0.01;

            for (int i = 0; i < Año; i++)
            {
                // Calcula el ValorPresente
                VP += (ValorFuturo[i] / Math.Pow((1 + TasaDescuento), (i + 1))); // i + 1 indica el año asociado al FNE
            }

            return VP;
        }

        // +-------------------------------------------------------------------------------------+
        // |   Recibe un string que contiene el valor hexadecimal del color que quieres aplicar  |
        // +-------------------------------------------------------------------------------------+
        private Color ApplyHexColor(string hexColor)
        {
            return ColorTranslator.FromHtml(hexColor);
        }

        // +----------------------------------------------------------------+
        // |   Calcula el valor presente neto de un proyecto de inversión.  |
        // +----------------------------------------------------------------+
        private void BtnVPN_Click(object sender, EventArgs e)
        {
            int i;
            int NoFlujos;
            double InversionInicial;
            double TMAR;
            double[] FlujoEfectivo;
            double VPN;
            double Salida;
            double SalidaTMAR;

            // Validacion de calidad de datos

            if (TbxInversionInicial.Text == "")
            {
                MessageBox.Show("Capture la inversion inicial.");
                TbxInversionInicial.Focus();
                return;
            }

            if (!Double.TryParse(TbxInversionInicial.Text, out Salida))
            {
                MessageBox.Show("Capture un valor numérico.");
                TbxInversionInicial.Focus();
                return;
            }

            if (TbxTMAR.Text == "")
            {
                MessageBox.Show("Capture la tasa mínima aceptable de rendimiento.");
                TbxTMAR.Focus();
                return;
            }

            if (!Double.TryParse(TbxTMAR.Text, out SalidaTMAR))
            {
                MessageBox.Show("Capture un valor numérico");
                TbxTMAR.Focus();
                return;
            }

            if (DgvP3FlujosNetos.Rows.Count == 0)
            {
                MessageBox.Show("Capture los flujos netos de efectivo");
                BtnLlenarP3.Focus();
                return;
            }

            i = 0;
            NoFlujos = DgvP3FlujosNetos.Rows.Count;

            InversionInicial = Convert.ToDouble(TbxInversionInicial.Text);
            TMAR = Convert.ToDouble(TbxTMAR.Text);
            FlujoEfectivo = new double[NoFlujos];

            // Recorre la lista flujos netos de efectivo de cada año.
            while (i < DgvP3FlujosNetos.Rows.Count - 1)
            {

                // Valida calidad de datos

                if (DgvP3FlujosNetos.Rows[i].Cells[1].Value == null)
                {
                    DgvP3FlujosNetos.ClearSelection();
                    MessageBox.Show("Capture un flujo de efectivo en el " + DgvP3FlujosNetos.Rows[i].Cells[0].Value.ToString() + ".");
                    DgvP3FlujosNetos.Rows[i].Cells[1].Selected = true;
                    return;
                }

                // Valida calidad de datos

                if (!Double.TryParse(DgvP3FlujosNetos.Rows[i].Cells[1].Value.ToString(), out Salida))
                {
                    DgvP3FlujosNetos.ClearSelection();
                    MessageBox.Show("Caputure valor numérico en el " + DgvP3FlujosNetos.Rows[i].Cells[0].Value.ToString() + ".");
                    DgvP3FlujosNetos.Rows[i].Cells[1].Selected = true;
                    return;
                }

                // Captura el flujo de efectivo neto

                FlujoEfectivo[i] = Convert.ToDouble(DgvP3FlujosNetos.Rows[i].Cells[1].Value);

                i++;
            }

            // Calcula el valor presente del flujo total

            VPN = CalcularValorPresente(FlujoEfectivo, NoFlujos, TMAR) - InversionInicial;

            // Mostrar VPN final en componente TbxResultado
            TbxResultado.Text = "$" + Math.Round(VPN, 2).ToString();

            // Establecer propiedad ShowColor para TbxDecision

            FontDialog fd = new FontDialog();
            fd.ShowColor = true;

            // Decidir si el proyecto es factible, indiferente, no factible.

            if (VPN > 0)
            {
                TbxResultado.BackColor = ApplyHexColor("#303030");
                TbxResultado.ForeColor = ApplyHexColor("#1ed760");
                TbxDecision.BackColor = ApplyHexColor("#303030");
                TbxDecision.ForeColor = ApplyHexColor("#1ed760");
                TbxDecision.Text = "Factible";
            }

            if (VPN < 0)
            {
                TbxResultado.BackColor = ApplyHexColor("#f8f9fa");
                TbxResultado.ForeColor = ApplyHexColor("#bb2929");
                TbxDecision.BackColor = ApplyHexColor("#f8f9fa");
                TbxDecision.ForeColor = ApplyHexColor("#bb2929"); // Rojo
                TbxDecision.Text = "No factible";
            }

            if (Math.Round(VPN, 2) == 0)
            {
                TbxResultado.BackColor = ApplyHexColor("#454545");
                TbxResultado.ForeColor = ApplyHexColor("#f7df1e");
                TbxDecision.BackColor = ApplyHexColor("#454545");
                TbxDecision.ForeColor = ApplyHexColor("#f7df1e"); // Amarrillo
                TbxDecision.Text = "Indeterminado";
            }
        }

        // ===========================================================================

        // +-------------------------------------------------------------------------+
        // |                               Practica 4                                |
        // +-------------------------------------------------------------------------+


        // +----------------------------------------------------------------+
        // |        Limpia los datos espaciales y el polígono dibujado      |
        // +----------------------------------------------------------------+
        private void BtnP4Limpiar_Click(object sender, EventArgs e)
        {
            DgvP4DatosEspaciales.Rows.Clear();
            CbxP4Terrenos.SelectedIndex = -1;
            TpgPractica4.CreateGraphics().Clear(Color.White);
        }

        // +----------------------------------------------------------------+
        // |        Llena datos de prueba según el terreno seleccionado     |
        // +----------------------------------------------------------------+
        private void CbxP4Terrenos_SelectedIndexChanged(object sender, EventArgs e)
        {
            DgvP4DatosEspaciales.Rows.Clear();

            switch (CbxP4Terrenos.SelectedIndex)
            {
                case 0:
                    DgvP4DatosEspaciales.Rows.Add();
                    DgvP4DatosEspaciales.Rows[0].Cells[0].Value = 1;
                    DgvP4DatosEspaciales.Rows[0].Cells[1].Value = "0";
                    DgvP4DatosEspaciales.Rows[0].Cells[2].Value = "0";

                    DgvP4DatosEspaciales.Rows.Add();
                    DgvP4DatosEspaciales.Rows[1].Cells[0].Value = 2;
                    DgvP4DatosEspaciales.Rows[1].Cells[1].Value = "0";
                    DgvP4DatosEspaciales.Rows[1].Cells[2].Value = "200";

                    DgvP4DatosEspaciales.Rows.Add();
                    DgvP4DatosEspaciales.Rows[2].Cells[0].Value = 3;
                    DgvP4DatosEspaciales.Rows[2].Cells[1].Value = "100";
                    DgvP4DatosEspaciales.Rows[2].Cells[2].Value = "200";

                    DgvP4DatosEspaciales.Rows.Add();
                    DgvP4DatosEspaciales.Rows[3].Cells[0].Value = 4;
                    DgvP4DatosEspaciales.Rows[3].Cells[1].Value = "100";
                    DgvP4DatosEspaciales.Rows[3].Cells[2].Value = "0";

                    break;

                case 1:

                    DgvP4DatosEspaciales.Rows.Add();
                    DgvP4DatosEspaciales.Rows[0].Cells[0].Value = 1;
                    DgvP4DatosEspaciales.Rows[0].Cells[1].Value = "0";
                    DgvP4DatosEspaciales.Rows[0].Cells[2].Value = "0";

                    DgvP4DatosEspaciales.Rows.Add();
                    DgvP4DatosEspaciales.Rows[1].Cells[0].Value = 2;
                    DgvP4DatosEspaciales.Rows[1].Cells[1].Value = "450";
                    DgvP4DatosEspaciales.Rows[1].Cells[2].Value = "600";

                    DgvP4DatosEspaciales.Rows.Add();
                    DgvP4DatosEspaciales.Rows[2].Cells[0].Value = 3;
                    DgvP4DatosEspaciales.Rows[2].Cells[1].Value = "450";
                    DgvP4DatosEspaciales.Rows[2].Cells[2].Value = "600";

                    DgvP4DatosEspaciales.Rows.Add();
                    DgvP4DatosEspaciales.Rows[3].Cells[0].Value = 4;
                    DgvP4DatosEspaciales.Rows[3].Cells[1].Value = "450";
                    DgvP4DatosEspaciales.Rows[3].Cells[2].Value = "0";

                    break;

                case 2:

                    DgvP4DatosEspaciales.Rows.Add();
                    DgvP4DatosEspaciales.Rows[0].Cells[0].Value = 1;
                    DgvP4DatosEspaciales.Rows[0].Cells[1].Value = "0";
                    DgvP4DatosEspaciales.Rows[0].Cells[2].Value = "0";

                    DgvP4DatosEspaciales.Rows.Add();
                    DgvP4DatosEspaciales.Rows[1].Cells[0].Value = 2;
                    DgvP4DatosEspaciales.Rows[1].Cells[1].Value = "20";
                    DgvP4DatosEspaciales.Rows[1].Cells[2].Value = "55";

                    DgvP4DatosEspaciales.Rows.Add();
                    DgvP4DatosEspaciales.Rows[2].Cells[0].Value = 3;
                    DgvP4DatosEspaciales.Rows[2].Cells[1].Value = "10";
                    DgvP4DatosEspaciales.Rows[2].Cells[2].Value = "72";

                    DgvP4DatosEspaciales.Rows.Add();
                    DgvP4DatosEspaciales.Rows[3].Cells[0].Value = 4;
                    DgvP4DatosEspaciales.Rows[3].Cells[1].Value = "60";
                    DgvP4DatosEspaciales.Rows[3].Cells[2].Value = "131";

                    DgvP4DatosEspaciales.Rows.Add();
                    DgvP4DatosEspaciales.Rows[4].Cells[0].Value = 5;
                    DgvP4DatosEspaciales.Rows[4].Cells[1].Value = "180";
                    DgvP4DatosEspaciales.Rows[4].Cells[2].Value = "153";

                    break;

                case 3:
                    break;
            }

            DibujaPoligono(0, 0);


        }

        // +------------------------------------------------------------------+
        // | Dibuja el polígono a partir de los datos de DgvP4DatosEspaciales |
        // +------------------------------------------------------------------+
        private void DibujaPoligono(int XOrigen, int YOrigen)
        {
            // Limpiar 

            //TpgPractica4.CreateGraphics().Clear(Color.White);

            // Declaración de variables

            Point[] Puntos;
            Pen Lapiz;
            Graphics Lienzo;
            Random random;
            Color randomColor;

            // Validacion de datos

            if (DgvP4DatosEspaciales.Rows[0].Cells[0].Value == null)
            {
                return;
            }

            // Creación de puntos :D

            Puntos = new Point[DgvP4DatosEspaciales.Rows.Count];

            for (int i = 0; i < DgvP4DatosEspaciales.Rows.Count - 1; i++)
            {
                Puntos[i].X = Convert.ToInt32(DgvP4DatosEspaciales.Rows[i].Cells[1].Value.ToString()); // + XOrigen
                Puntos[i].Y = Convert.ToInt32(DgvP4DatosEspaciales.Rows[i].Cells[2].Value.ToString()); // + YOrigen
            }

            // Construcción de objetos de dibujo

            random = new Random();

            randomColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));

            Lapiz = new Pen(randomColor, 2);
            Lienzo = TpgPractica4.CreateGraphics();

            Lienzo.SmoothingMode = SmoothingMode.AntiAlias;
            Lienzo.ScaleTransform(1.0f, -1.0f);
            Lienzo.TranslateTransform(XOrigen, -(float)YOrigen);

            // Dibuja el polígono
            Lienzo.DrawPolygon(Lapiz, Puntos);
        }

        // +------------------------------------------------------------------+
        // | Actualiza el polígono utilizando los valores de la tabla.        |
        // +------------------------------------------------------------------+
        private void BtnP4Actualizar_Click(object sender, EventArgs e)
        {
            DibujaPoligono(0, 0);
        }

        // +------------------------------------------------------------------+
        // | Actualiza el polígono utilizando los valores de la tabla.        |
        // +------------------------------------------------------------------+
        private void TpgPractica4_MouseClick(object sender, MouseEventArgs e)
        {
            int X;
            int Y;

            X = e.X;
            Y = e.Y;

            DibujaPoligono(X, Y);

        }

        private void TpgPractica4_MouseMove(object sender, MouseEventArgs e)
        {
            int X;
            int Y;

            X = e.X;
            Y = e.Y;

            DibujaPoligono(X, Y);
        }

        // ===========================================================================

        // +-------------------------------------------------------------------------+
        // |                               Practica 5                                |
        // +-------------------------------------------------------------------------+


        // +-------------------------------------------------------------------------+
        // |                    VARIABLES GLOBLABLES PRACTICA 5                      |
        // +-------------------------------------------------------------------------+

        // Coordendas X,Y obtenidas en BtnP5Cargar
        static List<double> CoordenadasX;
        static List<double> CoordenadasY;

        // Flag para indicar si el archivo a cargar falló

        bool falloAlCargar;

        // Guardar nombre de archivo

        public static string NombreArchivo;

        // Elementos gráficos para dibujar el polígono
        static Graphics ComponentCanvas;
        static Brush poligonoContenido;
        static Brush poligonoPuntos;
        static Pen poligonoContorno;

        // Puntos vectoriales

        static PointF[] PuntosVectoriales;

        // Propiedades del polígono (Color, ancho, escala)

        public static Color Contorno;
        public static Color Area;
        public static Color Puntos;
        public static int ContornoAncho;
        public static int escalaX;
        public static int escalaY;
        public static int cantidadPuntos;

        public static bool pintado;

        // Lienzo y coordendas X,Y de mouse
        static Panel drawingPane;
        int mouseX;
        int mouseY;

        // ================================ FIN ======================================

        // +-------------------------------------------------------------------------+
        // |          Nos ayuda a dibujar el polígono en drawingPane.                |
        // +-------------------------------------------------------------------------+
        public void DibujarPoligono()
        {

            // Inicializar puntos vectoriales

            PuntosVectoriales = new PointF[cantidadPuntos];

            // Introducir datos en PuntosVectoriales

            for (int i = 0; i < cantidadPuntos; i++)
            {
                PuntosVectoriales[i].X = (float)CoordenadasX[i] * escalaX;
                PuntosVectoriales[i].Y = (float)CoordenadasY[i] * escalaY;
            }

            // Inicializar herramientas de dibujo gráficas

            poligonoContenido = new SolidBrush(Area);
            poligonoPuntos = new SolidBrush(Puntos);
            poligonoContorno = new Pen(Contorno, ContornoAncho);

            // Obtener e inicializar contexto gráfico

            ComponentCanvas = drawingPane.CreateGraphics();

            // Establecer propiedades del lienzo

            ComponentCanvas.Clear(ApplyHexColor("#eee"));
            ComponentCanvas.SmoothingMode = SmoothingMode.AntiAlias;
            ComponentCanvas.ScaleTransform(1.0f, -1.0f); // Escala
            ComponentCanvas.TranslateTransform(500.0f, -350.0f); // Constantes sin sentido :D

            // Dibujar polígono

            ComponentCanvas.DrawPolygon(poligonoContorno, PuntosVectoriales);
            ComponentCanvas.FillPolygon(poligonoContenido, PuntosVectoriales);

            // Dibujar puntos vectoriales
            foreach (PointF point in PuntosVectoriales)
            {
                ComponentCanvas.FillEllipse(poligonoPuntos, point.X - 2.0f, point.Y - 2, 6, 6);
            }

            // Dejamos de utilizar las herramientas y cerramos su proceso

            poligonoContenido.Dispose();
            poligonoContorno.Dispose();
            poligonoPuntos.Dispose();
            ComponentCanvas.Save();
            drawingPane.Update();

        }

        // +-------------------------------------------------------------------------+
        // |          Evento que maneja la escala del polígono dibujado.             |
        // +-------------------------------------------------------------------------+
        private void DlgProyecto_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Oemplus &&
                e.Modifiers == Keys.Control &&
                TbcPrincipal.SelectedTab == TbcPrincipal.TabPages["TpgPractica5"]
                && ComponentCanvas != null)
            {

                escalaX++;
                escalaY++;

                DibujarPoligono();

            }

            if (e.KeyCode == Keys.OemMinus &&
                e.Modifiers == Keys.Control &&
                TbcPrincipal.SelectedTab == TbcPrincipal.TabPages["TpgPractica5"]
                && ComponentCanvas != null)
            {

                escalaX--;
                escalaY--;

                DibujarPoligono();

            }

            if (e.KeyCode == Keys.G &&
                e.Modifiers == Keys.Control &&
                TbcPrincipal.SelectedTab == TbcPrincipal.TabPages["TpgPractica5"] &&
                ComponentCanvas != null)
            {
                GuardarImagen();
            }

        }

        // +-------------------------------------------------------------------------+
        // |    Calcula el centro del componente dado como parametro.                |
        // +-------------------------------------------------------------------------+
        private Point calcularCentro(Panel panel)
        {
            return new Point(
                (PnlP5Lienzo.Width - panel.Width) / 2,
                (PnlP5Lienzo.Height - panel.Height) / 2
            );
        }

        // +-------------------------------------------------------------------------+
        // | Inicializa el contexto gráfico y acomoda el lienzo en runtime.          |
        // +-------------------------------------------------------------------------+
        private void iniciarLienzo()
        {

            // Comprobar si el componente ya existe, y lo elimina

            if (PnlP5Lienzo.Controls.Count > 0)
            {
                PnlP5Lienzo.Controls.Clear();
            }

            // Asignación
            drawingPane = new Panel();

            // Propiedades 

            drawingPane.BackColor = ApplyHexColor("#eee");
            drawingPane.Size = new Size(PnlP5Lienzo.Width, PnlP5Lienzo.Height); // Hacer que sea ajustable   
            drawingPane.Location = calcularCentro(drawingPane);
            drawingPane.AutoScroll = true;

            // Evento

            drawingPane.MouseDown += DrawingPaneMouse_Down;
            drawingPane.MouseMove += DrawingPaneMouse_Move;

            // Añadir componente y actualizar vista
            PnlP5Lienzo.Controls.Add(drawingPane);
            PnlP5Lienzo.Update();
        }

        // +-------------------------------------------------------------------------+
        // |        Calcula la nueva posicion del panel tomando en cuenta            |
        // |        valores del evento, y, X,Y del evento Mouse Down.                |
        // +-------------------------------------------------------------------------+
        private void DrawingPaneMouse_Move(Object sender, MouseEventArgs e)
        {
            // Comprobar si el clic izquierdo es utilizado

            if (e.Button == MouseButtons.Left)
            {
                // Modificar posicion en pantalla
                drawingPane.Location = new Point(
                    e.X + drawingPane.Left - mouseX,
                    e.Y + drawingPane.Top - mouseY
                );
                drawingPane.Update();
            }

        }

        // +-------------------------------------------------------------------------+
        // |              Actualiza las coordenadas X,Y del panel.                   |
        // +-------------------------------------------------------------------------+
        private void DrawingPaneMouse_Down(Object sender, MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;
        }

        public void CargarDatosDesdeArchivo(string fileName)
        {

            StreamReader Reader;
            String ReaderLine;
            String[] ReaderValues;

            Reader = null;

            try
            {
                Reader = new StreamReader(fileName);
            }
            catch (Exception)
            {
                MessageBox.Show("El archivo se encuentra en uso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                falloAlCargar = true;
                return;
            }

            while (!Reader.EndOfStream)
            {
                // Leer lineas del archivo y dividir por ,

                ReaderLine = Reader.ReadLine();
                ReaderValues = ReaderLine.Split(",");

                // Almacenar datos en las listas declaradas

                try
                {
                    CoordenadasX.Add(Double.Parse(ReaderValues[0]));
                    CoordenadasY.Add(Double.Parse(ReaderValues[1]));
                }
                catch (Exception)
                {
                    MessageBox.Show("Intente con otro archivo, formato incorrecto o corrupto", "Error al abrir el archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Iterar atraves de las listas y mostrarlo en el datagridview

                for (int i = 0; i < CoordenadasX.Count; i++)
                {
                    DgvP5DatosEspaciales.Rows.Add();
                    DgvP5DatosEspaciales.Rows[i].Cells[0].Value = i + 1;
                    DgvP5DatosEspaciales.Rows[i].Cells[1].Value = CoordenadasX[i];
                    DgvP5DatosEspaciales.Rows[i].Cells[2].Value = CoordenadasY[i];
                }


            }

            // Cargaron los datos correctamente

            falloAlCargar = false;

            cantidadPuntos = CoordenadasX.Count;

            // Cerrar el lector de archivo

            Reader.Close();
        }

        // +-------------------------------------------------------------------------+
        // | Abre un diálogo para obtener los puntos vectoriales desde un csv.       |
        // +-------------------------------------------------------------------------+
        private void BtnP5Cargar_Click(object sender, EventArgs e)
        {

            // Limpiar Datagridview

            DgvP5DatosEspaciales.Rows.Clear();

            // Declaración variables

            OpenFileDialog FileDialog;
            DialogResult FileDialogResult;


            // Asignación 

            FileDialog = new OpenFileDialog();
            CoordenadasX = new List<double>();
            CoordenadasY = new List<double>();

            // Propiedades

            FileDialog.Title = "Buscar y abrir archivo";
            FileDialog.InitialDirectory = $"C:\\{Environment.UserName}";
            FileDialog.Filter = "Archivos CSV (*.csv)|*.csv";
            FileDialog.RestoreDirectory = true;

            // Abrir diálogo de archivos.

            FileDialogResult = FileDialog.ShowDialog();

            // Validar resultados

            if (FileDialogResult == DialogResult.Cancel
                || FileDialogResult == DialogResult.No
                || FileDialogResult == DialogResult.Abort)
            {
                return;
            }

            // Obtener datos desde archivo CSV

            if (FileDialogResult == DialogResult.OK)
            {

                iniciarLienzo();

                CargarDatosDesdeArchivo(FileDialog.FileName);

                DlgPropiedades propiedades = new DlgPropiedades();

                if (!falloAlCargar)
                {
                    propiedades.ShowDialog();
                    DibujarPoligono();
                }

            }
        }

        // +-------------------------------------------------------------------------+
        // |          Permite limpiar el lienzo y reiniciar la vista.                |
        // +-------------------------------------------------------------------------+
        private void BtnP5Limpiar_Click(object sender, EventArgs e)
        {
            // Validar si el polígono ha sido dibujado

            if (ComponentCanvas != null)
            {
                // Borrar gráficos dibujados
                drawingPane.CreateGraphics().Clear(Color.Transparent);
                // Actualizar vista
                drawingPane.Update();
            }

        }

        // +-------------------------------------------------------------------------+
        // | Abre un diálogo a otra ventana donde puedes modificar colores del       |
        // | polígono a dibujar, además del grosor.                                  |
        // +-------------------------------------------------------------------------+
        private void BtnP5Propiedades_Click(object sender, EventArgs e)
        {
            // Instancia
            DlgPropiedades dlgPropiedades = new DlgPropiedades();

            if (ComponentCanvas == null)
            {
                MessageBox.Show("Cargue los datos vectoriales primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Mostrar dialogo si y solo si el component canvas no es nulo
            dlgPropiedades.ShowDialog();
        }

        // +-------------------------------------------------------------------------+
        // |          Guardar el polígono dibujado como imagen (png | jpg).          |
        // +-------------------------------------------------------------------------+
        private void BtnP5Guardar_Click(object sender, EventArgs e)
        {
            GuardarImagen();
        }

        private void GuardarImagen()
        {
            // Definición variables

            SaveFileDialog saveFileDialog;
            DialogResult Resultado;
            Graphics fileCanvas;
            Bitmap lienzoVirtual;
            string formatoImagen;
            string ArchivoGuardado;
            string NombreArchivo;
            int AnchoImagen;
            int AltoImagen;


            AnchoImagen = 0;
            AltoImagen = 0;
            ArchivoGuardado = String.Empty;
            NombreArchivo = String.Empty;

            // Validación polígono pintado 

            if (ComponentCanvas == null)
            {
                MessageBox.Show("Cargue los datos vectoriales primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validación alto y ancho imagen

            if (TxtP5Alto.Text.Equals(""))
            {
                TxtP5Alto.Focus();
                return;
            }

            if (TxtP5Alto.Text.Equals(""))
            {
                TxtP5Alto.Focus();
                return;
            }

            try
            {
                AnchoImagen = Int32.Parse(TxtP5Alto.Text);
                AltoImagen = Int32.Parse(TxtP5Ancho.Text);

                // Comprobar limite de resolución

                if (AnchoImagen == 0 ||
                    AnchoImagen < 0)
                {
                    AnchoImagen = 500;
                }

                if (AltoImagen == 0 ||
                    AnchoImagen < 0)
                {
                    AltoImagen = 500;
                }

                if (AnchoImagen < 500)
                {
                    AnchoImagen = 500;
                }

                if (AltoImagen < 500)
                {
                    AnchoImagen = 500;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Introduce valores validos", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Inicialización - asignación

            saveFileDialog = new SaveFileDialog();
            lienzoVirtual = new Bitmap(AnchoImagen, AltoImagen, PixelFormat.Format48bppRgb);
            formatoImagen = CbxFormatoImagen.Text.ToUpper();

            poligonoContorno = new Pen(Contorno);
            poligonoContenido = new SolidBrush(Area);
            poligonoPuntos = new SolidBrush(Puntos);

            // Propiedades del canvas
            fileCanvas = Graphics.FromImage(lienzoVirtual);
            fileCanvas.SmoothingMode = SmoothingMode.HighQuality;
            fileCanvas.ScaleTransform(1.0f, -1.0f);
            fileCanvas.TranslateTransform(100.0f, -300.0f);

            // Propiedades del save file dialog

            saveFileDialog.Title = "Guardar imagen de polígono";

            if (formatoImagen == "PNG")
            {
                saveFileDialog.Filter = "Png Image(.png)|*.png";
            }
            else if (formatoImagen == "JPG")
            {
                saveFileDialog.Filter = "JPEG Image(.jpeg)|*.jpeg";
            }
            saveFileDialog.RestoreDirectory = true;

            // Dibujar polígono 

            fileCanvas.DrawPolygon(poligonoContorno, PuntosVectoriales);
            fileCanvas.FillPolygon(poligonoContenido, PuntosVectoriales);

            // Dibujar puntos vectoriales
            foreach (PointF point in PuntosVectoriales)
            {
                fileCanvas.FillEllipse(poligonoPuntos, point.X - 2, point.Y - 2, 2 * escalaX, 2 * escalaY);
            }

            lienzoVirtual.MakeTransparent();

            Resultado = saveFileDialog.ShowDialog();

            // Validar dialogo de guardado

            if (Resultado == DialogResult.No ||
                Resultado == DialogResult.Abort ||
                Resultado == DialogResult.Cancel)
            {
                return;
            }

            if (Resultado == DialogResult.OK)
            {
                // Guardar imagen

                ArchivoGuardado = saveFileDialog.FileName;
                NombreArchivo = Path.GetFileName(saveFileDialog.FileName);

                switch (formatoImagen)
                {
                    case "PNG":
                        lienzoVirtual.Save(ArchivoGuardado, ImageFormat.Png);

                        break;
                    case "JPG":
                        lienzoVirtual.Save(ArchivoGuardado, ImageFormat.Jpeg);
                        break;
                }

            }

            MessageBox.Show("Imagen guardada satisfactoriamente!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Abrir imagen en visualizador de imagenes

            Process Visualizador;

            Visualizador = new Process();

            Visualizador.StartInfo.FileName = @"explorer.exe"; // Por alguna extraña razon esto abre el visualizador de fotos >:D
            Visualizador.StartInfo.Arguments = NombreArchivo;

            Visualizador.Start();
        }

        // +-------------------------------------------------------------------------+
        // |                          Redibujar polígono.                            |
        // +-------------------------------------------------------------------------+
        private void PnlP5Lienzo_Resize(object sender, EventArgs e)
        {

            // Validar si el component canvas esta inicializado y re dibujar el polígono

            if (ComponentCanvas != null)
            {
                drawingPane.Location = calcularCentro(drawingPane);
                DibujarPoligono();
            }

        }

        #region PRACTICA 6

        // +-------------------------------------------------------------------------+
        // | Obtiene coordenadas geograficas de un lugar a partir de los servicios   |
        // | De Google Maps.                                                         |
        // +-------------------------------------------------------------------------+
        private async void BtnObtenerCoordenadas_Click(object sender, EventArgs e)
        {
            // Validación

            if (TxtLugar.Text.Equals(""))
            {
                return;
            }

            RtbxContenidoKML.Clear();

            // Obtiene coordenadas del API de google maps.
            await GetCoordenadas();

        }

        // +-------------------------------------------------------------------------+
        // |       Carga el archivo .env que contiene la API_KEY de google maps      |
        // +-------------------------------------------------------------------------+

        private void LoadEnv()
        {
            string ENV_PATH = Directory.GetCurrentDirectory() + "\\.env";

            foreach (var line in File.ReadAllLines(ENV_PATH))
            {
                var parts = line.Split('=', StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length != 2)
                {
                    continue;
                }

                Environment.SetEnvironmentVariable(parts[0], parts[1]);

            }

        }

        // +-------------------------------------------------------------------------+
        // | Obtiene coordenadas geograficas de un lugar a partir de los servicios   |
        // | De Google Maps.                                                         |
        // +-------------------------------------------------------------------------+
        public async Task GetCoordenadas()
        {
            // Declaración de variables
            HttpClient clienteHttp;
            Uri direccion;
            HttpResponseMessage respuestaHttp;
            XmlDocument documentoXML;
            XmlNodeList elemList;
            XmlElement bookElement;
            string contenidoHttp;
            string Llave;
            string Lugar;
            string Descripcion;
            string Longitud;
            string Latitud;
            string Status;

            // Prepara datos de trabajo
            Llave = Environment.GetEnvironmentVariable("GM_KEY");
            Lugar = TxtLugar.Text;

            // Consulta la API de geolocalización de google maps.
            clienteHttp = new HttpClient();
            direccion = new Uri("https://maps.googleapis.com/maps/api/geocode/");
            clienteHttp.BaseAddress = direccion;

            respuestaHttp = await clienteHttp.GetAsync("xml?address=" + Lugar + "&key=" + Llave);
            contenidoHttp = await respuestaHttp.Content.ReadAsStringAsync();

            // Extrae el Descripción, la latitud y la longitud del XML

            documentoXML = new XmlDocument();
            documentoXML.LoadXml(contenidoHttp);

            elemList = documentoXML.GetElementsByTagName("status");
            bookElement = (XmlElement)elemList[0];
            Status = bookElement.InnerText;

            if (Status == "ZERO_RESULTS")
            {
                TxtDescripcion.Text = "Lugar no encontrado.";
                TxtLatitud.Text = "Lugar no encontrado.";
                TxtLongitud.Text = "Lugar no encontrado.";
                return;
            }

            elemList = documentoXML.GetElementsByTagName("formatted_address");
            bookElement = (XmlElement)elemList[0];
            Descripcion = bookElement.InnerText;

            elemList = documentoXML.GetElementsByTagName("location");
            bookElement = (XmlElement)elemList[0];
            Latitud = bookElement["lat"].InnerText;
            Longitud = bookElement["lng"].InnerText;

            //MessageBox.Show(Descripcion);
            //MessageBox.Show(Latitud);
            //MessageBox.Show(Longitud);

            TxtDescripcion.Text = Descripcion;
            TxtLatitud.Text = Latitud;
            TxtLongitud.Text = Longitud;

            // MessageBox.Show(contenidoHttp);

        }

        // +--------------------------------------------------------------------------+
        // | Genera un archivo de texto en formato KML con las coordenadas calculadas |
        // +--------------------------------------------------------------------------+
        private void BtnGenerarKML_Click(object sender, EventArgs e)
        {
            // Variables
            string Ruta;
            string Nombre;
            string Contenido;
            bool Exito;

            // Inicializa datos de 
            Ruta = @"C:\Users\Jorge\Desktop\";
            Nombre = $"{TxtLugar.Text}.KML";

            Contenido =
                "<?xml version = \"1.0\" encoding = \"UTF-8\" ?>\n" +
                "<kml xmlns = \"http://www.opengis.net/kml/2.2\" >\n" +
                "  <Placemark>\n" +
                "    <name>\n" +
                "     " + TxtLugar.Text + "\n" +
                "    </name>\n" +
                "    <description>\n" +
                "     " + TxtDescripcion.Text + "\n" +
                "    </description>\n" +
                "    <Point>\n" +
                "      <coordinates>\n" +
                "       " + TxtLongitud.Text + "," + TxtLatitud.Text + "," + "0\n" +
                "      </coordinates>\n" +
                "   </Point>\n" +
                " </Placemark>\n" +
                "</kml>\n";


            // Crea el archivo de texto con formato KML

            try
            {
                using (StreamWriter Escritor = File.CreateText(Ruta + Nombre))
                {
                    Escritor.WriteLine(Contenido);
                }

                Exito = true;
            }
            catch (Exception)
            {
                Exito = false;
            }

            // Maneja el posible error

            if (Exito)
            {
                RtbxContenidoKML.Clear();
                RtbxContenidoKML.Text = Contenido;
                MessageBox.Show("El archivo ha KML se generó con éxito");
            }
            else
            {
                MessageBox.Show("Ocurrió un error al intentar generar el archivo");
            }

        }

        #endregion

        #region PRACTICA 7

        private async void BtnBuscarLugares_ClickAsync(object sender, EventArgs e)
        {
            // Validación

            if (CbxP7Lugares.SelectedIndex == -1)
            {
                return;
            }

            RtbxContenidoKML.Clear();

            // Obtiene coordenadas del API de google maps.
            await GetLugares();
        }


        public async Task GetLugares()
        {
            // Declaración de variables
            HttpClient clienteHttp;
            Uri direccion;
            HttpResponseMessage respuestaHttp;
            XmlDocument documentoXML;
            XmlNodeList elemList;
            XmlElement bookElement;
            string contenidoHttp;
            string Llave;
            string Nombre;
            string Domicilio;
            string Buscar;
            string Longitud;
            string Latitud;
            int Radio;

            // Inicializar datos de trabajo
            Llave = Environment.GetEnvironmentVariable("GM_KEY");
            Latitud = TxtP7Latitud.Text;
            Longitud = TxtP7Longitud.Text;
            Buscar = CbxP7Lugares.Text;
            Radio = Int32.Parse(TxtP7Radio.Text);

            // Consulta la api de geolocalización

            // Consulta la API de geolocalización de google maps.
            clienteHttp = new HttpClient();
            direccion = new Uri("https://maps.googleapis.com/maps/api/place/nearbysearch/");
            clienteHttp.BaseAddress = direccion;

            respuestaHttp = await clienteHttp.GetAsync("xml?location=" + Latitud + "," + Longitud + "&radius=" + Radio + "&type=" + Buscar + "&key=" + Llave);
            contenidoHttp = await respuestaHttp.Content.ReadAsStringAsync();

            // Obtiene y muestra la lista de lugares

            documentoXML = new XmlDocument();
            documentoXML.LoadXml(contenidoHttp);

            elemList = documentoXML.GetElementsByTagName("result");

            MessageBox.Show("Se encontraron " + elemList.Count + " lugares a " + Radio + " Metros a la redonda.");
            DgvP7Datos.Rows.Clear();

            for (int i = 0; i < elemList.Count; i++)
            {
                bookElement = (XmlElement)elemList[i];
                Nombre = bookElement["name"].InnerText;
                Domicilio = bookElement["vicinity"].InnerText;
                Latitud = bookElement["geometry"].ChildNodes[0].ChildNodes[0].InnerText;
                Longitud = bookElement["geometry"].ChildNodes[0].ChildNodes[1].InnerText; ;

                // Agregar datos al datagridview
                DgvP7Datos.Rows.Add();
                DgvP7Datos.Rows[i].Cells[0].Value = i + 1; // Indice
                DgvP7Datos.Rows[i].Cells[1].Value = Nombre;
                DgvP7Datos.Rows[i].Cells[2].Value = Domicilio;
                DgvP7Datos.Rows[i].Cells[3].Value = Latitud;  // lat
                DgvP7Datos.Rows[i].Cells[4].Value = Longitud; // lng

            }

        }

        // +-------------------------------------------------------------------------+
        // |                       Copia coordenadas de origen                       |
        // +-------------------------------------------------------------------------+
        private void BtnP7Coordenadas_Click(object sender, EventArgs e)
        {
            TxtP7Latitud.Text = TxtLatitud.Text;
            TxtP7Longitud.Text = TxtLongitud.Text;
        }

        #endregion
        
        #region PRACTICA 8

        // +--------------------------------------------------------------------------+
        // |                    Convertir grados decimales a radianes                 |
        // +--------------------------------------------------------------------------+
        private float EnRadianes(float GradosDecimales)
        {
            return (float)(Math.PI / 180) * GradosDecimales; 
        }

        // +--------------------------------------------------------------------------+
        // |   Calcula la distancia entre dos coordenaadas con base en la formula     |
        // |   de semiverseno                                                         |
        // +--------------------------------------------------------------------------+
        private float CalcularDistancia(float PosOrigenLatitud,
                                        float PosDestinoLatitud,
                                        float PosOrigenLongitud,
                                        float PosDestinoLongitud)
        {
            var DifLatitud = EnRadianes(PosDestinoLatitud - PosOrigenLatitud);
            var DifLongitud = EnRadianes(PosDestinoLongitud - PosOrigenLongitud);

            var a = Math.Pow(Math.Sin(DifLatitud / 2), 2) +
                Math.Cos(EnRadianes(PosOrigenLatitud)) *
                Math.Cos(EnRadianes(PosDestinoLatitud)) *
                Math.Pow(Math.Sin(DifLongitud / 2), 2);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return 6378.0F * Convert.ToSingle(c);

        }


        private void BtnCalcularP8_Click(object sender, EventArgs e)
        {
            // Declaración de variables
            float PosOrigenLatitud;
            float PosOrigenLongitud;
            float PosDestinoLatitud;
            float PosDestinoLongitud;

            float Resultado;

            // Inicialización de datos de trabajo
            PosOrigenLatitud = (float)Convert.ToDouble(TxtLatitudOrigen.Text);
            PosOrigenLongitud = (float)Convert.ToDouble(TxtLongitudOrigen.Text);
            PosDestinoLatitud = (float)Convert.ToDouble(TxtLatitudDestino.Text);
            PosDestinoLongitud = (float)Convert.ToDouble(TxtLongitudDestino.Text);

            // Calcula la distancia en kilómetros
            Resultado = CalcularDistancia(PosOrigenLatitud,
                                          PosDestinoLatitud,
                                          PosOrigenLongitud,
                                          PosDestinoLongitud);

            // Mostrar Resultado

            TxtResultadoP8.Text = Resultado.ToString() + "Kms";
        }

        // +-------------------------------------------------------------------------+
        // |                       Copia coordenadas de origen                       |
        // +-------------------------------------------------------------------------+
        private void BtnCopiarCOrigen_Click(object sender, EventArgs e)
        {
            TxtLatitudOrigen.Text = TxtLatitud.Text;
            TxtLongitudOrigen.Text = TxtLongitud.Text;
            TxtLugarOrigen.Text = TxtLugar.Text;
        }

        // +-------------------------------------------------------------------------+
        // |                        Copia coordenadas de destino                     |
        // +-------------------------------------------------------------------------+
        private void BtnCopiarCDestino_Click(object sender, EventArgs e)
        {
            TxtLatitudDestino.Text = TxtLatitud.Text;
            TxtLongitudDestino.Text = TxtLongitud.Text;
            TxtLugarDestino.Text = TxtLugar.Text;
        }

        #endregion

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            ResizeImage program = new ResizeImage();
            program.ShowDialog();
        }

        #endregion

        // ===========================================================================

    }
}
