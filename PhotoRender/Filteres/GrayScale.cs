namespace PhotoRender.Filteres
{
    public static class GrayScale
    {
        public static double[,] ToGrayscale(Pixel[,] original)
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
