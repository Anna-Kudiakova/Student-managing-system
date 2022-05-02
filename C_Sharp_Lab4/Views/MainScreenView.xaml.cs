using System.Windows.Controls;
using CSharp.Lab04.Tools.Managers;
using CSharp.Lab04.Tools.Navigation;
using CSharp.Lab04.ViewModels;

namespace CSharp.Lab04.Views
{
    public partial class MainScreenView : UserControl, INavigatable
    {

        public MainScreenView()
        {
            InitializeComponent();
            DataContext = new MainScreenViewModel();
            StationManager.PersonDataGrid = TableGrid;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             
        }
    }
}
