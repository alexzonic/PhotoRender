using System;
using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace PhotoRender
{
    public partial class NewWindow : Window
    {
        public NewWindow()
        {
            InitializeComponent();
        }

        private void LoadImage_Click(object sender, RoutedEventArgs e)
        {
            //var dlg = new OpenFileDialog
            //{
            //    FileName = "",
            //    Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG;*.JPEG)|*.BMP;*.JPG;*.GIF;*.PNG;*.JPEG|All files (*.*)|*.*"
            //};
            //if (dlg.ShowDialog() == true)
            //{
            //    image.Source = new BitmapImage(new Uri(dlg.FileName));
            //}
            
        }

        private void SaveImage_Click(object sender, RoutedEventArgs e)
        {
        
        }
    }
}