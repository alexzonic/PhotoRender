using System;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Media;
using Color = System.Drawing.Color;
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
        
        public static void ChangeBrightnessForTick(Slider slider)
        {
            ChangePixelsColor(slider, ChangeBrightness);
            FilteredImage.Source = AstridBitmap.GetBitmapSource(BmpImage);
        }
        
        public static void ChangeContrastForTick(Slider slider)
        {
            ChangePixelsColor(slider, ChangeContrast);
            FilteredImage.Source = AstridBitmap.GetBitmapSource(BmpImage);
        }
    }
}