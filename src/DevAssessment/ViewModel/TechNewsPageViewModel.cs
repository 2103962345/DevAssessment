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

namespace DevAssessment.ViewModel
{
    class TechNewsPageViewModel : BindableBase
    {

        private readonly INewsService _newsService;
        private readonly IDialogService _dialogService;
        private readonly IConnectivity _connectivity;

        public TechNewsPageViewModel(INewsService newsService, IDialogService dialogService, IConnectivity connectivity)
        {
            _newsService = newsService;
            _dialogService = dialogService;
            _connectivity = connectivity;

            _connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;

            LoadNewsList();

            NavigationCommand = new DelegateCommand<Article>(OnNavigationCommandExecuted);
        }

        ~TechNewsPageViewModel()
        {
            _connectivity.ConnectivityChanged -= Connectivity_ConnectivityChanged;
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

        private void OnNavigationCommandExecuted(Article article)
        {
            if (!string.IsNullOrEmpty(article.url))
                _dialogService.DisplayWebView(article.url);
           
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

                TopHeadlines latestNews = await _newsService.GetTopNewsByCategory("us", "technology", "f7cb4296dd7b4311b6c5e099345c71ab");
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
