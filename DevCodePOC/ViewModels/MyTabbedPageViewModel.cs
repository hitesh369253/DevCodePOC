using DevCodePOC.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity;
using Unity.Lifetime;

namespace DevCodePOC.ViewModels
{
    public class MyTabbedPageViewModel : ViewModelBase, IMyTabbedPageSelectedTab
    {
        private readonly IUnityContainer _unityContainer;

        private int _selectedTab;
        /// <summary>
        /// Binds to the View's property
        /// View-ViewModel communcation
        /// </summary>
        public int SelectedTab
        {
            get { return _selectedTab; }
            set
            {
                SetProperty(ref _selectedTab, value);
                Title = $"Dev Code Challenge";
            }
        }
        
        public MyTabbedPageViewModel(INavigationService navigationService, IUnityContainer unityContainer)
            : base(navigationService)
        {
            Title = $"Dev Code Challenge";

            this._unityContainer = unityContainer;

            // register this instance so we can access 
            // IMyTabbedPageSelectedTab anywhere in the code
            _unityContainer.RegisterInstance<IMyTabbedPageSelectedTab>(this, new ContainerControlledLifetimeManager());
        }

        public void SetSelectedTab(int tabIndex)
        {
            SelectedTab = tabIndex;
        }
    }
}
