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

public class ConcreteFootingViewModel : BindableBase
{
    private readonly IConcreteCalculatorService _concreteCalculatorService;
    private DelegateCommandWithValidator<RebarworksFootingInputModel, ConcreteFootingInputValidator> _calculateCommand;
    private ConcreteFootingInputValidator _validator = new();

    public DelegateCommandWithValidator<RebarworksFootingInputModel, ConcreteFootingInputValidator> CalculateCommand => _calculateCommand
        ??= new DelegateCommandWithValidator<RebarworksFootingInputModel, ConcreteFootingInputValidator>(ExecuteCalculateCommand, InputModel, _validator, new ErrorDialog());

    public RebarworksFootingInputModel InputModel { get; set; } = new();
    public ConcreteFootingOutputModel OutputModel { get; set; } = new();

    private bool _isResultVisible;

    public bool IsResultVisible
    {
        get { return _isResultVisible; }
        set { SetProperty(ref _isResultVisible, value); }
    }

    public ConcreteFootingViewModel(IConcreteCalculatorService concreteCalculatorService, IRegionManager regionManager)
    {
        _concreteCalculatorService = concreteCalculatorService;
    }

    private void ExecuteCalculateCommand()
    {
        decimal volume = _concreteCalculatorService.CalculateVolume(
                    InputModel.LengthOfFooting.StripAndParseAsDecimal(),
                    InputModel.WidthOfFooting.StripAndParseAsDecimal(),
                    InputModel.ThicknessOfFooting.StripAndParseAsDecimal(),
                    InputModel.NumbersOfCount.StripAndParseAsDecimal());

        decimal bagsOfCement = InputModel.ClassMixture switch
        {
            "AA" => volume * 12m,
            "A" => volume * 9m,
            "B" => volume * 7m,
            "C" => volume * 6.5m,
            _ => throw new ArgumentException("Invalid value for Class Mixture")
        };

        OutputModel.CementMixture = $"{bagsOfCement} Bags of Cement";
        OutputModel.Sand = $"{(volume * .5m)}m\xB3 of Sand";
        OutputModel.Gravel = $"{(volume * 1)}m\xB3 (3/4\") of Gravel";
        IsResultVisible = true;
    }
}