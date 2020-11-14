namespace PhotoRender.Filteres
{
    internal sealed class Blur : Convolution
    {
        private static readonly double[,] Sx = { {0.111, 0.111, 0.111}, {0.111, 0.111, 0.111}, {0.111, 0.111, 0.111} };
        
        public static void Filter()
        {
            FilteredImage.Source = AstridBitmap.GetBitmapSource(MatrixConvolution(Sx, 0));
        }
    }
}