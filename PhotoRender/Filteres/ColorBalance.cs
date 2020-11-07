namespace PhotoRender.Filteres
{
    public class ColorBalance
    {
        
        private int Red
        {
            get => Red;
            set
            {
                if (value < 0)
                    Red = 0;
                else if (value > 255)
                    Red = 255;
                else Red = value;
            }
        }
        private int Green
        {
            get => Green;
            set
            {
                if (value < 0)
                    Green = 0;
                else if (value > 255)
                    Green = 255;
                else Green = value;
            }
        }
        private int Blue
        {
            get => Blue;
            set
            {
                if (value < 0)
                    Blue = 0;
                else if (value > 255)
                    Blue = 255;
                else Blue = value;
            }
        }

        public uint BalanceRed(uint point, int position)
        {
            Red = (int)(((point & 0x00FF0000) >> 16) + position * 128 / 100));
            Green = (int)((point & 0x0000FF00) >> 8);
            Blue = (int)(point & 0x000000FF);

            return 0xFF000000 | ((uint)Red << 16) | ((uint)Green << 8) | ((uint)Blue);
        }

        public uint BalanceGreen(uint point, int position)
        {
            Red = (int)((point & 0x00FF0000) >> 16);
            Green = (int)(((point & 0x0000FF00) >> 8) + position * 128 / 100);
            Blue = (int)(point & 0x000000FF);

            return 0xFF000000 | ((uint)Red << 16) | ((uint)Green << 8) | ((uint)Blue);
        }

        public uint BalanceBlue(uint point, int position)
        {
            Red = (int)((point & 0x00FF0000) >> 16);
            Green = (int)((point & 0x0000FF00) >> 8);
            Blue = (int)((point & 0x000000FF) + position * 128 / 100);

            return 0xFF000000 | ((uint)Red << 16) | ((uint)Green << 8) | ((uint)Blue);
        }
    }
}
