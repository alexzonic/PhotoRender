namespace PhotoRender.Filteres
{
    public class Palette
    {
        private int red;
        private int green;
        private int blue;

        public int Red
        {
            get => red;
            set => red = GetTrueValue(value);
        }
        public int Green
        {
            get => green;
            set => green = GetTrueValue(value);
        }
        public int Blue
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
