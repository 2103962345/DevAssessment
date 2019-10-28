using DevAssesment.Admin;
using DevAssessment.Auth;
using DevAssessment.Auth.ViewModels;
using DevAssessment.Auth.Views;
using DevAssessment.Services;
using DevAssessment.ViewModel;
using DevAssessment.Views;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Logging;
using Prism.Modularity;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace DevAssessment
{

    public partial class App
    {
        public App() : this(null) { }
        public App(IPlatformInitializer initializer) : base(initializer) { }

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
            containerRegistry.RegisterSingleton<IMenuService, MenuService>();
            containerRegistry.RegisterForNavigation<ContactUsPage>();
            containerRegistry.RegisterForNavigation<AboutPage>();
            containerRegistry.RegisterForNavigation<LogOutPage>();
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
