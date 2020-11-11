using System;

namespace PhotoRender.AstridExceptions
{
    public class OriginalImageDontExistException : Exception
    {
        public OriginalImageDontExistException(string message)
            : base(message)
        { }
    }
    
    public class FilteredlImageDontExistException : Exception
    {
        public FilteredlImageDontExistException(string message)
            : base(message)
        { }
    }
}