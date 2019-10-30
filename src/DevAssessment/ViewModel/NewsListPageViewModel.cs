using DevAssessment.DialogExtentions;
using DevAssessment.Models;
using DevAssessment.Services;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Essentials.Interfaces;

namespace DevAssessment.ViewModel
{
    public class NewsListPageViewModel : BindableBase
    {

        private readonly INewsService _newsService;
        private readonly IDialogService _dialogService;
        private readonly IConnectivity _connectivity;

        public NewsListPageViewModel(INewsService newsService, IDialogService dialogService, IConnectivity connectivity)
        {
            _newsService = newsService;
            _dialogService = dialogService;
            _connectivity = connectivity;

            _connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;

            LoadNewsList();

        }

        ~NewsListPageViewModel()
        {
            _connectivity.ConnectivityChanged -= Connectivity_ConnectivityChanged;
        }


        void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            if (e.NetworkAccess != NetworkAccess.Internet)
                _dialogService.DisplayAlert("You don't have any internet connection.");
            else
            {
                _dialogService.DisplayAlert("Internet connection is available now.");

                LoadNewsList();
            }
        }



        private ObservableCollection<Source> _newsItems;
        public ObservableCollection<Source> NewsItems
        {
            get { return _newsItems; }
            set { SetProperty(ref _newsItems, value); }
        }



        private bool _isToggled;
        public bool IsToggled
        {
            get { return _isToggled; }
            set { SetProperty(ref _isToggled, value); }
        }


        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }


        private async void LoadNewsList()
        {
            try
            {
                IsBusy = true;

                if (_connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        _dialogService.DisplayAlert("Please check your internet connection.");
                    });
                    
                    return;
                }

                LatestNews latestNews = await _newsService.GetLatestNews();
                NewsItems = new ObservableCollection<Source>(latestNews.sources);

            }
            catch (Exception ex)
            {
                _dialogService.DisplayError(ex);
            }
            finally
            {
                IsBusy = false;
            }

        }
    }
}

