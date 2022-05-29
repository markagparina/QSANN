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

public class ConcreteColumnViewModel : BindableBase
{
    private readonly IConcreteCalculatorService _cementCalculatorService;
    private DelegateCommandWithValidator<ConcreteColumnInputModel, ConcreteColumnInputValidator> _calculateCommand;
    private ConcreteColumnInputValidator _validator = new();

    public DelegateCommandWithValidator<ConcreteColumnInputModel, ConcreteColumnInputValidator> CalculateCommand => _calculateCommand
        ??= new DelegateCommandWithValidator<ConcreteColumnInputModel, ConcreteColumnInputValidator>(ExecuteCalculateCommand, InputModel, _validator, new ErrorDialog());
    public ConcreteColumnInputModel InputModel { get; set; } = new();
    public ConcreteColumnOutputModel OutputModel { get; set; } = new();

    private bool _isResultVisible;
    public bool IsResultVisible
    {
        get { return _isResultVisible; }
        set { SetProperty(ref _isResultVisible, value); }
    }

    public ConcreteColumnViewModel(IConcreteCalculatorService cementCalculatorService, IRegionManager regionManager)
    {
        _cementCalculatorService = cementCalculatorService;

    }
    private void ExecuteCalculateCommand()
    {
        decimal volume = _cementCalculatorService.CalculateVolume(
                    InputModel.LengthOfColumn.StripAndParseAsDecimal(),
                    InputModel.WidthOfColumn.StripAndParseAsDecimal(),
                    InputModel.HeightOfColumn.StripAndParseAsDecimal(),
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
