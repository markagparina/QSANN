using CategoriesModule.Dialogs;
using CategoriesModule.Models;
using CategoriesModule.Validators;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using QSANN.Core.Commands;
using QSANN.Core.Events;
using QSANN.Core.Extensions;
using QSANN.Data;
using QSANN.Services.Interfaces;
using System;

namespace CategoriesModule.ViewModels;

public class RebarworksBeamViewModel : BindableBase
{
    private readonly IRebarworksBeamCalculatorService _beamCalculatorService;
    private readonly AppDbContext _context;
    private readonly IEventAggregator _eventAggregator;
    private DelegateCommandWithValidator<RebarworksBeamInputModel, RebarworksBeamInputValidator> _calculateCommand;
    private readonly RebarworksBeamInputValidator _validator = new();

    public DelegateCommandWithValidator<RebarworksBeamInputModel, RebarworksBeamInputValidator> CalculateCommand => _calculateCommand
        ??= new DelegateCommandWithValidator<RebarworksBeamInputModel, RebarworksBeamInputValidator>(ExecuteCalculateCommand, InputModel, _validator, new ErrorDialog());

    public RebarworksBeamInputModel InputModel { get; set; } = new();
    public RebarworksBeamOutputModel OutputModel { get; set; } = new();

    private bool _isResultVisible;

    public bool IsResultVisible
    {
        get { return _isResultVisible; }
        set { SetProperty(ref _isResultVisible, value); }
    }

    public RebarworksBeamViewModel(IRebarworksBeamCalculatorService beamCalculatorService, AppDbContext context, IEventAggregator eventAggregator)
    {
        _beamCalculatorService = beamCalculatorService;
        _context = context;
        _eventAggregator = eventAggregator;

        _eventAggregator.GetEvent<RebarworksWidthOfColumnChanged>().Subscribe(UpdateWidthOfColumn);
    }

    private void UpdateWidthOfColumn(string widthOfcolumn)
    {
        InputModel.WidthOfColumn = widthOfcolumn;
    }

    private void ExecuteCalculateCommand()
    {
        decimal area = _beamCalculatorService.CalculateBeamArea(InputModel.HeightOfBeam.StripAndParseAsDecimal(), InputModel.WidthOfBeam.StripAndParseAsDecimal());

        decimal steel = _beamCalculatorService.CalculateSteel(area, InputModel.SizeOfMainbar.StripAndParseAsDecimal());

        decimal sbl = _beamCalculatorService.CalculateSBL(InputModel.WidthOfColumn.StripAndParseAsDecimal(), InputModel.LengthOfBeam.StripAndParseAsDecimal(),
            InputModel.SizeOfStirrups.StripAndParseAsDecimal(), InputModel.NumbersOfBeam.StripAndParseAsDecimal());

        decimal bsl = _beamCalculatorService.CalculateBSL(InputModel.LengthOfBeam.StripAndParseAsDecimal());

        decimal mainbarBeam = _beamCalculatorService.CalculateMainbarBeam(InputModel.NumbersOfBeam.StripAndParseAsDecimal(), bsl, steel);

        decimal stirrups = _beamCalculatorService.CalculateStirrups1(InputModel.LengthOfBeam.StripAndParseAsDecimal(),
            InputModel.WidthOfBeam.StripAndParseAsDecimal());

        decimal spacing = _beamCalculatorService.CalculateSpacing(InputModel.LengthOfBeam.StripAndParseAsDecimal());

        decimal balance = _beamCalculatorService.CalculateBalance(spacing);

        decimal pieces = _beamCalculatorService.CalculatePieces(balance);

        decimal lateralTies = _beamCalculatorService.CalculateStirrups(stirrups, pieces);

        decimal tiewire = _beamCalculatorService.CalculateTieWire(pieces, steel, InputModel.NumbersOfBeam.StripAndParseAsDecimal());

        OutputModel.Mainbar = $"{mainbarBeam:N2} pcs of 6m Mainbar";
        OutputModel.ShortBeamLength = $"{sbl:N2} pcs of 6m Bendbars";
        OutputModel.Tiewire = $"{tiewire:N2} kg/s of (#16) Tiewire";
        OutputModel.LateralTies = $"{lateralTies:N2} pcs of 6m Stirrups";
        IsResultVisible = true;
    }
}