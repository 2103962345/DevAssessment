using DevAssessment.Attributes;
using DevAssessment.Views;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;


[assembly: MenuItem("Log Out", nameof(LogOutPage))]
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