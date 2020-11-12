namespace PhotoRender.Filteres
{
    public class Palette
    {
        private static  int red;
        private static  int green;
        private static int blue;
        

        protected static int Red
        {
            get => red;
            set => red = GetTrueValue(value);
        }

        protected static int Green
        {
            get => green;
            set => green = GetTrueValue(value);
        }

        protected static int Blue
        {
            get => blue;
            set => blue = GetTrueValue(value);
        }

        private static int GetTrueValue(int color)
        {
            if (color < 0) return 0;
            if (color > 255) return 255;
            return color;
        }
    }
}
