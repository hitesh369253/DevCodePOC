using DevCodePOC.Interfaces;
using Prism.Commands;
using Prism.Navigation;
using DevCodePOC.Views;
using Unity;
using DevCodePOC.Models;

namespace DevCodePOC.ViewModels
{
    public class TabChild1PageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IUnityContainer _unityContainer;

        public DelegateCommand OkPressCommand { get; set; }

        public DelegateCommand<string> GoToNextTabCommand { get; set; }

        public TabChild1PageViewModel(INavigationService navigationService, IUnityContainer unityContainer)
            : base(navigationService)
        {
            this._navigationService = navigationService;
            this._unityContainer = unityContainer;

            Title = "TabSlide";
            
            OkPressCommand = new DelegateCommand(DissMissPopupPage);

            GoToNextTabCommand = new DelegateCommand<string>((param) => GoToNextTab(int.Parse(param)));
        }

        private string _entryText;
        public string EntryText
        {
            get => _entryText;
            set
            {
                IsSliderVisible = (!string.IsNullOrWhiteSpace(value));

                SetProperty(ref _entryText, value);
                
            }
        }

        private int sliderValue;
        public int SliderValue
        {
            get => sliderValue;
            set
            {
                sliderValue = value;
                SetProperty(ref sliderValue, value);
            }
        }

        private bool _IsWelcomepopupVisibel;
        public bool IsWelcomepopupVisibel
        {
            get => _IsWelcomepopupVisibel;
            set
            {

                SetProperty(ref _IsWelcomepopupVisibel, value);
            }
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            IsWelcomepopupVisibel = false;
            if (string.IsNullOrEmpty(SavePrefrences.GetValue(Constants.WelcomeMessage_key)))
            {
                IsWelcomepopupVisibel = true;
                SavePrefrences.AddValue(Constants.WelcomeMessage_key, "true");
            }
                
        }

        private bool _isSliderVisible;
        public bool IsSliderVisible
        {
            get => _isSliderVisible;
            set
            {

                SetProperty(ref _isSliderVisible, value);
            }
        }

        private void DissMissPopupPage()
        {
            IsWelcomepopupVisibel = false;
        }

        private void GoToNextTab(int tabIndex)
        {
            _unityContainer.Resolve<IMyTabbedPageSelectedTab>().SetSelectedTab(tabIndex);
        }
    }
}
