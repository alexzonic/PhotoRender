﻿namespace PhotoRender.Filteres // только для матриц 3х3
{
    internal class Sharpness : Convolution
    {
        private static readonly double[,] _sx = { { -1, -1, -1 }, { -1, 9, -1 }, { -1, -1, -1 } };
            // { -1, -1, -1 }, { -1, 9, -1 }, { -1, -1, -1 }
            // {0.111, 0.111, 0.111}, {0.111, 0.111, 0.111}, {0.111, 0.111, 0.111}
        public static void Filter()
        {
            var width = BmpImage.Width;
            var height = BmpImage.Height;
            
            var kernelMatrix = KernelMatrix(width, height);
            
            MatrixConvolution(kernelMatrix, width, height, _sx);
            
            var bitmap = AstridBitmap.SetPixelsInBitmap(Pixels, BmpImage);
            FilteredImage.Source = AstridBitmap.GetBitmapSource(bitmap);
        }
    }
}
