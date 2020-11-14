using System.Windows.Controls;
using System.Windows.Media;

namespace PhotoRender.Filteres // только для матриц 3х3
{
    internal sealed class Sharpness : Convolution
    {
        private static readonly double[,] Sx = { { -1, -1, -1 }, { -1, 9, -1 }, { -1, -1, -1 } };
            
        public static void Filter()
        {
            FilteredImage.Source = AstridBitmap.GetBitmapSource(MatrixConvolution(Sx, 0));
        }
    }
}
