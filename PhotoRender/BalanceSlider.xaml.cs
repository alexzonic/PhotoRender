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
        
        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            if ((int)RedColorSlider.Value != 0)
                Saves.SaveChanges(RedColorSlider);
            else if ((int)GreenColorSlider.Value != 0)
                Saves.SaveChanges(GreenColorSlider);
            else
                Saves.SaveChanges(BlueColorSlider);
        }
        
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        
        private void X_Symbol_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
        
        private void Minus_Symbol_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}