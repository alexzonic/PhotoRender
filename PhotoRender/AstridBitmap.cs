﻿using System;
using System.Drawing;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Color = System.Drawing.Color;

namespace PhotoRender
{
    public static class AstridBitmap
    {
        private const int ResizeRate = 2;

        public static Bitmap ToBitmap(int width, int height, Func<int, int, Color> getPixelColor)
        {
            var bmp = new Bitmap(ResizeRate * width, ResizeRate * height);
            using (var g = Graphics.FromImage(bmp))
            {
                for (var x = 0; x < width; x++)
                    for (var y = 0; y < height; y++)
                        g.FillRectangle(new SolidBrush(getPixelColor(x, y)),
                            ResizeRate * x,
                            ResizeRate * y,
                            ResizeRate,
                            ResizeRate
                        );
            }

            return bmp;
        }

        public static Bitmap ToBitmap(Pixel[,] array)
        {
            return ToBitmap(array.GetLength(0), array.GetLength(1),
                (x, y) => Color.FromArgb(array[x, y].R, array[x, y].G, array[x, y].B));
        }

        public static Bitmap ToBitmap(double[,] array)
        {
            return ToBitmap(array.GetLength(0), array.GetLength(1), (x, y) =>
            {
                var gray = (int)(255 * array[x, y]);
                gray = Math.Min(gray, 255);
                gray = Math.Max(gray, 0);
                return Color.FromArgb(gray, gray, gray);
            });
        }

        public static BitmapSource GetBitmapSource(Bitmap bitmap)
        {
            var bitmapData = bitmap.LockBits(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                System.Drawing.Imaging.ImageLockMode.ReadOnly, bitmap.PixelFormat);

            var bitmapSource = BitmapSource.Create(
                bitmapData.Width, bitmapData.Height,
                bitmap.HorizontalResolution, bitmap.VerticalResolution,
                PixelFormats.Bgr32, null, // формат Bgra32 тоже работает исправно
                bitmapData.Scan0, bitmapData.Stride * bitmapData.Height, bitmapData.Stride);

            bitmap.UnlockBits(bitmapData);
            return bitmapSource;
        }

        public static Pixel[,] LoadPixels(Bitmap bmp)
        {
            var pixels = new Pixel[bmp.Width, bmp.Height];
            for (var x = 0; x < bmp.Width; x++)
                for (var y = 0; y < bmp.Height; y++)
                    pixels[x, y] = new Pixel(bmp.GetPixel(x, y));
            return pixels;
        }
    }
}