using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevCodePOC.ViewModels;
using DevCodePOC.Views;
using Prism.Common;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;
using Xunit;
namespace DevCodePOC.UnitTest
{
    public class Tests
    {
        private TestApp _appInstance;

        public Tests()
        {
            Xamarin.Forms.Mocks.MockForms.Init();
        }

        [Fact]
        public void AppInit()
        {
            _appInstance = new TestApp();

            Assert.NotNull(_appInstance);
        }

        [Fact]
        public void NavigatingFromWithinTabbedPage()
        {
            _appInstance = new TestApp();

            var navigationStack = ((NavigationPage)_appInstance.MainPage).Navigation.NavigationStack;

            //Resolving MyTabbedPage instance   
            var myTabbedPage = (MyTabbedPage)_appInstance.Container.Resolve<MyTabbedPage>();
            myTabbedPage.SendAppearing();

            //  Am I inside the MyTabbedPage
            Assert.IsType<MyTabbedPageViewModel>(navigationStack.Last().BindingContext);

            //  Am I in the MyTabbedPage-> TabChild1Page?
            Assert.IsType<TabChild1PageViewModel>(myTabbedPage.CurrentPage.BindingContext);

            //  Let's Tab-Navigate to TabChild2Page
            _appInstance.Container.Resolve<TabChild1PageViewModel>()
                        .GoToNextTabCommand.Execute("1");

            ////  Am I in the MyTabbedPage-> TabChild2Page?
            Assert.IsType<TabChild2PageViewModel>(myTabbedPage.CurrentPage.BindingContext);

            //  Let's Tab-Navigate to TabChild3Page
            _appInstance.Container.Resolve<TabChild2PageViewModel>()
                        .GoToDetailPageCommand.Execute();

          
        }

        [Fact]
        public void NavigatingFromOutsideTabbedPage()
        {
            _appInstance = new TestApp();

            var navigationStack = ((NavigationPage)_appInstance.MainPage).Navigation.NavigationStack;

           
            //Resolving MyTabbedPage instance   
            var myTabbedPage = (MyTabbedPage)_appInstance.Container.Resolve<MyTabbedPage>();
            myTabbedPage.SendAppearing();

            //  Am I inside the MyTabbedPage?
            Assert.IsType<MyTabbedPageViewModel>(navigationStack.Last().BindingContext);

            //  Am I in the MyTabbedPage-> TabChild1Page?
            Assert.IsType<TabChild1PageViewModel>(myTabbedPage.CurrentPage.BindingContext);

            //  Let's go to DetailPage
            _appInstance.Container.Resolve<TabChild1PageViewModel>()
                        .GoToNextTabCommand.Execute(null);

            //  Am I inside the DetailPage?
            Assert.IsType<DetailPageViewModel>(navigationStack.Last().BindingContext);

            // Let's go back to Tabbed Page -> TabChild1Page
            _appInstance.Container.Resolve<DetailPageViewModel>()
                                        .GoBackToTabChild1PageCommand.Execute();

            //  Am I inside the MyTabbedPage?
            Assert.IsType<MyTabbedPageViewModel>(navigationStack.Last().BindingContext);

         
        }
    }
}
