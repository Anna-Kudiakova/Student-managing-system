using System.Windows.Controls;
using CSharp.Lab04.Tools.Navigation;
using CSharp.Lab04.ViewModels;

namespace CSharp.Lab04.Views
{
    public partial class EditingPersonView : UserControl, INavigatable
    {
        public EditingPersonView()
        {
            InitializeComponent();
            DataContext = new EditPersonViewModel();
        }

   
       
    }
}
