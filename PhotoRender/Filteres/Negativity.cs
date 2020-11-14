﻿namespace PhotoRender.Filteres
{
    public class Negativity : Convolution
    {
        private static readonly double[,] _sx = { { 0, 0, 0 }, { 0, -1, 0 }, { 0, 0, 0 } };
        
        public static void Filter()
        {
            var width = BmpImage.Width;
            var height = BmpImage.Height;
            
            var kernelMatrix = KernelMatrix(width, height, _sx);
            
            MatrixConvolution(kernelMatrix, width, height, 255);
            
            var bitmap = AstridBitmap.SetPixelsInBitmap(Pixels, BmpImage);
            FilteredImage.Source = AstridBitmap.GetBitmapSource(bitmap);
        }
    }
}