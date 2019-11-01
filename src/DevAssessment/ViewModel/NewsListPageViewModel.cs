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
using Common.Resx;
using Prism.AppModel;
using Prism.Navigation;

namespace DevAssessment.ViewModel
{
    public class NewsListPageViewModel : BindableBase, INavigatedAware
    {

        private readonly INewsService _newsService;
        private readonly IDialogService _dialogService;
        private readonly IConnectivity _connectivity;

        public NewsListPageViewModel(INewsService newsService, IDialogService dialogService, IConnectivity connectivity)
        {
            _newsService = newsService;
            _dialogService = dialogService;
            _connectivity = connectivity;
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
            set
            {
                if (SetProperty(ref _isToggled, value))
                {
                    if (NewsItems.Count > 0)
                        foreach (var item in NewsItems)
                            item.ListToggleItem = value;
                };
            }
        }


        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }


        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            _connectivity.ConnectivityChanged -= Connectivity_ConnectivityChanged;
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            _connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
            LoadNewsList();
        }


        void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            if (e.NetworkAccess != NetworkAccess.Internet)
                _dialogService.DisplayAlert(AppResources.ConnectionInternetNotAvailable);
            else
                LoadNewsList();
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
                        _dialogService.DisplayAlert(AppResources.ConnectionPleaseCheckInternet);
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

