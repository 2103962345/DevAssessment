using Common.Resx;
using DevAssessment.Attributes;
using DevAssessment.Views;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: MenuItem(nameof(AppResources.MenuNameDependencyServices), nameof(DSPage))]
namespace DevAssessment.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DSPage : ContentPage
    {
        public DSPage()
        {
            InitializeComponent();
        }
    }
}