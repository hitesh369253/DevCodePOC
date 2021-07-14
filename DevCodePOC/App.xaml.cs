using Prism;
using Prism.Ioc;
using DevCodePOC.ViewModels;
using DevCodePOC.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Unity;
using DevCodePOC.Interfaces;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DevCodePOC
{
    public partial class App : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync(Constants.MainNavigation);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MyTabbedPage>();
            containerRegistry.RegisterForNavigation<TabChild1Page>();
            containerRegistry.RegisterForNavigation<TabChild2Page>();
            containerRegistry.RegisterForNavigation<DetailPage>();
        }

       
    }
}
