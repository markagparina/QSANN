using CategoriesModule.Dialogs;
using CategoriesModule.Models;
using CategoriesModule.Models.Rebarworks;
using CategoriesModule.Validators;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using QSANN.Core.Commands;
using QSANN.Core.Events;
using QSANN.Core.Extensions;
using QSANN.Core.Mvvm;
using QSANN.Data;
using QSANN.Data.Entities;
using QSANN.Services.Interfaces;
using System;

namespace CategoriesModule.ViewModels;

public class RebarworksFootingViewModel : ViewModelBase<RebarworksFootingInputModel, RebarworksFootingInput, RebarworksFootingOutput>
{
    private readonly IRebarworksFootingCalculatorService _rebarworksFootingCalculatorService;

    private DelegateCommandWithValidator<RebarworksFootingInputModel, RebarworksFootingInputValidator> _calculateCommand;
    private readonly RebarworksFootingInputValidator _validator = new();

    public DelegateCommandWithValidator<RebarworksFootingInputModel, RebarworksFootingInputValidator> CalculateCommand => _calculateCommand
        ??= new DelegateCommandWithValidator<RebarworksFootingInputModel, RebarworksFootingInputValidator>(ExecuteCalculateCommand, InputModel, _validator, new ErrorDialog());

    public override RebarworksFootingInputModel InputModel { get; set; } = new();
    public RebarworksFootingOutputModel OutputModel { get; set; } = new();

    public override RebarworksFootingOutput OutputStorage { get; set; } = new();

    public RebarworksFootingViewModel(IRebarworksFootingCalculatorService rebarworksFootingCalculatorService, AppDbContext context, IEventAggregator eventAggregator)
    : base(context, eventAggregator)
    {
        _rebarworksFootingCalculatorService = rebarworksFootingCalculatorService;
    }

    private void ExecuteCalculateCommand()
    {
        decimal horizontalFooting = _rebarworksFootingCalculatorService.CalculateHorizontalFoootingRebar
            (InputModel.LengthOfFooting.StripAndParseAsDecimal(),
            InputModel.WidthOfFooting.StripAndParseAsDecimal(), InputModel.SpacingOfSteelbar.StripAndParseAsDecimal());

        decimal verticalFooting = _rebarworksFootingCalculatorService.CalculateVerticalFoootingRebar
            (InputModel.WidthOfFooting.StripAndParseAsDecimal(),
            InputModel.LengthOfFooting.StripAndParseAsDecimal(), InputModel.SpacingOfSteelbar.StripAndParseAsDecimal());

        decimal totalFooting = _rebarworksFootingCalculatorService.CalculateTotalFootingRebar(horizontalFooting, verticalFooting);
        decimal tiewire = _rebarworksFootingCalculatorService.CalculateTiewire(InputModel.WidthOfFooting.StripAndParseAsDecimal(),
            InputModel.LengthOfFooting.StripAndParseAsDecimal(),
            InputModel.SpacingOfSteelbar.StripAndParseAsDecimal(),
            InputModel.NumbersOfFooting.StripAndParseAsDecimal());

        OutputStorage.Steelbar = totalFooting;
        OutputStorage.Tiewire = tiewire;

        OutputModel.Steelbar = $"{totalFooting:N2} pcs of 6m Mainbar";
        OutputModel.Tiewire = $"{tiewire:N2} kg/s of (#16) Tiewire";

        IsResultVisible = true;
    }
}