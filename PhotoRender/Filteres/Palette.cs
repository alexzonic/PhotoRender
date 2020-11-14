using System;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Media;
using Color = System.Drawing.Color;
using Image = System.Windows.Controls.Image;

namespace PhotoRender.Filteres
{
    public class Palette
    {
        private static float _red;
        private static float _green;
        private static float _blue;
        public static uint[,] Pixels { get; set; }
        public static Bitmap BmpImage { get; set; }
        public static Image FilteredImage { get; set; }
        public static ImageSource OriginalImage { get; set; }

        protected static float Red
        {
            get => _red;
            set => _red = GetTrueValue(value);
        }

        protected static float Green
        {
            get => _green;
            set => _green = GetTrueValue(value);
        }

        protected static float Blue
        {
            get => _blue;
            set => _blue = GetTrueValue(value);
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
        
        private static float GetTrueValue(float color)
        {
            if (color < 0) return 0.0f;
            if (color > 255) return 255.0f;
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

        protected static (float r, float g, float b) GetColor(uint pixel, double coefficient)
        {
            var r = (float)(coefficient * ((pixel & 0x00FF0000) >> 16));
            var g = (float)(coefficient * ((pixel & 0x0000FF00) >> 8));
            var b = (float)(coefficient * (pixel & 0x000000FF));
            return (r, g, b);
        }

        public static void FillStaticProperties(Image originImage, Image filterImage)
        {
            BmpImage = AstridBitmap.ImageToBitmap(originImage);
            Pixels = BitmapPixels(BmpImage);
            FilteredImage = filterImage;
        } 
    }
}
