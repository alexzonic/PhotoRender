using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using PhotoRender.Filteres;
using Image = System.Windows.Controls.Image;

namespace PhotoRender
{
    public partial class AstridSlider
    {
        public AstridSlider()
        {
            InitializeComponent();
        }

        private void Bright_ValueChanger(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((Slider)sender).SelectionEnd = e.NewValue;
            BrightnessContrast.ChangeBrightnessForTick(brightSlider);
        }

        private void Contrast_ValueChanger(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((Slider)sender).SelectionEnd = e.NewValue;
            BrightnessContrast.ChangeContrastForTick(contrastSlider);
        }

        private void X_Symbol_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void Minus_Symbol_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}