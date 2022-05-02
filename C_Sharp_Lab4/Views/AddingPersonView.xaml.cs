using System.Windows.Controls;
using CSharp.Lab04.Tools.Navigation;
using CSharp.Lab04.ViewModels;

namespace CSharp.Lab04.Views
{
    public partial class AddingPersonView : UserControl, INavigatable
    {
        public AddingPersonView()
        {
            InitializeComponent();
            DataContext = new AddPersonViewModel();
        }

    }
}
