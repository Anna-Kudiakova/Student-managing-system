

namespace CSharp.Lab04.Tools.Navigation
{
    internal enum ViewType
    {
        MainScreenView,
        AddPersonView,
        EditPersonView
    }

    interface INavigatableModel
    {
        void Navigate(ViewType viewType);
    }
}
