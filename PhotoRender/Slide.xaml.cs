using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using PhotoRender.Filteres;
using Image = System.Windows.Controls.Image;

namespace PhotoRender
{
    public partial class Slide : Window
    {
        public Slide()
        {
            InitializeComponent();
        }

        private static double curValue = 0;
        public void Slider_ValueChanger(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            slider.Value = e.NewValue;
            curValue = slider.Value;
        }

        public static Bitmap ChangeBright(Bitmap image)
        {
            uint point;
            // цвета битмапа
            var pixel = new uint[image.Height, image.Width];
            for (var y = 0; y < image.Height; y++)
            {
                for (var x = 0; x < image.Width; x++)
                    pixel[y, x] = (uint) (image.GetPixel(x, y).ToArgb());
            }
            
            // меняем цвета битмапа
            for (var y = 0; y < image.Height; y++)
            {
                for (var x = 0; x < image.Width; x++)
                {
                    point = BrightnessContrast.ChangeBrightness(pixel[y, x], curValue);
                    FromOnePixelToBitmap(y, x, point, image);
                }
            }
            
            // изменение битмапа
            var res = SetBmp(image, pixel);
            
            return res;
        }

        private static Bitmap SetBmp(Bitmap image, uint[,] pixel)
        {
            for (var y = 0; y < image.Height; y++)
            {
                for (var x = 0; x < image.Width; x++)
                {
                    image.SetPixel(x, y, Color.FromArgb((int)pixel[y, x]));     
                }
            }

            return image;
        }
        
        private static void FromOnePixelToBitmap(int x, int y, uint pixel, Bitmap image)
        {
            image.SetPixel(y, x, Color.FromArgb((int)pixel));
        }
    }
}