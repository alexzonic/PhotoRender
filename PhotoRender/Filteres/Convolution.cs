using System.Runtime.CompilerServices;

namespace PhotoRender.Filteres
{
    public class Convolution : Palette
    {
        private static double[,] _sx = { { 0, 0, 0 }, { 0, 1, 0 }, { 0, 0, 0 } };
        private static int Gap = 1;

        protected static uint[,] KernelMatrix(int width, int height, double[,] sx)
        {
            _sx = sx;
            Gap = _sx.GetLength(0) / 2;
            var tempWidth = width + 2 * Gap;
            var tempHeight = height + 2 * Gap;
            var pixels = new uint[tempHeight, tempWidth];

            for (var i = 0; i < Gap; i++)
            {
                for (var j = 0; j < Gap; j++)
                {
                    pixels[i, j] = Pixels[i, j];
                    pixels[i, tempWidth - 1 - j] = Pixels[0, width - 1];
                    pixels[tempHeight - 1 - i, 0] = Pixels[height - 1, 0];
                    pixels[tempHeight - 1 - i, tempWidth - 1 - j] = Pixels[height - 1, width - 1];
                }
            }

            for (var y = Gap; y < tempHeight - Gap; y++)
            {
                for (var x = 0; x < Gap; x++)
                {
                    pixels[y, x] = Pixels[y - Gap, x];
                    pixels[y, tempWidth - 1 - x] = Pixels[y - Gap, width - 1 - x];
                }
            }

            for (var y = 0; y < Gap; y++)
            {
                for (var x = Gap; x < tempWidth - Gap; x++)
                {
                    pixels[y, x] = Pixels[y, x - Gap];
                    pixels[tempHeight - 1 - y, x] = Pixels[height - 1 - y, x - Gap];
                }
            }

            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                    pixels[y + Gap, x + Gap] = Pixels[y, x];
            }

            return pixels;
        }

        protected static void MatrixConvolution(uint[,] kernelMatrix, int width, int height, int offset)
        {
            //Gap = _sx.GetLength(0) / 2;
            var n = _sx.GetLength(0);
            for (var y = Gap; y < height + Gap; ++y)
            {
                for (var x = Gap; x < width + Gap; ++x)
                {
                    float red = 0, green = 0, blue = 0;
                    for (var i = 0; i < n; i++)
                    {
                        for (var j = 0; j < n; j++)
                        {
                            var (r, g, b) = GetColor(kernelMatrix[y - Gap + i, x - Gap + j], _sx[i, j]);
                            red += r;
                            green += g;
                            blue += b;
                        }
                    }
                    Red = red + offset;
                    Green = green + offset;
                    Blue = blue + offset;
                    Pixels[y - Gap, x - Gap] = PixelColor(Red, Green, Blue);
                }
            }
        }

        private static uint PixelColor(float r, float g, float b)
        {
            return 0xFF000000 | ((uint)r << 16) | ((uint)g << 8) | ((uint)b);
        }
    }
}