using System;
using System.Windows.Controls;

namespace PhotoRender.Filteres
{
    public class ColorBalance : Palette
    {    
        
        public static uint BalanceRed(uint point, int position, int max)
        {
            var percent = (100 / max) * position;
            
            Red = ((point & 0x00FF0000) >> 16) + percent * 128 / 100;
            Green = (point & 0x0000FF00) >> 8;
            Blue = point & 0x000000FF;

            return 0xFF000000 | ((uint)Red << 16) | ((uint)Green << 8) | ((uint)Blue);
        }

        public static uint BalanceGreen(uint point, int position, int max)
        {
            var percent = (100 / max) * position;
            
            Red = ((point & 0x00FF0000) >> 16);
            Green = ((point & 0x0000FF00) >> 8) + percent * 128 / 100;
            Blue = point & 0x000000FF;

            return 0xFF000000 | ((uint)Red << 16) | ((uint)Green << 8) | ((uint)Blue);
        }

        public static uint BalanceBlue(uint point, int position, int max)
        {
            var percent = (100 / max) * position;
            
            Red = (point & 0x00FF0000) >> 16;
            Green = (point & 0x0000FF00) >> 8;
            Blue = (point & 0x000000FF) + percent * 128 / 100;

            return 0xFF000000 | ((uint)Red << 16) | ((uint)Green << 8) | ((uint)Blue);
        }

        public static void PointBalance(Slider slider, Func<uint, int, int, uint> colorBalance)
        {
            ChangePixelsColor(slider, colorBalance);
            FilteredImage.Source = AstridBitmap.GetBitmapSource(BmpImage);
        }
    }
}
