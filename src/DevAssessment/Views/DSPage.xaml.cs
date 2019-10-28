using DevAssessment.Attributes;
using DevAssessment.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: MenuItem("Dependency Services", nameof(DSPage))]
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