using CategoriesModule.Dialogs;
using CategoriesModule.Models;
using CategoriesModule.Validators;
using Prism.Events;
using QSANN.Core.Commands;
using QSANN.Core.Events;
using QSANN.Core.Extensions;
using QSANN.Core.Mvvm;
using QSANN.Data;
using QSANN.Data.Entities;
using QSANN.Services.Interfaces;
using System;
using System.Linq;

namespace CategoriesModule.ViewModels
{
    public class FormworksColumnViewModel : ViewModelBase<FormworksColumnInputModel, FormworksColumnInput, FormworksColumnOutput, FormworksColumnInputValidator>
    {
        private readonly IFormworksColumnCalculatorService _formworksColumnCalculatorService;
        private readonly AppDbContext _context;
        private DelegateCommandWithValidator<FormworksColumnInputModel, FormworksColumnInputValidator> _calculateCommand;
        private readonly FormworksColumnInputValidator _validator = new();

        public override DelegateCommandWithValidator<FormworksColumnInputModel, FormworksColumnInputValidator> CalculateCommand => _calculateCommand
            ??= new DelegateCommandWithValidator<FormworksColumnInputModel, FormworksColumnInputValidator>(ExecuteCalculateCommand, InputModel, _validator, new ErrorDialog());

        public override FormworksColumnInputModel InputModel { get; set; } = new();
        public FormworksColumnOutputModel OutputModel { get; set; } = new();
        public override FormworksColumnOutput OutputStorage { get; set; } = new();

        public FormworksColumnViewModel(IFormworksColumnCalculatorService formworksColumnCalculatorService, AppDbContext context, IEventAggregator eventAggregator)
        : base(context, eventAggregator)
        {
            _formworksColumnCalculatorService = formworksColumnCalculatorService;
            _context = context;
            //eventAggregator.GetEvent<LoadProjectEvent>().Subscribe(LoadProjectInput, ThreadOption.UIThread);
        }

        private void ExecuteCalculateCommand()
        {
            decimal perimeter = _formworksColumnCalculatorService.CalculatePerimeter(InputModel.LengthOfColumn.StripAndParseAsDecimal(), InputModel.WidthOfColumn.StripAndParseAsDecimal());
            decimal area = _formworksColumnCalculatorService.CalculateArea(perimeter, InputModel.HeightOfColumn.StripAndParseAsDecimal(), InputModel.NumberOfCounts.StripAndParseAsDecimal());
            decimal numberOfPlywood = _formworksColumnCalculatorService.CalculateNumberOfPlywood(area);
            decimal numberOfBoardFeetLumber = _formworksColumnCalculatorService.CalculateNumberOfBoardFeetLumber(numberOfPlywood, InputModel.LumberSize, InputModel.ThicknessOfPlywood);

            OutputStorage.NumberOfPlywood = numberOfPlywood;
            OutputStorage.NumberOfBoardFeetLumber = numberOfBoardFeetLumber;

            OutputModel.NumberOfPlywood = $"{numberOfPlywood:N2} pcs of 4'x8' Plywood";
            OutputModel.NumberOfBoardFeetLumber = $"{numberOfBoardFeetLumber:N2} Bd.ft Lumber";

            IsResultVisible = true;
        }

        //private void LoadProjectInput(Guid projectId)
        //{
        //    var columnProject = _context.Set<FormworksColumnInput>().FirstOrDefault(column => column.ProjectId == projectId);

        //    if (columnProject is not null)
        //    {
        //        InputModel.LengthOfColumn = columnProject.LengthOfColumn;
        //        InputModel.WidthOfColumn = columnProject.WidthOfColumn;
        //        InputModel.HeightOfColumn = columnProject.HeightOfColumn;
        //        InputModel.NumberOfCounts = columnProject.NumberOfCounts;
        //        InputModel.LumberSize = columnProject.LumberSize;
        //        InputModel.ThicknessOfPlywood = columnProject.ThicknessOfPlywood;
        //    }
        //}
    }
}