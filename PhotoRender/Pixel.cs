using System.Runtime.InteropServices;
using System.Windows.Media;

namespace PhotoRender
{
    public class Pixel
    {
        public Pixel(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }

        public Pixel(System.Drawing.Color color)
        {
            R = color.R;
            G = color.G;
            B = color.B;
        }

        /*public Pixel(System.Drawing.Color color)
        {
            Color = color;
        }*/

        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }
        //public System.Drawing.Color Color { get; }

        public double GetShadeOfGray()
        {
            return (0.299 * R + 0.587 * G + 0.114 * B) / 255;
        }

        public override string ToString()
        {
            return $"Pixel({R}, {G}, {B})";
        }
    }
}
