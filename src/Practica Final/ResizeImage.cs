using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        bool IsAspectRatio;
        private int ImageWidth;
        private int ImageHeight;
        private int QuantityOfImages;
        private string[] FileNames;
        private string ImageFormat;

        private OpenFileDialog OpenDialog;
        private SaveFileDialog SaveDialog;
        private DialogResult Result;


        private async void SelectImages()
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

                for (int i = 0; i < QuantityOfImages; i++)
                {
                    FileNames[i] = OpenDialog.FileNames[i];
                }

            }

            LblQuantity.Text += $" {QuantityOfImages}";

            await ImagePreview();
        }

        private Task ImagePreview()
        {

            FlpImages.Controls.Clear();

            PictureBox SelectedImage;

            for (int i = 0; i < QuantityOfImages; i++)
            {
                SelectedImage = new PictureBox();
                SelectedImage.Size = new Size(400, 300);
                SelectedImage.BackColor = Color.Black;
                SelectedImage.BackgroundImage = Image.FromFile(FileNames[i]);
                SelectedImage.BackgroundImageLayout = ImageLayout.Stretch;
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

        private void ValidateInput()
        {

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

            IsAspectRatio = CbxAspectRatio.Checked;
            ImageWidth = Int32.Parse(TxtWidth.Text);
            ImageHeight = Int32.Parse(TxtHeight.Text);
            ImageFormat = CbxFormat.Text.ToLower();

            SelectImages();
            
        }

        private async void BtnSelectImages_Click(object sender, EventArgs e)
        {
            ResetUi();
            ValidateInput();    
        }

        private void Validation_KeyPress(object sender, KeyPressEventArgs e)
        {

            TextBox Field = sender as TextBox;

            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && 
                (Field.Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            if (Field.Text.Length > 4)
            {
                e.Handled = true;
            }


        }
    }
}
