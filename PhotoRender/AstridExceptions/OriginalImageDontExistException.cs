using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace PhotoRender.AstridExceptions
{
    public class OriginalImageDontExistException : Exception
    {
        public OriginalImageDontExistException(string message)
            : base(message)
        { }
    }
}