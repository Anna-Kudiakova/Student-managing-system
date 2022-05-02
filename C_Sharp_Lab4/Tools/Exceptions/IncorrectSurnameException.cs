using System;

namespace CSharp.Lab04.Tools.Exceptions
{
    internal class IncorrectSurnameException : Exception
    {
        public IncorrectSurnameException(string name) : base($"Input username {name} is incorrect. A-Z a-z letters only allowed")
        {

        }
    }
}
