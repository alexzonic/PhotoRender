namespace PhotoRender.Filteres
{
    public class Relief : Convolution
    {
        private static readonly double[,] _sx = { { -2, -1, 0 }, { -1, 0, 1 }, { 0, 1, 2 } };
        
        public static void Filter()
        {
            var width = BmpImage.Width;
            var height = BmpImage.Height;
            
            var kernelMatrix = KernelMatrix(width, height);
            
            MatrixConvolution(kernelMatrix, width, height, _sx, 128);
            
            var bitmap = AstridBitmap.SetPixelsInBitmap(Pixels, BmpImage);
            FilteredImage.Source = AstridBitmap.GetBitmapSource(bitmap);
        }
    }
}