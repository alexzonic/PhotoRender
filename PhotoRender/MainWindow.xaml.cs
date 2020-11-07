using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace PhotoRender
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void loadImage_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.OpenFileDialog
            {
                FileName = "",
                Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG;*.JPEG)|*.BMP;*.JPG;*.GIF;*.PNG;*.JPEG|All files (*.*)|*.*"
            };

            if (dlg.ShowDialog() == true)
            {
                originalImage.Source = new BitmapImage(new Uri(dlg.FileName));
            }
        }

        //private void saveImage_Click(object sender, RoutedEventArgs e)
        //{
        //    if(filteredImage != null)
        //    {
        //        var filteredImageBMP = new BitmapImage();
        //        var saveDialog = new SaveFileDialog();
        //        saveDialog.Title = "Сохранить картинку как...";
        //        //отображать ли предупреждение, если пользователь указывает имя уже существующего файла
        //        saveDialog.OverwritePrompt = true;
        //        //отображать ли предупреждение, если пользователь указывает несуществующий путь
        //        saveDialog.CheckPathExists = true;
        //        //список форматов файла, отображаемый в поле "Тип файла"
        //        saveDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG;*.JPEG)|*.BMP;*.JPG;*.GIF;*.PNG;*.JPEG|All files (*.*)|*.*";
        //        if (saveDialog.ShowDialog() == true)
        //        {
        //            try
        //            {
        //                filteredImage.Save(saveDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
        //            }
        //            catch
        //            {
        //                MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
        //                MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }
        //    }

        //}
        //}
    }
}
