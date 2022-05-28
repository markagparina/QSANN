using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CommonModule.ViewModels
{
    public class MessageDialogViewModel : BindableBase
    {

        private ObservableCollection<string> _validationErrors;
        public ObservableCollection<string> ValidationErrors
        {
            get { return _validationErrors; }
            set { SetProperty(ref _validationErrors, value); }
        }

        public MessageDialogViewModel(string message = null, IEnumerable<string> errors = null)
        {
            ValidationErrors = new ObservableCollection<string>(errors);
        }
    }
}
