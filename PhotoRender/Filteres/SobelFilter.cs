using System;

namespace PhotoRender.Filteres
{
    public static class SobelFilter
    {
        private static int _size;
        public static double[,] ToSobell(double[,] g, double[,] sx)
        {
            var width = g.GetLength(0);
            var height = g.GetLength(1);
            _size = sx.GetUpperBound(0) + 1;

            var filteredArray = new double[width, height];
            var delta = sx.GetUpperBound(0) / 2;
            var sy = Transpose(sx);

            for (var x = delta; x < width - delta; x++)
            {
                for (var y = delta; y < height - delta; y++)
                {
                    var gx = Сonvolution(sx, g, x - delta, y - delta);
                    var gy = Сonvolution(sy, g, x - delta, y - delta);
                    filteredArray[x, y] = Math.Sqrt(gx * gx + gy * gy);
                }
            }

            return filteredArray;
        }

        private static double[,] Transpose(double[,] sx)
        {
            var result = new double[_size, _size];
            for (var x = 0; x < _size; x++)
            {
                for (var y = 0; y < _size; y++)
                    result[x, y] = sx[y, x];
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
