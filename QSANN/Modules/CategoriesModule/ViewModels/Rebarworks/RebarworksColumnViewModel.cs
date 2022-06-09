using CategoriesModule.Dialogs;
using CategoriesModule.Models;
using CategoriesModule.Validators;
using Prism.Mvvm;
using Prism.Regions;
using QSANN.Core.Commands;
using QSANN.Core.Extensions;
using QSANN.Services.Interfaces;
using System;

namespace CategoriesModule.ViewModels;

public class RebarworksColumnViewModel : BindableBase
{
    private readonly IRebarworksColumnCalculatorService _rebarworksColumnCalculatorService;
    private DelegateCommandWithValidator<RebarworksColumnInputModel, RebarworksColumnInputValidator> _calculateCommand;
    private readonly RebarworksColumnInputValidator _validator = new();

    public DelegateCommandWithValidator<RebarworksColumnInputModel, RebarworksColumnInputValidator> CalculateCommand => _calculateCommand
        ??= new DelegateCommandWithValidator<RebarworksColumnInputModel, RebarworksColumnInputValidator>(ExecuteCalculateCommand, InputModel, _validator, new ErrorDialog());

    public RebarworksColumnInputModel InputModel { get; set; } = new();
    public RebarworksColumnOutputModel OutputModel { get; set; } = new();

    private bool _isResultVisible;

    public bool IsResultVisible
    {
        get { return _isResultVisible; }
        set { SetProperty(ref _isResultVisible, value); }
    }

    public RebarworksColumnViewModel(IRebarworksColumnCalculatorService rebarworksColumnCalculatorService, IRegionManager regionManager)
    {
        _rebarworksColumnCalculatorService = rebarworksColumnCalculatorService;
    }

    private void ExecuteCalculateCommand()
    {
        decimal area = _rebarworksColumnCalculatorService.CalculateColumnArea(InputModel.LengthOfColumn.StripAndParseAsDecimal(),
            InputModel.WidthOfColumn.StripAndParseAsDecimal());

        decimal steel = _rebarworksColumnCalculatorService.CalculateSteel(area, InputModel.SizeOfMainbar.StripAndParseAsDecimal());

        decimal mainbarColumn = _rebarworksColumnCalculatorService.CalculateMainbarColumn(
            InputModel.HeightOfColumn.StripAndParseAsDecimal(),
            steel,
            InputModel.NumbersOfColumn.StripAndParseAsDecimal());

        decimal ties = _rebarworksColumnCalculatorService.CalculateTies(InputModel.LengthOfColumn.StripAndParseAsDecimal(),
            InputModel.WidthOfColumn.StripAndParseAsDecimal());

        decimal spacing = _rebarworksColumnCalculatorService.CalculateSpcaing(InputModel.HeightOfColumn.StripAndParseAsDecimal());

        decimal balance = _rebarworksColumnCalculatorService.CalculateBalance(spacing);

        decimal pieces = _rebarworksColumnCalculatorService.CalculatePieces(balance);

        decimal lateralTies = _rebarworksColumnCalculatorService.CalculateLateralTies(ties, pieces);

        decimal tiewire = _rebarworksColumnCalculatorService.CalculateTieWire(pieces, steel, InputModel.NumbersOfColumn.StripAndParseAsDecimal());

        OutputModel.Steelbar = $"{steel} pcs of 6m Steelbar";
        OutputModel.Tiewire = $"{tiewire:N2} kg/s of (#16) Tiewire";
        IsResultVisible = true;
    }
}