namespace PhotoRender.Filteres
{
    internal class Sharpness : Palette
    {
        private static readonly double[,] _sx = { { -1, -1, -1 }, { -1, 9, -1 }, { -1, -1, -1 } };

        public static void Filter()
        {
            var width = BmpImage.Width;
            var height = BmpImage.Height;
            var tempWidth = BmpImage.Width + 2;
            var tempHeight = BmpImage.Height + 2;
            
            var pixels = new uint[height, width];
            var tempPixels = new uint[tempHeight, tempWidth];
            
            tempPixels[0, 0] = Pixels[0, 0];
            tempPixels[0, tempWidth - 1] = Pixels[0, width - 1];
            tempPixels[tempHeight - 1, 0] = Pixels[height - 1, 0];
            tempPixels[tempHeight - 1, tempWidth - 1] = Pixels[height - 1, width - 1];

            for (var y = 1; y < tempHeight - 1; y++)
            {
                tempPixels[y, 0] = Pixels[y - 1, 0];
                tempPixels[y, tempWidth - 1] = Pixels[y - 1, width - 1];
            }

            for (var x = 1; x < tempWidth - 1; x++)
            {
                tempPixels[0, x] = Pixels[0, x - 1];
                tempPixels[tempHeight - 1, x] = Pixels[height - 1, x - 1];
            }

            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                    tempPixels[y + 1, x + 1] = Pixels[y, x];
            }

            for (var y = 1; y < tempHeight - 1; y++)
            {
                for (var x = 1; x < tempWidth - 1; x++)
                {
                    float red = 0, green = 0, blue = 0;
                    for (var i = 0; i < 3; i++)
                    {
                        for (var j = 0; j < 3; j++)
                        {
                            var (r, g, b) = GetColor(tempPixels[y - 1 + i, x - 1 + j], _sx[i, j]);
                            red += r;
                            green += g;
                            blue += b;
                        }
                    }
                    Red = red;
                    Green = green;
                    Blue = blue;
                    pixels[y - 1, x - 1] = PixelColor(Red, Green, Blue);
                }
            }
            
            var bitmap = AstridBitmap.SetPixelsInBitmap(pixels, BmpImage);
            FilteredImage.Source = AstridBitmap.GetBitmapSource(bitmap);
        }

        private static uint PixelColor(float r, float g, float b)
        {
            return 0xFF000000 | ((uint)r << 16) | ((uint)g << 8) | ((uint)b);
        }
    }
}
