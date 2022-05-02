using System.Windows.Controls;

namespace CSharp.Lab04.Tools.Navigation
{
    internal interface IContentOwner
    {
        ContentControl ContentControl { get; }
    }
}
