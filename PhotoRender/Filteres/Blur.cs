namespace PhotoRender.Filteres
{
    public class Blur : Convolution
    {
        private static readonly double[,] _sx = { {0.111, 0.111, 0.111}, {0.111, 0.111, 0.111}, {0.111, 0.111, 0.111} };
        
        public static void Filter()
        {
            var width = BmpImage.Width;
            var height = BmpImage.Height;
            
            var kernelMatrix = KernelMatrix(width, height, _sx);
            
            MatrixConvolution(kernelMatrix, width, height, 0);
            
            var bitmap = AstridBitmap.SetPixelsInBitmap(Pixels, BmpImage);
            FilteredImage.Source = AstridBitmap.GetBitmapSource(bitmap);
        }
    }
}