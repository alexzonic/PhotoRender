using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoRender.Filteres
{
    public static class Contrast
    {
        public static uint ChangeContrast(uint point, int position, int maxValue)
        {
            int red;
            int green;
            int blue;

            var percent = (100 / maxValue) * position; //кол-во процентов

            if (percent >= 0)
            {
                if (percent == 100) percent = 99;
                red = (int)((((point & 0x00FF0000) >> 16) * 100 - 128 * percent) / (100 - percent));
                green = (int)((((point & 0x0000FF00) >> 8) * 100 - 128 * percent) / (100 - percent));
                blue = (int)(((point & 0x000000FF) * 100 - 128 * percent) / (100 - percent));
            }
            else
            {
                red = (int)((((point & 0x00FF0000) >> 16) * (100 - (-percent)) + 128 * (-percent)) / 100);
                green = (int)((((point & 0x0000FF00) >> 8) * (100 - (-percent)) + 128 * (-percent)) / 100);
                blue = (int)(((point & 0x000000FF) * (100 - (-percent)) + 128 * (-percent)) / 100);
            }

            //контролируем переполнение переменных
            if (red < 0) red = 0;
            else if (red > 255) red = 255;
            
            if (green < 0) green = 0;
            else if (green > 255) green = 255;
            
            if (blue < 0) blue = 0;
            else if (blue > 255) blue = 255;

            point = 0xFF000000 | ((uint)red << 16) | ((uint)green << 8) | ((uint)blue);

            return point;
        }
    }
}
