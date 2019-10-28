using DevAssesment.Admin.Views;
using Prism.Ioc;
using Prism.Modularity;
using System;

namespace DevAssesment.Admin
{
    public class AdminModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
           
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<AdminPage>();
        }
    }
}
