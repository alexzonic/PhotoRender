using System.Windows;
using System.Windows.Controls;

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
        }
        
        private void GreenColorSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((Slider)sender).SelectionEnd = e.NewValue;
        }
        
        private void BlueColorSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((Slider)sender).SelectionEnd = e.NewValue;
        }
    }
}