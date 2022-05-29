using CategoriesModule.Dialogs;
using CategoriesModule.Models;
using CategoriesModule.Validators;
using QSANN.Core.Commands;
using QSANN.Core.Extensions;
using QSANN.Core.Mvvm;
using QSANN.Services.Interfaces;
using System;

namespace CategoriesModule.ViewModels
{
    public class FormworksColumnViewModel : ViewModelBase
    {
        private readonly IFormworksColumnCalculatorService _formworksColumnCalculatorService;



        private DelegateCommandWithValidator<FormworksColumnInputModel, FormworksColumnInputValidator> _calculateCommand;
        private FormworksColumnInputValidator _validator = new();

        public DelegateCommandWithValidator<FormworksColumnInputModel, FormworksColumnInputValidator> CalculateCommand => _calculateCommand
            ??= new DelegateCommandWithValidator<FormworksColumnInputModel, FormworksColumnInputValidator>(ExecuteCalculateCommand, InputModel, _validator, new ErrorDialog());

        public FormworksColumnInputModel InputModel { get; set; } = new();
        public FormworksColumnOutputModel OutputModel { get; set; } = new();

        private bool _isResultVisible;
        public bool IsResultVisible
        {
            get { return _isResultVisible; }
            set { SetProperty(ref _isResultVisible, value); }
        }
        public FormworksColumnViewModel(IFormworksColumnCalculatorService formworksColumnCalculatorService)
        {
            _formworksColumnCalculatorService = formworksColumnCalculatorService;
        }
            
        private void ExecuteCalculateCommand()
        {
            decimal perimeter = _formworksColumnCalculatorService.CalculatePerimeter(InputModel.LengthOfColumn.StripAndParseAsDecimal(), InputModel.WidthOfColumn.StripAndParseAsDecimal());
            decimal area = _formworksColumnCalculatorService.CalculateArea(perimeter, InputModel.HeightOfColumn.StripAndParseAsDecimal(), InputModel.NumberOfCounts.StripAndParseAsDecimal());
            decimal numberOfPlywood = _formworksColumnCalculatorService.CalculateNumberOfPlywood(area);
            decimal numberOfBoardFeetLumber = _formworksColumnCalculatorService.CalculateNumberOfBoardFeetLumber(numberOfPlywood, InputModel.LumberSize, InputModel.ThicknessOfPlywood);

            OutputModel.NumberOfPlywood = $"{numberOfPlywood:N2} pcs of 4'x8' Plywood";
            OutputModel.NumberOfBoardFeetLumber = $"{numberOfBoardFeetLumber:N2} Bd.ft Lumber";

            IsResultVisible = true;

        }

    }
}
