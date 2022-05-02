using System;

namespace CSharp.Lab04.Tools.Exceptions
{
    internal class OveragedPersonException : Exception
    {

        public OveragedPersonException(DateTime birth) : base($"The person with birth date [{birth.ToShortDateString()}] is more than 135 years")
        {

        }
    }
}
