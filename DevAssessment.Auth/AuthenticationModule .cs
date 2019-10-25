using DevAssessment.Auth.MockServices;
using DevAssessment.Auth.ViewModels;
using DevAssessment.Auth.Views;
using Prism.Ioc;
using Prism.Modularity;
using System;

namespace DevAssessment.Auth
{
    public class AuthenticationModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.Register<ILoginManager,LoginManager>();
            containerRegistry.Register<IJwtAuthService,JwtAuthService>();
        }
    }
}
