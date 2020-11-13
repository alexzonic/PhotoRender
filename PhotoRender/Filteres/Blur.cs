namespace PhotoRender.Filteres
{
    public class Blur : Convolution
    {
        private static readonly double[,] _sx = { {0.111, 0.111, 0.111}, {0.111, 0.111, 0.111}, {0.111, 0.111, 0.111} };

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