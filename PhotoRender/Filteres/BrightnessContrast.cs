using System.Windows.Controls;

namespace PhotoRender.Filteres
{
    internal sealed class BrightnessContrast : Palette
    {
        private static uint ChangeBrightness(uint point, int position, int max)
        {
            var percent = (100 / max) * position;
            
            Red = ((point & 0x00FF0000) >> 16) + percent * 128 / 100;
            Green = ((point & 0x0000FF00) >> 8) + percent * 128 / 100;
            Blue = (point & 0x000000FF) + percent * 128 / 100;

            return 0xFF000000 | ((uint)Red << 16) | ((uint)Green << 8) | ((uint)Blue);
        }

        private static uint ChangeContrast(uint point, int position, int max)
        {
            var percent = (100 / max) * position;
            if (percent >= 0)
            {
                if (percent == 100) percent = 99;
                Red = (((point & 0x00FF0000) >> 16) * 100f - 128 * percent) / (100 - percent);
                Green = (((point & 0x0000FF00) >> 8) * 100f - 128 * percent) / (100 - percent);
                Blue = ((point & 0x000000FF) * 100f - 128 * percent) / (100 - percent);
            }
            else
            {
                Red = (((point & 0x00FF0000) >> 16) * (100f - (-percent)) + 128 * (-percent)) / 100;
                Green = (((point & 0x0000FF00) >> 8) * (100f - (-percent)) + 128 * (-percent)) / 100;
                Blue = ((point & 0x000000FF) * (100f - (-percent)) + 128 * (-percent)) / 100;
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