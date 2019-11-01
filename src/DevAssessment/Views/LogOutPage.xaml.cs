
using Common.Resx;
using HelpersLibrary;
using DevAssessment.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


[assembly: MenuItem(nameof(AppResources.MenuNameLogOut), nameof(LogOutPage))]
namespace DevAssessment.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogOutPage : ContentPage
    {
        public LogOutPage()
        {
            InitializeComponent();
        }
    }
}