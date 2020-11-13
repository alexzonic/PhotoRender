using System.IO;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using PhotoRender.AstridExceptions;

namespace PhotoRender
{
    public static class Saves
    {
        public static void SaveImage(Image image)
        {
            if (image.Source == null)
                throw new FilteredlImageDontExistException();
            var saveDialog = new SaveFileDialog
            {
                Title = "Сохранить картинку как...",
                OverwritePrompt = true,
                CheckPathExists = true,
                Filter =
                    "Image Files(*.BMP;*.JPG;*.GIF;*.PNG;*.JPEG)|*.BMP;*.JPG;*.GIF;*.PNG;*.JPEG|All files (*.*)|*.*",
                InitialDirectory = @"c:\temp\",
                DefaultExt = ".png",
            };
            if (saveDialog.ShowDialog() == true)
            {
                var encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create((BitmapSource)image.Source));
                using (var stream = new FileStream(saveDialog.FileName, FileMode.Create))
                    encoder.Save(stream);
            }
        }
    }
}