﻿using CategoriesModule.Dialogs;
using CategoriesModule.Models;
using CategoriesModule.Validators;
using Prism.Events;
using Prism.Mvvm;
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
    public class FormworksBeamViewModel : ViewModelBase<FormworksBeamInputModel, FormworksBeamInput, FormworksBeamOutput, FormworksBeamInputValidator>
    {
        private readonly IFormworksBeamCalculatorService _formworksBeamCalculatorService;
        private DelegateCommandWithValidator<FormworksBeamInputModel, FormworksBeamInputValidator> _calculateCommand;
        private readonly FormworksBeamInputValidator _validator = new();

        public override DelegateCommandWithValidator<FormworksBeamInputModel, FormworksBeamInputValidator> CalculateCommand => _calculateCommand
            ??= new DelegateCommandWithValidator<FormworksBeamInputModel, FormworksBeamInputValidator>(ExecuteCalculateCommand, InputModel, _validator, new ErrorDialog());

        public override FormworksBeamInputModel InputModel { get; set; } = new();
        public FormworksBeamOutputModel OutputModel { get; set; } = new();
        public override FormworksBeamOutput OutputStorage { get; set; } = new();

        public FormworksBeamViewModel(IFormworksBeamCalculatorService formworksBeamCalculatorService, AppDbContext context, IEventAggregator eventAggregator)
        : base(context, eventAggregator)
        {
            _formworksBeamCalculatorService = formworksBeamCalculatorService;
        }

        private void ExecuteCalculateCommand()
        {
            decimal perimeter = _formworksBeamCalculatorService.CalculatePerimeter(InputModel.LengthOfBeam.StripAndParseAsDecimal(), InputModel.WidthOfBeam.StripAndParseAsDecimal());
            decimal area = _formworksBeamCalculatorService.CalculateArea(perimeter, InputModel.LengthOfBeam.StripAndParseAsDecimal(), InputModel.NumberOfCounts.StripAndParseAsDecimal());
            decimal numberOfPlywood = _formworksBeamCalculatorService.CalculateNumberOfPlywood(area);
            decimal numberOfBoardFeetLumber = _formworksBeamCalculatorService.CalculateNumberOfBoardFeetLumber(numberOfPlywood, InputModel.LumberSize, InputModel.ThicknessOfPlywood);

            OutputStorage.NumberOfPlywood = numberOfPlywood;
            OutputStorage.NumberOfBoardFeetLumber = numberOfBoardFeetLumber;

            OutputModel.NumberOfPlywood = $"{numberOfPlywood:N2} pcs of 4'x8' Plywood";
            OutputModel.NumberOfBoardFeetLumber = $"{numberOfBoardFeetLumber:N2} Bd.ft Lumber";

            IsResultVisible = true;
        }
    }
}