using FluentValidation;
using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Mvvm;
using QSANN.ViewModels;
using System;
using System.Linq;
using System.Windows.Controls;

namespace QSANN.Core.Commands
{
    public class DelegateCommandWithValidator<TValidatable, TValidator> : CustomDelegateCommand
        where TValidatable : BindableBase
        where TValidator : AbstractValidator<TValidatable>
    {
        private readonly Action _executeMethod;
        private readonly TValidatable _validatable;
        private readonly TValidator _validator;
        private readonly ContentControl _errorDialogControl;

        public DelegateCommandWithValidator(Action executeMethod, TValidatable validatable, TValidator validator, ContentControl errorDialogControl) : base(executeMethod)
        {
            _executeMethod = executeMethod;
            _validatable = validatable;
            _validator = validator;
            _errorDialogControl = errorDialogControl;
        }

        protected override void Execute(object parameter)
        {
            Execute();
        }

        public override async void Execute()
        {
            var validationResult = _validator.Validate(_validatable);

            if (!validationResult.IsValid)
            {
                _errorDialogControl.DataContext = new ErrorDialogViewModel(validationResult.Errors.Select(failure => failure.ErrorMessage));

                if (!DialogHost.IsDialogOpen(null))
                {
                    var dialogResult = await DialogHost.Show(_errorDialogControl);
                    return;
                }
            }
            _executeMethod();
        }
    }
}