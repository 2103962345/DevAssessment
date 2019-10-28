
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Essentials;
namespace DevAssessment.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]

    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (Device.Idiom == TargetIdiom.TV || Device.Idiom == TargetIdiom.Desktop)
            {
                IsPresented = true;
                
            }
            else if (Device.Idiom == TargetIdiom.Tablet)
            {
                var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
               
                var orientation = mainDisplayInfo.Orientation;
              
                if (orientation == DisplayOrientation.Landscape)
                {
                    IsPresented = true;
                }
                
            }



        }
    }
}