using Common.Resx;
using HelpersLibrary;
using DevAssessment.Views;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: MenuItem(nameof(AppResources.MenuNameNewsCategoryList), nameof(NewsCategoriesPage))]
namespace DevAssessment.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewsCategoriesPage : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public NewsCategoriesPage()
        {
            InitializeComponent();
        }

    }
}
