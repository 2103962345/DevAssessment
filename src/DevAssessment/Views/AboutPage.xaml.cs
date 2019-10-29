using Common.Resx;
using DevAssessment.Attributes;
using DevAssessment.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: MenuItem(nameof(AppResources.MenuNameAboutUs), nameof(AboutPage))]
namespace DevAssessment.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }
    }
}