using DevAssessment.DialogExtentions;
using DevAssessment.Models;
using DevAssessment.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Essentials.Interfaces;
using Prism.Navigation;
using Prism.AppModel;
using Common.Resx;

namespace DevAssessment.ViewModel
{
    class TechNewsPageViewModel : BindableBase , INavigatedAware
    {

        private readonly INewsService _newsService;
        private readonly IDialogService _dialogService;
        private readonly IConnectivity _connectivity;
        private string newsCategory = "";

        public TechNewsPageViewModel(INewsService newsService, IDialogService dialogService, IConnectivity connectivity)
        {
            _newsService = newsService;
            _dialogService = dialogService;
            _connectivity = connectivity;

            NavigationCommand = new DelegateCommand<Article>(OnNavigationCommandExecuted);
            
        }

       
        public DelegateCommand<Article> NavigationCommand { get; }


        private ObservableCollection<Article> _technologyNews;
        public ObservableCollection<Article> TechnologyNews
        {
            get { return _technologyNews; }
            set { SetProperty(ref _technologyNews, value); }
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

            if (parameters.ContainsKey("NewsCategory"))
            {
                newsCategory = parameters.GetValue<string>("NewsCategory");
                LoadNewsList();
            }
        }

        void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            if (e.NetworkAccess != NetworkAccess.Internet)
                _dialogService.DisplayAlert(AppResources.ConnectionInternetNotAvailable);
            else
                LoadNewsList();

        }

        private void OnNavigationCommandExecuted(Article article)
        {
            if (!string.IsNullOrEmpty(article.url))
                _dialogService.DisplayWebView(article.url);

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

                TopHeadlines latestNews = await _newsService.GetTopNewsByCategory("us", newsCategory, "f7cb4296dd7b4311b6c5e099345c71ab");
                TechnologyNews = new ObservableCollection<Article>(latestNews.articles);

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
