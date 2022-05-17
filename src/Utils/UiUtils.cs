using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PE22A_JAMZ.src.Utils
{
    internal class UiUtils
    {
        public static Color GetColor(string hex)
        {
            return ColorTranslator.FromHtml(hex);
        }

        public static void PaintBorder(object sender, EventArgs e)
        {

            // Propiedades del borde
            Color BorderColor = GetColor("#06f");
            int BorderSize = 4;
            ButtonBorderStyle BorderStyle = ButtonBorderStyle.Solid;

            // Obtener componente
            PictureBox component = sender as PictureBox;
            // Crear un rectángulo
            Rectangle componentRec = new Rectangle(new Point(0, 0), component.Size);
            // Dibujar el borde con los gráficos
            ControlPaint.DrawBorder(component.CreateGraphics(),
                                    componentRec,
                                    BorderColor,
                                    BorderSize,
                                    BorderStyle,
                                    BorderColor,
                                    BorderSize,
                                    BorderStyle,
                                    BorderColor,
                                    BorderSize,
                                    BorderStyle,
                                    BorderColor,
                                    BorderSize,
                                    BorderStyle);
            
            component.Update();
        }

        public static void RemoveBorder(object sender, EventArgs e)
        {
            PictureBox component = sender as PictureBox;
            Rectangle componentRec = new Rectangle(new Point(0, 0), component.Size);
            ControlPaint.DrawBorder(component.CreateGraphics(), componentRec, GetColor("#fff"), ButtonBorderStyle.None);
            component.Refresh();
        }

        public static void StyleContainer(string BgColor, string FgColor ,Panel container)
        {
            container.BackColor = GetColor(BgColor);
            container.ForeColor = GetColor(FgColor);

            foreach(Control UiElement in container.Controls)
            {

                if (UiElement is TextBox)
                {

                    UiElement.BackColor = GetColor(BgColor);
                    UiElement.ForeColor = GetColor(FgColor);

                }

                if (UiElement is ComboBox)
                {
                    UiElement.BackColor = GetColor(BgColor);
                    UiElement.ForeColor = GetColor(FgColor);
                }

                if (UiElement is RichTextBox)
                {
                    UiElement.BackColor = GetColor(BgColor);
                    UiElement.ForeColor = GetColor(FgColor);
                }

            }

        } 

        public static void StyleLabel(string BgColor, string FgColor, Label label)
        {
            label.BackColor = GetColor(BgColor);
            label.ForeColor = GetColor(FgColor);
        }

        public static void DrawItem(object sender, DrawItemEventArgs e, int SelectedTheme)
        {

            ComboBox comboBox = sender as ComboBox;

            int Index = e.Index;

            Brush ItemBrush;

            ItemBrush = new SolidBrush(Color.Black); // Fallback

            if (SelectedTheme == 0) ItemBrush = new SolidBrush(Color.White);
            if (SelectedTheme == 1) ItemBrush = new SolidBrush(Color.Black);

            e.DrawBackground();
            
            if (Index > -1 )
            {
                e.Graphics.DrawString(comboBox.Items[Index].ToString(),
                                  e.Font,
                                  ItemBrush,
                                  e.Bounds,
                                  StringFormat.GenericDefault);
            }

        }

    }
}
