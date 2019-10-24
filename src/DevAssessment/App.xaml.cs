using System;
using Xamarin.Forms;
using DevAssessment.Views;
using Prism;
using Prism.Ioc;
using DevAssessment.ViewModels;

namespace DevAssessment
{

    //Updated the App.xaml.cs file to use Prism

    public partial class App
    {
        public App() : this(null) { }
        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {


            InitializeComponent();

            await NavigationService.NavigateAsync("MainPage");

       }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
        }
    }
}
