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

        bool IsAspectRatioEnabled;
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

            IsAspectRatioEnabled = CbxAspectRatio.Checked;
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

        private void CalculateAspecRatio(string Target)
        {

            if (!IsAspectRatioEnabled) return;

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
                    
                    Ratio = 16.0f / 9.0f;
                    Height = Double.Parse(TxtHeight.Text);

                    NewWidth = (int)Math.Round(Ratio * Height, 1);

                    TxtWidth.Text = NewWidth.ToString();

                    break;
                case "height":
                    
                    Ratio = 9.0f / 16.0f;
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
    }
}
