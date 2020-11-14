namespace PhotoRender.Filteres
{
    public class BorderHighlight : Convolution
    {
        private static readonly double[,] _sx = { { -2, -1, 0 }, { -1, 0, 1 }, { 0, 1, 2 } };
        
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