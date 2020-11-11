using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoRender.Filteres
{
    static class Negativ
    {
        private static double[,] _sx = new double[,] { { -1, -1, -1 }, { -1, 9, -1 }, { -1, -1, -1 } };
        public static Bitmap NegativFiltred(System.Windows.Controls.Image image)
        {
            var bmp = AstridBitmap.ImageToBitmap(image);
            var pixels = new uint[bmp.Height, bmp.Width];
            for(var x = 0; x < bmp.Height; x++)
            {
                for (var y = 0; y < bmp.Width; y++)
                {
                    pixels[x, y] = (uint)bmp.GetPixel(y, x).ToArgb() ;
                }
            }
            var imageUint = HighlightingChangesInBrightness(_sx, pixels, 1);

            return SetBmp(bmp, imageUint);
        }

        private static uint[,] HighlightingChangesInBrightness(double[,] array,uint[,] g, int shift)
        {
            var filtredImage = new uint[g.GetLength(0), g.GetLength(1)];
            var length = array.GetLength(0);
            for (var x = shift; x < g.GetLength(0) - shift; x++)
            {
                for (int y = shift; y < g.GetLength(1) - shift; y++)
                {
                    for (var i = 0; i < length; i++)
                    {
                        for (var j = 0; j < length; j++)
                        {
                                filtredImage[x, y] = (uint)array[i, j] * g[x - 1 + i, y - 1 + j];
                        }
                    }
                }
            }
            return filtredImage;
        }

        private static Bitmap SetBmp(Bitmap image, uint[,] pixels)
        {
            for (var x = 0; x < pixels.GetLength(0); x++)
            {
                for (var y = 0; y < pixels.GetLength(1); y++)
                {
                    image.SetPixel(y, x, Color.FromArgb((int)pixels[x, y]));
                }
            }
            return image;
        }
    }
}
