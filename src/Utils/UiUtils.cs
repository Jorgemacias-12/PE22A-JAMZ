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
            Color BorderColor = GetColor("#2667FF");
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
        }

        public static void RemoveBorder(object sender, EventArgs e)
        {
            PictureBox component = sender as PictureBox;
            Rectangle componentRec = new Rectangle(new Point(0, 0), component.Size);
            ControlPaint.DrawBorder(component.CreateGraphics(), componentRec, GetColor("#fff"), ButtonBorderStyle.None);
            component.Refresh();
        }

    }
}
