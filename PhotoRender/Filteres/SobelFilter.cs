using System;
using System.Drawing;
using Image = System.Windows.Controls.Image;

namespace PhotoRender.Filteres
{
    public static class SobelFilter
    {
        private static int _size;
        private static readonly double[,] _sx = new double[,] {{-1, -2, -1}, {0, 0, 0}, {1, 2, 1}};

        public static Bitmap ToSobelFilter(Image originalImg)
        {
            var filtredPixels = GrayScale.GetGrayImage(originalImg);

            var sobel = Filter(filtredPixels);
            
            return AstridBitmap.ToBitmap(sobel);
        }

        private static double[,] Filter(double[,] g)
        {
            var width = g.GetLength(0);
            var height = g.GetLength(1);
            _size = _sx.GetUpperBound(0) + 1;

            var filteredArray = new double[width, height];
            var delta = _sx.GetUpperBound(0) / 2;
            var sy = TransposeSX();

            for (var x = delta; x < width - delta; x++)
            {
                for (var y = delta; y < height - delta; y++)
                {
                    var gx = Сonvolution(_sx, g, x - delta, y - delta);
                    var gy = Сonvolution(sy, g, x - delta, y - delta);
                    filteredArray[x, y] = Math.Sqrt(gx * gx + gy * gy);
                }
            }

            return filteredArray;
        }

        private static double[,] TransposeSX()
        {
            var result = new double[_size, _size];
            for (var x = 0; x < _size; x++)
            {
                for (var y = 0; y < _size; y++)
                    result[x, y] = _sx[y, x];
            }
            return result;
        }

        private static double Сonvolution(double[,] sxy, double[,] g, int x, int y)
        {
            var sum = 0.0;
            for (var i = 0; i < _size; i++)
            {
                for (var j = 0; j < _size; j++)
                    sum += sxy[i, j] * g[x + i, y + j];
            }
            return sum;
        }
    }
}
