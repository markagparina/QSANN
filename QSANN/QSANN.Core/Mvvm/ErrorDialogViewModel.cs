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

        private string _entityName;

        public string EntityName
        {
            get { return _entityName; }
            set { SetProperty(ref _entityName, value); }
        }



        public ErrorDialogViewModel(string entityName, IEnumerable<string> errors = null)
        {
            ValidationErrors = new ObservableCollection<string>(errors);
            EntityName = entityName;
        }
    }
}