using System.Drawing;
using Image = System.Windows.Controls.Image;

namespace PhotoRender.Filteres
{
    public static class GrayScale
    {
	    public static Bitmap ToGrayscale(Image originalImg)
	    {
		    var pixels = AstridBitmap.LoadPixels(AstridBitmap.ImageToBitmap(originalImg));
            
		    var filteredPixels = Filter(pixels);
		    
		    return AstridBitmap.ToBitmap(filteredPixels);
	    }

	    public static double[,] GetGrayImage(Image originalImg)
	    {
		    var pixels = AstridBitmap.LoadPixels(AstridBitmap.ImageToBitmap(originalImg));
		    return Filter(pixels);
	    }
	    
        private static double[,] Filter(Pixel[,] original)
		{
			var width = original.GetLength(0);
			var height = original.GetLength(1);
			var grayscale = new double[width, height];

			for (var x = 0; x < width; x++)
			{
				for (var y = 0; y < height; y++)
                    grayscale[x, y] = original[x, y].GetShadeOfGray();
			}

			return grayscale;
		}
	}
}
