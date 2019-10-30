using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevAssessment.ViewModel
{
    public class WebViewPageDialogViewModel : BindableBase, IDialogAware, IAutoInitialize
    {


        public WebViewPageDialogViewModel()
        {
            CloseCommand = new DelegateCommand(() => RequestClose(null));
        }

        public DelegateCommand CloseCommand { get; }

        public event Action<IDialogParameters> RequestClose;

        private string _hyperLink;
        public string HyperLink
        {
            get { return _hyperLink; }
            set { SetProperty(ref _hyperLink, value); }
        }

        public bool CanCloseDialog() => true;

        public void OnDialogClosed()
        {

        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
        }
    }
}
