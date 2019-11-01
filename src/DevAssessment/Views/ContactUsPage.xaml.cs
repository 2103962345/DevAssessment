
using Common.Resx;
using HelpersLibrary;
using DevAssessment.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: MenuItem(nameof(AppResources.MenuNameContactUs), nameof(ContactUsPage))]
namespace DevAssessment.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactUsPage : ContentPage
    {
        public ContactUsPage()
        {
            InitializeComponent();
        }
    }
}