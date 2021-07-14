using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using DevCodePOC.Views;
using Prism.Commands;
using Prism;
using Prism.Services;
using DevCodePOC.Interfaces;
using Unity;
using DevCodePOC.Models;
using Xamarin.Essentials;

namespace DevCodePOC.ViewModels
{
    public class DetailPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IMyTabbedPageSelectedTab _myTabbedPageSelectedTab;

        public DelegateCommand GoBackToTabChild1PageCommand { get; set; }



        public DetailPageViewModel(INavigationService navigationService, IUnityContainer unityContainer)
            : base(navigationService)
        {
            this._navigationService = navigationService;
            

            this._myTabbedPageSelectedTab = unityContainer.Resolve<IMyTabbedPageSelectedTab>();

            Title = "Detail Page";

            GoBackToTabChild1PageCommand = new DelegateCommand(GoBackToTabChild1Page);

           
        }

        private string _essentialsDetails;

        public string EssentialsDetails
        {
            get => _essentialsDetails;
            set
            {
                SetProperty(ref _essentialsDetails, value);
            }
        }


        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters != null)
            {
              string EssentialID = parameters.GetValue<string>("EssentialID");

                try
                {
                    switch (Convert.ToInt32(EssentialID))
                    {
                        case 1:
                            EssentialsDetails = $"Connectivity Status: { Connectivity.NetworkAccess}";
                            break;
                        case 2:
                            EssentialsDetails = $"Device Info: \n Model: { DeviceInfo.Model}. \n Manufacturer:  {DeviceInfo.Manufacturer}. \n Device Name: {DeviceInfo.Name} \n Platform: {DeviceInfo.Platform}";
                            break;
                        case 3:
                            // Get Metrics
                            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
                            EssentialsDetails = $"Display Info: \n Metrics: { mainDisplayInfo}. \n Orientation: {mainDisplayInfo.Orientation}. \n Rotation: {mainDisplayInfo.Rotation} \n Width:{mainDisplayInfo.Width} \n Height: {mainDisplayInfo.Height} \n  Screen density: {mainDisplayInfo.Density}";
                            break;
                    }
                }
                catch(Exception ex)
                {

                }
            }
        }

        

        private void GoBackToTabChild1Page()
        {
            _myTabbedPageSelectedTab.SetSelectedTab(1);
            _navigationService.GoBackAsync();
        }

       
    }
}
