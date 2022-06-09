using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace QSANN.ViewModels
{
    public class ErrorDialogViewModel : BindableBase
    {
        private ObservableCollection<string> _validationErrors;

        public ObservableCollection<string> ValidationErrors
        {
            get { return _validationErrors; }
            set { SetProperty(ref _validationErrors, value); }
        }

        public ErrorDialogViewModel(IEnumerable<string> errors = null)
        {
            ValidationErrors = new ObservableCollection<string>(errors);
        }
    }
}