using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoRender.Filteres
{
    public static class Brigtness
    { 
        public static uint ChangeBrigtness(uint point, int position, int maxValue)
        {
            int red;
            int green;
            int blue;

            var percent = (100 / maxValue) * position; //кол-во процентов

            red = (int)(((point & 0x00FF0000) >> 16) + percent * 128 / 100);
            green = (int)(((point & 0x0000FF00) >> 8) + percent * 128 / 100);
            blue = (int)((point & 0x000000FF) + percent * 128 / 100);

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
