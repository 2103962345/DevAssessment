using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevAssessment.ViewModel
{
    public class AlertDialogViewModel : BindableBase, IDialogAware, IAutoInitialize
    {
       

        public AlertDialogViewModel()
        {
            CloseCommand = new DelegateCommand(() => RequestClose(null));
        }

        public DelegateCommand CloseCommand { get; }

        public event Action<IDialogParameters> RequestClose;

        private string _alertMessage;
        public string AlertMessage
        {
            get { return _alertMessage; }
            set { SetProperty(ref _alertMessage, value); }
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
