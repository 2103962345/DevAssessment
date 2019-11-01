using DevAssessment.Auth;
using DevAssessment.Models;
using DevAssessment.Services;
using DevAssessment.Views;
using Prism.AppModel;
using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DevAssessment.ViewModel
{
    public class MainPageViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;
        private readonly IMenuService _menuService;
        private readonly IModuleManager _moduleManager;
        private readonly IModuleCatalog _moduleCatalog;

        public MainPageViewModel(INavigationService navigationService, IMenuService menuService, 
            IModuleManager moduleManager, IModuleCatalog moduleCatalog)
        {

            _navigationService = navigationService;
            _menuService = menuService;
            _moduleManager = moduleManager;
            _moduleCatalog = moduleCatalog;

            NavigationCommand = new DelegateCommand<Item>(OnNavigationCommandExecuted);

            GetListOfMenus();
        }



        public DelegateCommand<Item> NavigationCommand { get; }

        private ObservableCollection<Item> _items;
        public ObservableCollection<Item> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }


        private async void OnNavigationCommandExecuted(Item item)
        {
            if (item.Uri == nameof(LogOutPage))
            {
                //clearing the navigation stack and go to login page.
                await _navigationService.NavigateAsync($"/NavigationPage/LoginPage");

                Application.Current.Properties.Remove(Constants.JwtToken);
                await Application.Current.SavePropertiesAsync();
            }
            else
                await _navigationService.NavigateAsync($"NavigationPage/{item.Uri}");
        }
       
        private void GetListOfMenus()
        {
            try
            {
                var itemsList = _menuService.Items;

                if (Application.Current.Properties.ContainsKey(Constants.IsAdmin) && (bool)Application.Current.Properties[Constants.IsAdmin])
                {
                    _moduleManager.LoadModule("AdminModule");
                    var adminModule = _moduleCatalog.Modules.Where(m => m.ModuleName == "AdminModule").SingleOrDefault();
                    if(adminModule != null)
                    {
                        var adminModuleAttr = Type.GetType(adminModule.ModuleType).Assembly.GetCustomAttributes<HelpersLibrary.MenuItemAttribute>();
                        itemsList.AddRange(adminModuleAttr.Select(x => new Item()
                        {
                            Name = x.DisplayName,
                            Uri = x.NavigationName
                        }).ToList());
                    }
                }

                if (itemsList.Count > 0)
                    Items = new ObservableCollection<Item>(itemsList.OrderBy(o => o.Name));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Menu Exception : " + ex.Message);
            }
        }
     
      
    }
}
