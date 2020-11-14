namespace PhotoRender.Filteres
{
    internal sealed class Negativity : Convolution
    {
        private static readonly double[,] Sx = { { 0, 0, 0 }, { 0, -1, 0 }, { 0, 0, 0 } };
        
        public static void Filter()
        {
            FilteredImage.Source = AstridBitmap.GetBitmapSource(MatrixConvolution(Sx, 255));
        }
    }
}