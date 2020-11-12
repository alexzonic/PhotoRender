using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using PhotoRender.Filteres;
using PhotoRender.AstridExceptions;
using static PhotoRender.Filteres.Palette;

namespace PhotoRender
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow
        {
            
            public MainWindow()
            {
                InitializeComponent();
            }

            private void loadImage_Click(object sender, RoutedEventArgs e)
            {
                var dlg = new OpenFileDialog
                {
                    FileName = "",
                    Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG;*.JPEG)|*.BMP;*.JPG;*.GIF;*.PNG;*.JPEG|All files (*.*)|*.*"
                };

                if (dlg.ShowDialog() == true)
                {
                    originalImage.Source = new BitmapImage(new Uri(dlg.FileName));
                    filteredImage.Source = null;
                }
            }

            private void Grayscale_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    var bitmap = GrayScale.ToGrayscale(originalImage);

                    filteredImage.Source = AstridBitmap.GetBitmapSource(bitmap);
                }
                catch (OriginalImageDontExistException exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }

            private void SobelFilter_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    var bitmap = SobelFilter.ToSobelFilter(originalImage);

                    filteredImage.Source = AstridBitmap.GetBitmapSource(bitmap);
                }
                catch (OriginalImageDontExistException exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }

            private void Negativ_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    var filtredPixels = Negativ.NegativFiltred(originalImage);
                    filteredImage.Source = AstridBitmap.GetBitmapSource(filtredPixels);
                }
                catch (AstridExceptions.OriginalImageDontExistException exception)
                {
                    MessageBox.Show(exception.Message);
                }
        }
            private void Bright_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    BmpImage = AstridBitmap.ImageToBitmap(originalImage);
                    PixelsArr = BitmapPixels(BmpImage);
                    FilteredImage = filteredImage;
                    var slider = new AstridSlider();
                    slider.Show();
                }
                catch (OriginalImageDontExistException exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }

            private void Balance_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    BmpImage = AstridBitmap.ImageToBitmap(originalImage);
                    PixelsArr = BitmapPixels(BmpImage);
                    FilteredImage = filteredImage;
                    var slider = new BalanceSlider();
                    slider.Show();
                }
                catch (OriginalImageDontExistException exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
            
            private void saveImage_Click(object sender, RoutedEventArgs e)
            {

                var saveDialog = new SaveFileDialog();
                saveDialog.Title = "Сохранить картинку как...";
                //отображать ли предупреждение, если пользователь указывает имя уже существующего файла
                saveDialog.OverwritePrompt = true;
                //отображать ли предупреждение, если пользователь указывает несуществующий путь
                saveDialog.CheckPathExists = true;
                //список форматов файла, отображаемый в поле "Тип файла"
                saveDialog.Filter =
                    "Image Files(*.BMP;*.JPG;*.GIF;*.PNG;*.JPEG)|*.BMP;*.JPG;*.GIF;*.PNG;*.JPEG|All files (*.*)|*.*";
                saveDialog.InitialDirectory = @"c:\temp\"; //каталог по умолчанию
                if (saveDialog.ShowDialog() == true)
                {
                    var jpegBitmapEncoder = new JpegBitmapEncoder();
                    jpegBitmapEncoder.Frames.Add(BitmapFrame.Create(filteredImage.Source as BitmapSource));
                    //jpegBitmapEncoder.Save(saveDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg); //saveDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    using (FileStream stream = new FileStream(saveDialog.FileName, FileMode.Create))
                        jpegBitmapEncoder.Save(stream);
                }
            }
            /*private void saveImage_Click(object sender, RoutedEventArgs e)
            { 
                if(filteredImage != null)
                {
                   var filteredImageBMP = new BmpImage();
                    var saveDialog = new SaveFileDialog();
                    saveDialog.Title = "Сохранить картинку как...";
                    //отображать ли предупреждение, если пользователь указывает имя уже существующего файла
                    saveDialog.OverwritePrompt = true;
                    //отображать ли предупреждение, если пользователь указывает несуществующий путь
                    saveDialog.CheckPathExists = true;
                    //список форматов файла, отображаемый в поле "Тип файла"
                    saveDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG;*.JPEG)|*.BMP;*.JPG;*.GIF;*.PNG;*.JPEG|All files (*.*)|*.*";
                    if (saveDialog.ShowDialog() == true)
                    {
                        try
                        {
                            filteredImage.Save(saveDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        }
                        catch
                        {
                            MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }*/

        }
}


// может пригодиится
/*private Bitmap BitmapImage2Bitmap(BmpImage bitmapImage)
{
    using (var str = new MemoryStream())
    {
        var enc = new BmpBitmapEncoder();
        enc.Frames.Add(BitmapFrame.Create(bitmapImage));
        enc.Save(str);
        var bitmap = new Bitmap(str);

        return new Bitmap(bitmap);
    }
}*/

/*var bitmap = new WriteableBitmap(
                (int)originalImage.ActualWidth,
                (int)originalImage.ActualHeight,
                96,
                96,
                PixelFormats.Bgr32,
                null);
*/
/*
            int stride = (bitmap.PixelWidth * bitmap.Format.BitsPerPixel + 7) / 8;
            byte[] pixels = new byte[bitmap.PixelHeight * stride];
            bitmap.CopyPixels(pixels, stride, 0);
*/


/*byte[] arr;
using (var ms = new MemoryStream())
{
    var bmp = originalImage.FilteredImage as BmpImage;
    JpegBitmapEncoder enc = new JpegBitmapEncoder();
    enc.Frames.Add(BitmapFrame.Create(bmp));
    enc.Save(ms);
    arr = ms.ToArray();
    ms.Dispose();
}*/

/*
         // надо затестить p.s. нихуя не работает
        private BmpImage GetLink(BitmapSource source)
        {
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            MemoryStream memoryStream = new MemoryStream();
            BmpImage bImg = new BmpImage();

            encoder.Frames.Add(BitmapFrame.Create(source));
            encoder.Save(memoryStream);

            memoryStream.Position = 0;
            bImg.BeginInit();
            bImg.StreamSource = memoryStream;
            bImg.EndInit();

            memoryStream.Close();

            return bImg;
        }
 */

/*static class Extent
{
    public static byte[] ToByteArray(this WriteableBitmap bmp)
    {
        var size = bmp.PixelWidth * bmp.PixelHeight;
        var arr = new int[size];
        bmp.CopyPixels(arr, 1, 0);
        int len = arr.Length * 4;
        byte[] result = new byte[len]; // ARGB
        Buffer.BlockCopy(arr, 0, result, 0, len);
        return result;
    }
}*/


/*using (ms)
{
    BmpImage bi = new BmpImage();
    bi.BeginInit();
    bi.StreamSource = ms;
    bi.EndInit();

    filteredImage.FilteredImage = bi;
}*/
/*
            var res = new BmpImage();
            res.BeginInit();
            ms.Seek(0, SeekOrigin.Begin);
            res.StreamSource = ms;
            res.EndInit();

            filteredImage.FilteredImage = res;*/

//var qqq = GrayScale.ToGrayscale(pixels);
/*
            var w = arr.GetLength(0);
            var h = arr.GetLength(1);

            byte[,] pp = new byte[w, h];
            for(int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    pp[i, j] = arr[i, j];
               }
            } */

//Convert.ToBitmap(pixels).Save(new MemoryStream(), System.Drawing.Imaging.ImageFormat.Jpeg);

/*            BmpImage res = new BmpImage();
            res.BeginInit();
            res.UriSource = new Uri(originalImage.FilteredImage.ToString());
            res.EndInit();
            filteredImage.FilteredImage = res;*/

//filteredImage.FilteredImage = BitmapFrame.Create(new MemoryStream(pixels), BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
