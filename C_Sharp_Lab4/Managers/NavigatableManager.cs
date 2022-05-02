using CSharp.Lab04.Tools.Navigation;

namespace CSharp.Lab04.Tools.Managers
{
    internal class NavigatableManager
    {
        private static readonly object Locker = new object();
        private static NavigatableManager _instance;

        internal static NavigatableManager Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;
                lock (Locker)
                {
                    return _instance ?? (_instance = new NavigatableManager());
                }
            }
        }

        private INavigatableModel _navigatableModel;

        private NavigatableManager()
        {

        }

        internal void Initialize(INavigatableModel navigatableModel)
        {
            _navigatableModel = navigatableModel;
        }

        internal void Navigate(ViewType viewType)
        {
            _navigatableModel.Navigate(viewType);

        }

    }
}
