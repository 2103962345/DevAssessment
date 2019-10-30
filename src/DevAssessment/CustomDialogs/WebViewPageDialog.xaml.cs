using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DevAssessment.CustomDialogs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WebViewPageDialog : Frame
    {
        private bool _isNavigatingFromWebView;
        public WebViewPageDialog()
        {
            InitializeComponent();
        }

        private void WebView_Navigating(object sender, WebNavigatingEventArgs e)
        {
            if(_isNavigatingFromWebView)
            {
                e.Cancel = true;
            }
        }

        private void WebView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            _isNavigatingFromWebView = true;
        }
    }
}