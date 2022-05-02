using System.Windows;
using System.Windows.Controls;
using CSharp.Lab04.Tools.DataStorage;
using CSharp.Lab04.Tools.Managers;
using CSharp.Lab04.Tools.Navigation;
using CSharp.Lab04.ViewModels;

namespace CSharp.Lab04
{
    public partial class MainWindow : Window, IContentOwner
    {
        public ContentControl ContentControl
        {
            get { return _contentControl; }
        }


        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            StationManager.Initialize(new SerializedDataStorage());
            NavigatableManager.Instance.Initialize(new InitializationNavigatableViewModel(this));
            NavigatableManager.Instance.Navigate(ViewType.MainScreenView);

        }
    }
}
