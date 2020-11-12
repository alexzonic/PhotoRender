namespace PhotoRender.Filteres
{
    internal sealed class BrightnessContrast : Palette
    {
        public static uint ChangeBrightness(uint point, int position, int max)
        {
            var percent = (100 / max) * position;
            
            Red = (int)(((point & 0x00FF0000) >> 16) + percent * 128 / 100);
            Green = (int)(((point & 0x0000FF00) >> 8) + percent * 128 / 100);
            Blue = (int)((point & 0x000000FF) + percent * 128 / 100);

            return 0xFF000000 | ((uint)Red << 16) | ((uint)Green << 8) | ((uint)Blue);
        }

        public uint ChangeContrast(uint point, int position)
        {
            if (position == 100) position = 99;
            Red = (int)((((point & 0x00FF0000) >> 16) * 100 - 128 * position) / (100 - position));
            Green = (int)((((point & 0x0000FF00) >> 8) * 100 - 128 * position) / (100 - position));
            Blue = (int)(((point & 0x000000FF) * 100 - 128 * position) / (100 - position));   
            
            return 0xFF000000 | ((uint)Red << 16) | ((uint)Green << 8) | ((uint)Blue);
        }
    }
}
