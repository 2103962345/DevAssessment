using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevAssessment.ViewModel
{
    public class NewsCategoriesViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;
        public NewsCategoriesViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            NavigateCommandClicked = new DelegateCommand<string>(NavigateToPage);
           
        }


        public DelegateCommand<string> NavigateCommandClicked { get; set; }
        

        private async void NavigateToPage(string newsCategory)
        {
            var navigationParams = new NavigationParameters();
            navigationParams.Add("NewsCategory", newsCategory);
            await _navigationService.NavigateAsync("TechNewsPage",navigationParams);
        }
    }
}
