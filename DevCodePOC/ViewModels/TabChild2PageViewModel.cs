using DevCodePOC.Interfaces;
using Prism.Commands;
using Prism.Navigation;
using DevCodePOC.Views;
using Unity;
using System.Collections.Generic;
using DevCodePOC.Models;

namespace DevCodePOC.ViewModels
{
    public class TabChild2PageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public DelegateCommand GoToDetailPageCommand { get; set; }



        public TabChild2PageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            this._navigationService = navigationService;

            Title = "Information";

            EssentialItems = new List<Essential>() { new Essential() { Text = "Connectivity", Description="To check connectivity status", Id = 1},
            new Essential() {Text = "Device Info", Description="To check device details", Id = 2},
                new Essential() {Text = "Display Info", Description = "To see display details", Id = 3}};

            SelectedEssential = EssentialItems[0];

            GoToDetailPageCommand = new DelegateCommand(GoToDetailPage);


        }
        private IList<Essential> _essentialItems;
        public IList<Essential> EssentialItems
        {
            get => _essentialItems;
            set
            {
                _essentialItems = value;
                RaisePropertyChanged(nameof(EssentialItems));
            }
        }

        Essential selectedEssential;
        public Essential SelectedEssential
        {
            get { return selectedEssential; }
            set
            {
                if (selectedEssential != value)
                {
                    selectedEssential = value;
                    RaisePropertyChanged(nameof(SelectedEssential));
                }
            }
        }

        private async void GoToDetailPage()
        {
            NavigationParameters param = new NavigationParameters();
            param.Add("EssentialID", selectedEssential.Id);
            await _navigationService.NavigateAsync(nameof(DetailPage), param);
        }

       
    }
}
