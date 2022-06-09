﻿using CategoriesModule.Dialogs;
using CategoriesModule.Models;
using CategoriesModule.Validators;
using Prism.Mvvm;
using Prism.Regions;
using QSANN.Core.Commands;
using QSANN.Core.Extensions;
using QSANN.Services.Interfaces;
using System;

namespace CategoriesModule.ViewModels;

public class RebarworksBeamViewModel : BindableBase
{
    private readonly IRebarworksColumnCalculatorService _concreteCalculatorService;
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

    public RebarworksBeamViewModel(IRebarworksColumnCalculatorService concreteCalculatorService, IRegionManager regionManager)
    {
        _concreteCalculatorService = concreteCalculatorService;
    }

    private void ExecuteCalculateCommand()
    {
        //decimal volume = _concreteCalculatorService.CalculateVolume(
        //            InputModel.LengthOfBeam.StripAndParseAsDecimal(),
        //            InputModel.WidthOfBeam.StripAndParseAsDecimal(),
        //            InputModel.HeightOfBeam.StripAndParseAsDecimal(),
        //            InputModel.NumbersOfCount.StripAndParseAsDecimal());

        //decimal bagsOfCement = InputModel.ClassMixture switch
        //{
        //    "AA" => volume * 12m,
        //    "A" => volume * 9m,
        //    "B" => volume * 7m,
        //    "C" => volume * 6.5m,
        //    _ => throw new ArgumentException("Invalid value for Class Mixture")
        //};

        //OutputModel.CementMixture = $"{bagsOfCement} Bags of Cement";
        //OutputModel.Sand = $"{(volume * .5m)}m\xB3 of Sand";
        //OutputModel.Gravel = $"{(volume * 1)}m\xB3 (3/4\") of Gravel";
        //IsResultVisible = true;
    }
}