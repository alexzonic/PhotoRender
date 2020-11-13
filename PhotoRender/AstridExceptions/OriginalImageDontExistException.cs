using System;

namespace PhotoRender.AstridExceptions
{
    public class OriginalImageDontExistException : Exception
    {
        public OriginalImageDontExistException(string message = "фото не найдено")
            : base(message)
        { }
    }
    
    public class FilteredlImageDontExistException : Exception
    {
        public FilteredlImageDontExistException(string message = "фото не найдено")
            : base(message)
        { }
    }
}