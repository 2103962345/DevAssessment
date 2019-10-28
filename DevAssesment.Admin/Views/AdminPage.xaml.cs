using DevAssesment.Admin.Views;
using HelpersLibrary;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: MenuItem("Admin", nameof(AdminPage))]
namespace DevAssesment.Admin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminPage : ContentPage
    {
        public AdminPage()
        {
            InitializeComponent();
        }
    }
}