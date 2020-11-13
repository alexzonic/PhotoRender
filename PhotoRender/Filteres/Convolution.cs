namespace PhotoRender.Filteres
{
    public class Convolution : Palette
    {
        protected static uint[,] KernelMatrix(int width, int height)
        {
            var tempWidth = width + 2;
            var tempHeight = height + 2;
            var pixels = new uint[tempHeight, tempWidth];
            
            pixels[0, 0] = Pixels[0, 0];
            pixels[0, tempWidth - 1] = Pixels[0, width - 1];
            pixels[tempHeight - 1, 0] = Pixels[height - 1, 0];
            pixels[tempHeight - 1, tempWidth - 1] = Pixels[height - 1, width - 1];

            for (var y = 1; y < tempHeight - 1; y++)
            {
                pixels[y, 0] = Pixels[y - 1, 0];
                pixels[y, tempWidth - 1] = Pixels[y - 1, width - 1];
            }

            for (var x = 1; x < tempWidth - 1; x++)
            {
                pixels[0, x] = Pixels[0, x - 1];
                pixels[tempHeight - 1, x] = Pixels[height - 1, x - 1];
            }

            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                    pixels[y + 1, x + 1] = Pixels[y, x];
            }

            return pixels;
        }

        protected static void MatrixConvolution(uint[,] kernelMatrix, int width, int height, double[,] sx, int offset)
        {
            for (var y = 1; y < height + 1; ++y)
            {
                for (var x = 1; x < width + 1; ++x)
                {
                    float red = 0, green = 0, blue = 0;
                    for (var i = 0; i < 3; i++)
                    {
                        for (var j = 0; j < 3; j++)
                        {
                            var (r, g, b) = GetColor(kernelMatrix[y - 1 + i, x - 1 + j], sx[i, j]);
                            red += r;
                            green += g;
                            blue += b;
                        }
                    }
                    Red = red + offset;
                    Green = green + offset;
                    Blue = blue + offset;
                    Pixels[y - 1, x - 1] = PixelColor(Red, Green, Blue);
                }
            }
        }

        private static uint PixelColor(float r, float g, float b)
        {
            return 0xFF000000 | ((uint)r << 16) | ((uint)g << 8) | ((uint)b);
        }
    }
}