namespace PhotoRender.Filteres
{
    internal sealed class Relief : Convolution
    {
        private static readonly double[,] Sx = { { -2, -1, 0 }, { -1, 0, 1 }, { 0, 1, 2 } };
        
        public static void Filter()
        {
            FilteredImage.Source = AstridBitmap.GetBitmapSource(MatrixConvolution(Sx, 128));
        }
    }
}