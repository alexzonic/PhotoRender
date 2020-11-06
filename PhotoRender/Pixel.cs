using System;
using System.Drawing;
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

        public Pixel(Color color)
        {
            R = color.R;
            G = color.G;
            B = color.B;
        }

        public byte R { get; }
        public byte G { get; }
        public byte B { get; }

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
