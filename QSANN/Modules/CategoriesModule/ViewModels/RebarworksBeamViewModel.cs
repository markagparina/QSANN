﻿using CategoriesModule.Dialogs;
using CategoriesModule.Models;
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
using System.Linq;

namespace CategoriesModule.ViewModels;

public class RebarworksBeamViewModel : ViewModelBase<RebarworksBeamInputModel, RebarworksBeamInput, RebarworksBeamOutput, RebarworksBeamInputValidator>
{
    private readonly IRebarworksBeamCalculatorService _beamCalculatorService;
    private readonly AppDbContext _context;
    private DelegateCommandWithValidator<RebarworksBeamInputModel, RebarworksBeamInputValidator> _calculateCommand;
    private readonly RebarworksBeamInputValidator _validator = new();

    public override DelegateCommandWithValidator<RebarworksBeamInputModel, RebarworksBeamInputValidator> CalculateCommand => _calculateCommand
        ??= new DelegateCommandWithValidator<RebarworksBeamInputModel, RebarworksBeamInputValidator>(ExecuteCalculateCommand, InputModel, _validator, new ErrorDialog());

    public override RebarworksBeamInputModel InputModel { get; set; } = new();
    public RebarworksBeamOutputModel OutputModel { get; set; } = new();
    public override RebarworksBeamOutput OutputStorage { get; set; } = new();

    public RebarworksBeamViewModel(IRebarworksBeamCalculatorService beamCalculatorService, AppDbContext context, IEventAggregator eventAggregator)
    : base(context, eventAggregator)
    {
        _beamCalculatorService = beamCalculatorService;
        _context = context;
        eventAggregator.GetEvent<RebarworksWidthOfColumnChanged>().Subscribe(UpdateWidthOfColumn);
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

        OutputStorage.Mainbar = mainbarBeam;
        OutputStorage.ShortBeamLength = sbl;
        OutputStorage.Tiewire = tiewire;
        OutputStorage.LateralTies = lateralTies;

        OutputModel.Mainbar = $"{mainbarBeam:N2} pcs of 6m Mainbar";
        OutputModel.ShortBeamLength = $"{sbl:N2} pcs of 6m Bendbars";
        OutputModel.Tiewire = $"{tiewire:N2} kg/s of (#16) Tiewire";
        OutputModel.LateralTies = $"{lateralTies:N2} pcs of 6m Stirrups";
        IsResultVisible = true;
    }

    //private void LoadProjectInput(Guid projectId)
    //{
    //    var rebarworksBeamProject = _context.Set<RebarworksBeamInput>().FirstOrDefault(rebarworkBeam => rebarworkBeam.ProjectId == projectId);

    //    if (rebarworksBeamProject is not null)
    //    {
    //        InputModel.LengthOfBeam = rebarworksBeamProject.LengthOfBeam;
    //        InputModel.WidthOfBeam = rebarworksBeamProject.WidthOfBeam;
    //        InputModel.HeightOfBeam = rebarworksBeamProject.HeightOfBeam;
    //        InputModel.NumbersOfBeam = rebarworksBeamProject.NumbersOfBeam;
    //        InputModel.SizeOfMainbar = rebarworksBeamProject.SizeOfMainbar;
    //        InputModel.SizeOfStirrups = rebarworksBeamProject.SizeOfStirrups;
    //    }
    //}

    private void UpdateWidthOfColumn(string widthOfcolumn)
    {
        InputModel.WidthOfColumn = widthOfcolumn;
    }
}