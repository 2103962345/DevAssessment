
using DevAssessment.Attributes;
using DevAssessment.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: MenuItem("Home", nameof(HomePage))]
namespace DevAssessment.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }
    }
}