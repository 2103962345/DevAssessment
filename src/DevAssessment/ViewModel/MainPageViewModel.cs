using DevAssessment.Auth;
using DevAssessment.Models;
using DevAssessment.Services;
using DevAssessment.Views;
using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DevAssessment.ViewModel
{
    public class MainPageViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;
        private readonly IMenuService _menuService;

        public MainPageViewModel(INavigationService navigationService, IMenuService menuService)
        {
            _navigationService = navigationService;
            _menuService = menuService;
            var categoryList = _menuService.Items.ToList();

            Items = new List<Item>(categoryList);

            NavigationCommand = new DelegateCommand<Item>(OnNavigationCommandExecuted);
        }

        public List<Item> Items { get; set; }

        public DelegateCommand<Item> NavigationCommand { get; }

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
    }
}
