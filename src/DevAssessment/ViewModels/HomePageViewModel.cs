using DevAssessment.Auth;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevAssessment.ViewModel
{
    public class HomePageViewModel : BindableBase, INavigatedAware
    {
        private readonly IEventAggregator _eventAggregator;

        public HomePageViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }


        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            _eventAggregator.GetEvent<UserTypeEvent>().Unsubscribe(ShowUserName);
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            _eventAggregator.GetEvent<UserTypeEvent>().Subscribe(ShowUserName);
        }

        private void ShowUserName(string userName)
        {
            if (!string.IsNullOrEmpty(userName))
                Name = userName;
        }
    }
}

