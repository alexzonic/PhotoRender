namespace PhotoRender.Filteres
{
    internal sealed class BrightnessContrast
    {
        private int Red { 
            get => Red;
            set {
                if (value < 0)
                    Red = 0;
                else if (value > 255)
                    Red = 255;
                else Red = value;
            }
        }
        private int Green {
            get => Green;
            set {
                if (value < 0)
                    Green = 0;
                else if (value > 255)
                    Green = 255;
                else Green = value;
            }
        }
        private int Blue {
            get => Blue;
            set {
                if (value < 0)
                    Blue = 0;
                else if (value > 255)
                    Blue = 255;
                else Blue = value;
            }
        }

        public uint ChangeBrightness(uint point, int position)
        {
            Red = (int)(((point & 0x00FF0000) >> 16) + position * 128 / 100);
            Green = (int)(((point & 0x0000FF00) >> 8) + position * 128 / 100);
            Blue = (int)((point & 0x000000FF) + position * 128 / 100);

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
