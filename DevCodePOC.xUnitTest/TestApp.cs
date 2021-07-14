﻿using System;
using DevCodePOC.ViewModels;
using DevCodePOC.Views;
using Prism;
using Prism.Common;
using Prism.Ioc;
using Prism.Navigation;
using Prism.Unity;
using Unity;
using Xamarin.Forms;
namespace DevCodePOC.UnitTest
{
    public partial class TestApp : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public TestApp() : this(null) { }

        public TestApp(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            Xamarin.Forms.Mocks.MockForms.Init();

            Container.GetContainer().RegisterInstance<INavigationService>(NavigationService, new Unity.Lifetime.SingletonLifetimeManager());

            await NavigationService.NavigateAsync("NavigationPage/MyTabbedPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MyTabbedPage>();
            containerRegistry.RegisterForNavigation<TabChild1Page>();
            containerRegistry.RegisterForNavigation<TabChild2Page>();
            containerRegistry.RegisterForNavigation<DetailPage>();

            containerRegistry.GetContainer().RegisterType<MyTabbedPageViewModel>(new Unity.Lifetime.ContainerControlledLifetimeManager());
            containerRegistry.GetContainer().RegisterType<TabChild1PageViewModel>(new Unity.Lifetime.ContainerControlledLifetimeManager());
            containerRegistry.GetContainer().RegisterType<TabChild2PageViewModel>(new Unity.Lifetime.ContainerControlledLifetimeManager());
            containerRegistry.GetContainer().RegisterType<DetailPageViewModel>(new Unity.Lifetime.ContainerControlledLifetimeManager());
        }
    }
}
