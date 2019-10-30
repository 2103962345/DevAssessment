using Common.Resx;
using DevAssessment.Auth;
using DevAssessment.DialogExtentions;
using Prism.Commands;
using Prism.Events;
using Prism.Logging;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services.Dialogs;
using System;
using System.Threading.Tasks;

namespace DevAssessment.ViewModel
{
    public class HomePageViewModel : BindableBase, INavigatedAware
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IDialogService _dialogService;
       

        public HomePageViewModel(IEventAggregator eventAggregator, IDialogService dialogService)
        {
            _eventAggregator = eventAggregator;
            _dialogService = dialogService;

            CustomDialogCommand = new DelegateCommand(CustomDialogClicked);
            ErrorDialogCommand = new DelegateCommand(ErrorDialogClicked);
        }




        public DelegateCommand CustomDialogCommand { get; set; }

        public DelegateCommand ErrorDialogCommand { get; set; }
        private string _name;

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }


        private void CustomDialogClicked()
        {
            _dialogService.DisplayAlert(AppResources.CustomAlertDialogMessage);
        }

        private void ErrorDialogClicked()
        {
            Exception ex = new Exception(); //null reference exception,,

            _dialogService.DisplayError(ex);
        }


        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            _eventAggregator.GetEvent<UserTypeEvent>().Unsubscribe(ShowUserName);
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            _eventAggregator.GetEvent<UserTypeEvent>().Subscribe(ShowUserName);
        }

        public void ShowUserName(string userName)
        {
            if (!string.IsNullOrEmpty(userName))
                Name = userName;
        }
    }
}

