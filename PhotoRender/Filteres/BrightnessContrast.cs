using System;
using System.Drawing;
using System.Windows.Controls;
using Image = System.Windows.Controls.Image;

namespace PhotoRender.Filteres
{
    internal sealed class BrightnessContrast : Palette
    {
        private static uint ChangeBrightness(uint point, int position, int max)
        {
            var percent = (100 / max) * position;
            
            Red = (int)(((point & 0x00FF0000) >> 16) + percent * 128 / 100);
            Green = (int)(((point & 0x0000FF00) >> 8) + percent * 128 / 100);
            Blue = (int)((point & 0x000000FF) + percent * 128 / 100);

            return 0xFF000000 | ((uint)Red << 16) | ((uint)Green << 8) | ((uint)Blue);
        }

        private static uint ChangeContrast(uint point, int position, int max)
        {
            var percent = (100 / max) * position;
            if (percent >= 0)
            {
                if (percent == 100) percent = 99;
                Red = (int) ((((point & 0x00FF0000) >> 16) * 100 - 128 * percent) / (100 - percent));
                Green = (int) ((((point & 0x0000FF00) >> 8) * 100 - 128 * percent) / (100 - percent));
                Blue = (int) (((point & 0x000000FF) * 100 - 128 * percent) / (100 - percent));
            }
            else
            {
                Red = (int)((((point & 0x00FF0000) >> 16) * (100 - (-percent)) + 128 * (-percent)) / 100);
                Green = (int)((((point & 0x0000FF00) >> 8) * (100 - (-percent)) + 128 * (-percent)) / 100);
                Blue = (int)(((point & 0x000000FF) * (100 - (-percent)) + 128 * (-percent)) / 100);
            }

            return 0xFF000000 | ((uint)Red << 16) | ((uint)Green << 8) | ((uint)Blue);
        }
        
        public static void ChangeBrightnessForTick(Bitmap originBitmap, Image origin, Slider slider, uint[,] pixel)
        {
            var bitmap = (Bitmap)originBitmap.Clone();
            var pixels = BitmapPixels(bitmap);
            ChangePixelsColor(bitmap, pixels, slider, ChangeBrightness);
            
            origin.Source = AstridBitmap.GetBitmapSource(bitmap);
        }
        // статический общий uint[,] пикселей
        public static void ChangeContrastForTick(Bitmap originBitmap, Image origin, Slider slider, uint[,] pixel)
        {
            var bitmap = (Bitmap)originBitmap.Clone();
            var pixels = BitmapPixels(bitmap);
            ChangePixelsColor(bitmap, pixels, slider, ChangeContrast);
            
            origin.Source = AstridBitmap.GetBitmapSource(bitmap);
        }

        public static uint[,] BitmapPixels(Bitmap bitmap)
        {
            var pixels = new uint[bitmap.Height, bitmap.Width];
            for (var y = 0; y < bitmap.Height; y++)
            {
                for (var x = 0; x < bitmap.Width; x++)
                    pixels[y, x] = (uint) (bitmap.GetPixel(x, y).ToArgb());
            }
            return pixels;
        }

        private static void ChangePixelsColor(Bitmap bitmap, uint[,] pixels, Slider slider, Func<uint, int, int, uint> change)
        {
            for (var y = 0; y < bitmap.Height; y++)
            {
                for (var x = 0; x < bitmap.Width; x++)
                {
                    var point = change(pixels[y, x], (int) slider.Value, (int) slider.Maximum);
                    bitmap.SetPixel(x, y, Color.FromArgb((int)point));
                }
            }
        }
    }
}
