using CategoriesModule.Dialogs;
using Prism.Mvvm;
using Prism.Regions;
using QSANN.Core.Commands;
using QSANN.Core.Extensions;
using System;

namespace CategoriesModule.ViewModels;

public class RebarworksFootingViewModel : BindableBase
{
    private readonly IRebarworksFootingCalculatorService _cementCalculatorService;
    private DelegateCommandWithValidator<RebarworksFootingInputModel, RebarworksFootingInputValidator> _calculateCommand;
    private RebarworksFootingInputValidator _validator = new();

    public DelegateCommandWithValidator<RebarworksFootingInputModel, RebarworksFootingInputValidator> CalculateCommand => _calculateCommand
        ??= new DelegateCommandWithValidator<RebarworksFootingInputModel, RebarworksFootingInputValidator>(ExecuteCalculateCommand, InputModel, _validator, new ErrorDialog());

    public RebarworksFootingInputModel InputModel { get; set; } = new();
    public RebarworksFootingOutputModel OutputModel { get; set; } = new();

    private bool _isResultVisible;

    public bool IsResultVisible
    {
        get { return _isResultVisible; }
        set { SetProperty(ref _isResultVisible, value); }
    }

    public RebarworksFootingViewModel(IRebarworksCalculatorService cementCalculatorService, IRegionManager regionManager)
    {
        _cementCalculatorService = cementCalculatorService;
    }

    private void ExecuteCalculateCommand()
    {
        decimal volume = _cementCalculatorService.CalculateVolume(
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