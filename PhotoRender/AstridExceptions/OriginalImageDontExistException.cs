using System;

namespace PhotoRender.AstridExceptions
{
    public class OriginalImageDontExistException : Exception
    {
        public OriginalImageDontExistException(string message)
            : base(message)
        { }
    }
}