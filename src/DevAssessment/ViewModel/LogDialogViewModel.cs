using DevAssessment.DialogExtentions;
using Prism.AppModel;
using Prism.Commands;
using Prism.Logging;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevAssessment.ViewModel
{
    class LogDialogViewModel : BindableBase, IDialogAware
    {
        private readonly ILogger _logger;

        public LogDialogViewModel(ILogger logger)
        {
            _logger = logger;
            CloseCommand = new DelegateCommand(() => RequestClose(null));
        }

        public DelegateCommand CloseCommand { get; }

        public event Action<IDialogParameters> RequestClose;

        public bool CanCloseDialog() => true;

        private string _logMessage;
        public string LogMessage
        {
            get { return _logMessage; }
            set { SetProperty(ref _logMessage, value); }
        }

       
        public void OnDialogClosed()
        {

        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            if (parameters.ContainsKey(CustomDialog.KeyLogMessage))
            {
                var log = parameters.GetValue<Exception>(CustomDialog.KeyLogMessage);
                _logger.Report(log);

                LogMessage = log.Message;
            }

        }
    }
}
