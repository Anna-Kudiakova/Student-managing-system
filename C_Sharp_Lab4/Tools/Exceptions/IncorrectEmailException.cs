using System;

namespace CSharp.Lab04.Tools.Exceptions
{
    internal class IncorrectEmailException : Exception
    {
        public IncorrectEmailException(string email) : base($"Input email [{email}] is incorrect")
        {

        }
    }
}
