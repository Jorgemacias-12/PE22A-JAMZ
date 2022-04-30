using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PE22A_JAMZ
{
    // --------------------------------------------------------------------
    // Clase del dialogo principal de la aplicación
    // --------------------------------------------------------------------
    public partial class DlgPrincipal : Form
    {
        // --------------------------------------------------------------------
        // Constructor
        // --------------------------------------------------------------------
        public DlgPrincipal()
        {
            InitializeComponent();
        }

        // --------------------------------------------------------------------
        // Hola mundo
        // --------------------------------------------------------------------

        private void BtnSaludo_Click(object sender, EventArgs e)
        {

            string NombreUsuario;
            string Sexo;

            NombreUsuario = TxtNombre.Text;
            Sexo = CbxSexo.Text.ToLower();

            MessageBox.Show("Hola mundo. Soy " + NombreUsuario + ", mi genero es " + Sexo + " y este es mi primer programa en lenguaje C#");
        }

        // --------------------------------------------------------------------
        // Llena los datos de prueba en el grid.
        // --------------------------------------------------------------------
        private void BtnLlenar_Click(object sender, EventArgs e)
        {
            DgvCarrito.Rows.Clear();
            for (int i = 0; i < 4; i++)
            {
                DgvCarrito.Rows.Add();
                DgvCarrito.Rows[i].Cells[0].Value = i + 1; // No items
                DgvCarrito.Rows[i].Cells[1].Value = "Producto " + (i + 1);
                DgvCarrito.Rows[i].Cells[2].Value = "1"; // Cantidad
                DgvCarrito.Rows[i].Cells[3].Value = "2"; // Peso
                DgvCarrito.Rows[i].Cells[4].Value = 1; // Fragilidad Column
            }
        }

        // --------------------------------------------------------------------
        // Calcula la paquetería de envio
        // --------------------------------------------------------------------
        private void BtnCalcularEnvio_Click(object sender, EventArgs e)
        {

            double PesoTotal;
            int NumItems;
            int FragilidadFinal;
            int i;

            PesoTotal = 0;
            NumItems = DgvCarrito.Rows.Count - 1;
            FragilidadFinal = 0;
            i = 0;

            while (i < NumItems)
            {
                int Cantidad;
                int FragilidadItem;
                double PesoUnitario;

                Cantidad = Convert.ToInt32(DgvCarrito.Rows[i].Cells[2].Value);
                PesoUnitario = Convert.ToDouble(DgvCarrito.Rows[i].Cells[3].Value);
                FragilidadItem = Convert.ToInt32(DgvCarrito.Rows[i].Cells[4].Value);

                PesoTotal = PesoTotal + (Cantidad * PesoUnitario);

                if (FragilidadItem > FragilidadFinal)
                {
                    FragilidadFinal = FragilidadItem;
                }

                i++;

            }
            TxtPeso.Text = "El peso total es de " + PesoTotal.ToString() + "kg";
            TxtFragilidad.Text = "La fragilidad final es: " + FragilidadFinal.ToString() + ".";
        }

        // --------------------------------------------------------------------
        // Limpia los datos de la venta.
        // --------------------------------------------------------------------
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            DgvCarrito.Rows.Clear();
            TxtFragilidad.Text = "";
            TxtPeso.Text = "";
        }

        // --------------------------------------------------------------------
        // Abre el dialogo del proyecto.
        // --------------------------------------------------------------------
        private void BtnDialogoProyecto_Click(object sender, EventArgs e)
        {
            DlgProyecto Ventana; 
            
            Ventana = new DlgProyecto();

            Ventana.ShowDialog();
            
        }
    }
}
