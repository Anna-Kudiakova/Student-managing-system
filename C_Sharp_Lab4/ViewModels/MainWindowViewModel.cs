using System.Windows;
using CSharp.Lab04.Tools;
using CSharp.Lab04.Tools.Managers;

namespace CSharp.Lab04.ViewModels
{
    internal class MainWindowViewModel : BaseViewModel, ILoaderOwner
    {

        private Visibility _loaderVisibility = Visibility.Hidden;
        private bool _isControlEnabled = true;
      

        public Visibility LoaderVisibility
        {
            get { return _loaderVisibility; }
            set
            {

                _loaderVisibility = value;
                OnPropertyChanged();
            }
        }
        public bool IsControlEnabled
        {
            get { return _isControlEnabled; }
            set
            {
                _isControlEnabled = value;
                OnPropertyChanged();
            }
        }

        internal MainWindowViewModel()
        {
            LoaderManager.Instance.Initialize(this);
        }
    }
}
