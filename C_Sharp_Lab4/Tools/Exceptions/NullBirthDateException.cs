using System;

namespace CSharp.Lab04.Tools.Exceptions
{
    internal class NullBirthDateException : Exception
    {
        public NullBirthDateException() : base("Birth date cannot be null!")
        {

        }
    }
}
