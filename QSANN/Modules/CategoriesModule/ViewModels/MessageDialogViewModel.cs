using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CategoriesModule.ViewModels
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
