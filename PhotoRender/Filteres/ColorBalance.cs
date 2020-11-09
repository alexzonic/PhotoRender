namespace PhotoRender.Filteres
{
    public class ColorBalance : Palette
    {
        public uint BalanceRed(uint point, int position)
        {
            Red = (int)(((point & 0x00FF0000) >> 16) + position * 128 / 100);
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
