using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using PhotoRender.Filteres;
using Color = System.Drawing.Color;
using Image = System.Windows.Controls.Image;

namespace PhotoRender
{
    public partial class BrightSlider : Window
    {
        private Bitmap original; 
        private static Image originalImg;
        public BrightSlider(Image img, Bitmap bimap) // второй параметр битмап
        {
            originalImg = img;
            original = bimap;
            InitializeComponent();
        }

        private static double curValue = 0;

        private void Slider_ValueChanger(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((Slider)sender).SelectionEnd=e.NewValue;
            curValue = e.NewValue;
            ChangeBright();
        }

        private void ChangeBright()
        {
            uint point;
            // цвета битмапа
            var pixel = new uint[original.Height, original.Width];
            for (var y = 0; y < original.Height; y++)
            {
                for (var x = 0; x < original.Width; x++)
                    pixel[y, x] = (uint) (original.GetPixel(x, y).ToArgb());
            }
            
            // меняем цвета битмапа
            for (var y = 0; y < original.Height; y++)
            {
                for (var x = 0; x < original.Width; x++)
                {
                    point = BrightnessContrast.ChangeBrightness(pixel[y, x], (int)curValue);
                    FromOnePixelToBitmap(y, x, point);
                }
            }
            
            // изменение битмапа
            //var res = SetBmp(pixel);

            originalImg.Source = AstridBitmap.GetBitmapSource(original);
        }

        private Bitmap SetBmp(uint[,] pixel)
        {
            for (var y = 0; y < original.Height; y++)
            {
                for (var x = 0; x < original.Width; x++)
                {
                    original.SetPixel(x, y, Color.FromArgb((int)pixel[y, x]));     
                }
            }

            return original;
        }
        
        private void FromOnePixelToBitmap(int x, int y, uint pixel)
        {
            original.SetPixel(y, x, Color.FromArgb((int)pixel));
        }
    }
}