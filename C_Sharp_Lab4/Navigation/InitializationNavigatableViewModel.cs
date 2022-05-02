using System;
using CSharp.Lab04.Views;

namespace CSharp.Lab04.Tools.Navigation
{
    internal class InitializationNavigatableViewModel : BaseNavigatableViewModel
    {
        public InitializationNavigatableViewModel(IContentOwner contentOwner) : base(contentOwner)
        {

        }

        protected override void InitializeView(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.MainScreenView:
                    Dictionary.Add(viewType, new MainScreenView());
                    break;
                case ViewType.AddPersonView:
                    Dictionary.Add(viewType, new AddingPersonView());
                    break;
                case ViewType.EditPersonView:
                    Dictionary.Add(viewType, new EditingPersonView());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
            }
        }
    }
}
