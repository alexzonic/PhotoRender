using System.Windows.Controls;
using System.Windows.Media;

namespace PhotoRender.Filteres // только для матриц 3х3
{
    internal class Sharpness : Convolution
    {
        private static readonly double[,] _sx = { { -1, -1, -1 }, { -1, 9, -1 }, { -1, -1, -1 } };
            // { -1, -1, -1 }, { -1, 9, -1 }, { -1, -1, -1 }
            //{ -2, -1, 0 }, { -1, 1, 1 }, { 0, 1, 2 } emboss
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
