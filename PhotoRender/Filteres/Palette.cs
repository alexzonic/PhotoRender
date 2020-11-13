using System;
using System.Drawing;
using System.Windows.Controls;

namespace PhotoRender.Filteres
{
    public class Palette
    {
        private static  int red;
        private static  int green;
        private static int blue;
        public static uint[,] Pixels { get; set; }
        public static Bitmap BmpImage { get; set; }
        public static System.Windows.Controls.Image FilteredImage { get; set; }

        protected static int Red
        {
            get => red;
            set => red = GetTrueValue(value);
        }

        protected static int Green
        {
            get => green;
            set => green = GetTrueValue(value);
        }

        protected static int Blue
        {
            get => blue;
            set => blue = GetTrueValue(value);
        }

        protected static void ChangePixelsColor(Slider slider, Func<uint, int, int, uint> change)
        {
            for (var y = 0; y < BmpImage.Height; y++)
            {
                for (var x = 0; x < BmpImage.Width; x++)
                {
                    var point = change(Pixels[y, x], (int) slider.Value, (int) slider.Maximum);
                    BmpImage.SetPixel(x, y, Color.FromArgb((int)point));
                }
            }
        }
        
        private static int GetTrueValue(int color)
        {
            if (color < 0) return 0;
            if (color > 255) return 255;
            return color;
        }
        
        public static uint[,] BitmapPixels(Bitmap bitmap)
        {
            var array = new uint[bitmap.Height, bitmap.Width];
            for (var y = 0; y < bitmap.Height; y++)
            {
                for (var x = 0; x < bitmap.Width; x++)
                    array[y, x] = (uint) (bitmap.GetPixel(x, y).ToArgb());
            }
            return array;
        }
    }
}
