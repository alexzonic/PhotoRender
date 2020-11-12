using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static PhotoRender.Filteres.ColorBalance;

namespace PhotoRender
{
    public partial class BalanceSlider : Window
    {
        public BalanceSlider()
        {
            InitializeComponent();
        }

        private void RedColorSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((Slider)sender).SelectionEnd = e.NewValue;
            PointBalance(RedColorSlider, BalanceRed);
        }
        
        private void GreenColorSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((Slider)sender).SelectionEnd = e.NewValue;
            PointBalance(GreenColorSlider, BalanceGreen);
        }
        
        private void BlueColorSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((Slider)sender).SelectionEnd = e.NewValue;
            PointBalance(BlueColorSlider, BalanceBlue);
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}