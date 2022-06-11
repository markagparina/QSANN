using CategoriesModule.Dialogs;
using CategoriesModule.Models;
using CategoriesModule.Validators;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using QSANN.Core.Commands;
using QSANN.Core.Events;
using QSANN.Core.Extensions;
using QSANN.Services.Interfaces;
using System;

namespace CategoriesModule.ViewModels;

public class RebarworksColumnViewModel : BindableBase
{
    private readonly IRebarworksColumnCalculatorService _rebarworksColumnCalculatorService;
    private readonly IEventAggregator _eventAggregator;
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

    public RebarworksColumnViewModel(IRebarworksColumnCalculatorService rebarworksColumnCalculatorService, IEventAggregator eventAggregator)
    {
        _rebarworksColumnCalculatorService = rebarworksColumnCalculatorService;
        _eventAggregator = eventAggregator;
        InputModel.PropertyChanged += InputModel_PropertyChanged;
    }

    private void InputModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(InputModel.WidthOfColumn))
        {
            _eventAggregator.GetEvent<RebarworksWidthOfColumnChanged>().Publish(InputModel.WidthOfColumn);
        }
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

        OutputModel.Mainbar = $"{mainbarColumn:N2} pcs of 6m Mainbar";
        OutputModel.Tiewire = $"{tiewire:N2} kg/s of (#16) Tiewire";
        OutputModel.LateralTies = $"{lateralTies:N2} pcs of 6m Lateral ties";
        IsResultVisible = true;
    }
}