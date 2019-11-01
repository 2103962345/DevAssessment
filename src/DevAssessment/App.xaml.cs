using DevAssesment.Admin;
using DevAssessment.Auth;
using DevAssessment.CustomDialogs;
using DevAssessment.Services;
using DevAssessment.ViewModel;
using DevAssessment.Views;
using DryIoc;
using Prism;
using Prism.DryIoc.Extensions;
using Prism.Ioc;
using Prism.Logging;
using Prism.Modularity;
using System;
using Xamarin.Forms;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;



namespace DevAssessment
{

    public partial class App
    {
        public App() : this(null) { }
        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override IContainerExtension CreateContainerExtension()
        {
            return base.CreateContainerExtension();
        }

        protected override async void OnInitialized()
        {


            InitializeComponent();

            if (Current.Properties.ContainsKey(Constants.JwtToken) && Current.Properties.ContainsKey(Constants.JwtTokenValidTime) 
                && (DateTime)Current.Properties[Constants.JwtTokenValidTime] > DateTime.Now)
                await NavigationService.NavigateAsync("MainPage/NavigationPage/HomePage");
            else
                await NavigationService.NavigateAsync("LoginPage");

        }


        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<ContactUsPage>();
            containerRegistry.RegisterForNavigation<AboutPage>();
            containerRegistry.RegisterForNavigation<LogOutPage>();
            containerRegistry.RegisterForNavigation<DSPage, DSPageViewModel>();
            containerRegistry.RegisterForNavigation<NewsListPage, NewsListPageViewModel>();
            containerRegistry.RegisterForNavigation<NewsCategoriesPage, NewsCategoriesViewModel>();
            containerRegistry.RegisterForNavigation<TechNewsPage, TechNewsPageViewModel>();
          

            containerRegistry.RegisterDialog<AlertDialog, AlertDialogViewModel>();
            containerRegistry.RegisterDialog<LogDialog, LogDialogViewModel>();
            containerRegistry.RegisterDialog<WebViewPageDialog, WebViewPageDialogViewModel>();

            containerRegistry.Register<ILogger, ConsoleLoggingService>();


            containerRegistry.RegisterSingleton<IMenuService, MenuService>();
            containerRegistry.RegisterSingleton<INewsService, NewsService>();


           
            containerRegistry.Register<IConnectivity, ConnectivityImplementation>();

        }


        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<AuthenticationModule>();
            moduleCatalog.AddModule<AdminModule>(InitializationMode.OnDemand);
        }

        //public App()
        //{
        //    InitializeComponent();

        //    MainPage = new LoginPage();
        //}

        //protected override void OnStart()
        //{
        //    // Handle when your app starts
        //}

        //protected override void OnSleep()
        //{
        //    // Handle when your app sleeps
        //}

        //protected override void OnResume()
        //{
        //    // Handle when your app resumes
        //}
    }
}
