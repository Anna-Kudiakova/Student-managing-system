using System;

namespace CSharp.Lab04.Tools.Exceptions
{
    internal class UnbornPersonException : Exception
    {
        public UnbornPersonException(DateTime birth) : base($"The date {birth.ToShortDateString()} has not yet arrived. The person has not yet been born.")
        {

        }
    }
}
