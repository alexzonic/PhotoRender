using System.Drawing;
using System.Runtime.CompilerServices;
using Image = System.Windows.Controls.Image;

namespace PhotoRender.Filteres
{
    public class Convolution : Palette
    {
        private static double[,] _sx = { { 0, 0, 0 }, { 0, 1, 0 }, { 0, 0, 0 } };
        private static int _gap = 1;
        public static uint[,] Matrix { get; set; }
        
        protected static Bitmap MatrixConvolution(double[,] sx, int offset)
        {
            _sx = sx;
            var width = BmpImage.Width;
            var height = BmpImage.Height;
            var n = _sx.GetLength(0);
            for (var y = _gap; y < height + _gap; ++y)
            {
                for (var x = _gap; x < width + _gap; ++x)
                {
                    float red = 0, green = 0, blue = 0;
                    for (var i = 0; i < n; i++)
                    {
                        for (var j = 0; j < n; j++)
                        {
                            var (r, g, b) = GetColor(Matrix[y - _gap + i, x - _gap + j], _sx[i, j]);
                            red += r;
                            green += g;
                            blue += b;
                        }
                    }
                    Red = red + offset;
                    Green = green + offset;
                    Blue = blue + offset;
                    Pixels[y - _gap, x - _gap] = PixelColor(Red, Green, Blue);
                }
            }
            return AstridBitmap.SetPixelsInBitmap(Pixels, BmpImage);
        }

        private static uint PixelColor(float r, float g, float b)
        {
            return 0xFF000000 | ((uint)r << 16) | ((uint)g << 8) | ((uint)b);
        }

        public static uint[,] KernelMatrix(int width, int height)
        {
            _gap = _sx.GetLength(0) / 2;
            var tempWidth = width + 2 * _gap;
            var tempHeight = height + 2 * _gap;
            var pixels = new uint[tempHeight, tempWidth];

            for (var i = 0; i < _gap; i++)
            {
                for (var j = 0; j < _gap; j++)
                {
                    pixels[i, j] = Pixels[i, j];
                    pixels[i, tempWidth - 1 - j] = Pixels[0, width - 1];
                    pixels[tempHeight - 1 - i, 0] = Pixels[height - 1, 0];
                    pixels[tempHeight - 1 - i, tempWidth - 1 - j] = Pixels[height - 1, width - 1];
                }
            }

            for (var y = _gap; y < tempHeight - _gap; y++)
            {
                for (var x = 0; x < _gap; x++)
                {
                    pixels[y, x] = Pixels[y - _gap, x];
                    pixels[y, tempWidth - 1 - x] = Pixels[y - _gap, width - 1 - x];
                }
            }

            for (var y = 0; y < _gap; y++)
            {
                for (var x = _gap; x < tempWidth - _gap; x++)
                {
                    pixels[y, x] = Pixels[y, x - _gap];
                    pixels[tempHeight - 1 - y, x] = Pixels[height - 1 - y, x - _gap];
                }
            }

            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                    pixels[y + _gap, x + _gap] = Pixels[y, x];
            }

            return pixels;
        }
    }
}