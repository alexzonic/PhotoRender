using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using Image = System.Windows.Controls.Image;

namespace PhotoRender
{
    public partial class BrightSlider
    {
        private readonly Bitmap _originBitmap; 
        private static Image _originalImg;

        public BrightSlider(Image img, Bitmap bimap)
        {
            _originalImg = img;
            _originBitmap = bimap;
            InitializeComponent();
        }

        private void Slider_ValueChanger(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((Slider)sender).SelectionEnd=e.NewValue;
            AstridBitmap.ChangeBrightnessForTick(_originBitmap, _originalImg, myslider);
        }

        private void Image_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}