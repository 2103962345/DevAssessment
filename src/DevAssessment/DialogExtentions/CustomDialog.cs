using DevAssessment.CustomDialogs;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevAssessment.DialogExtentions
{
    public static class CustomDialog
    {
        public const string keyAlertMessage = "AlertMessage";
        public const string KeyLogMessage = "LogMessage";
        public const string KeyWebViewMessage = "HyperLink";

        
        public static void DisplayAlert(this IDialogService dialogService, string message)
        {
            var param = new DialogParameters();
            param.Add(keyAlertMessage, message);
            
            dialogService.ShowDialog(typeof(AlertDialog).Name,param, CloseDialog);
        }

        public static void DisplayError(this IDialogService dialogService, Exception ex, string message = null)
        {
            var param = new DialogParameters();
            param.Add(KeyLogMessage, ex);

            dialogService.ShowDialog(typeof(LogDialog).Name, param , CloseLogDialog );
        }

        public static void DisplayWebView(this IDialogService dialogService, string link)
        {
            var param = new DialogParameters();
            param.Add(KeyWebViewMessage, link);

            dialogService.ShowDialog(nameof(WebViewPageDialog), param, CloseDialog);
        }


        private static void CloseDialog(IDialogResult dialogResult)
        {

        }

        private static void CloseLogDialog(IDialogResult dialogResult)
        {

        }
    }
}
