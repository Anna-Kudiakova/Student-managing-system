using System;

namespace CSharp.Lab04.Tools.Exceptions
{
    internal class IncorrectNameException : Exception
    {
        public IncorrectNameException(string name) : base($"Input name {name} is incorrect. A-Z a-z letters only allowed")
        {

        }
    }
}
