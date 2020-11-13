using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using PhotoRender.Filteres;

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

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            Saves.SaveChanges((int) brightSlider.Value != 0 ? brightSlider : contrastSlider);
        }
        
        private void X_Symbol_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
               DragMove();
        }

        private void Minus_Symbol_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}