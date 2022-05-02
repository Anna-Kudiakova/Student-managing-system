using System.Collections.Generic;


namespace CSharp.Lab04.Tools.Navigation
{
    internal abstract class BaseNavigatableViewModel : INavigatableModel
    {
        private readonly IContentOwner _contentOwner;
        private readonly Dictionary<ViewType, INavigatable> _dictionary;

        protected BaseNavigatableViewModel(IContentOwner contentOwner)
        {
            _contentOwner = contentOwner;
            _dictionary = new Dictionary<ViewType, INavigatable>();
        }

        protected IContentOwner ContentOwner
        {
            get { return _contentOwner; }
        }

        protected Dictionary<ViewType, INavigatable> Dictionary
        {
            get { return _dictionary; }
        }

        public void Navigate(ViewType viewType)
        {
            if (Dictionary.ContainsKey(viewType))
            {
                Dictionary.Remove(viewType);
            }
            InitializeView(viewType);
            ContentOwner.ContentControl.Content = Dictionary[viewType];
        }

        protected abstract void InitializeView(ViewType viewType);

    }
}
