using CategoriesModule.Dialogs;
using CategoriesModule.Models;
using CategoriesModule.Validators;
using Prism.Mvvm;
using Prism.Regions;
using QSANN.Core.Commands;
using QSANN.Core.Extensions;
using QSANN.Services.Interfaces;
using System;
using System.Collections.ObjectModel;

namespace CategoriesModule.ViewModels;

public class ConcreteOtherViewModel : BindableBase
{
    private readonly IConcreteCalculatorService _cementCalculatorService;
    private DelegateCommandWithValidator<ConcreteOtherInputModel, ConcreteOtherInputValidator> _calculateCommand;
    private ConcreteOtherInputValidator _validator = new();

    public DelegateCommandWithValidator<ConcreteOtherInputModel, ConcreteOtherInputValidator> CalculateCommand => _calculateCommand
        ??= new DelegateCommandWithValidator<ConcreteOtherInputModel, ConcreteOtherInputValidator>(ExecuteCalculateCommand, InputModel, _validator, new ErrorDialog());
    public ConcreteOtherInputModel InputModel { get; set; } = new();
    public ConcreteOtherOutputModel OutputModel { get; set; } = new();
    public ObservableCollection<ConcreteSpecificationModel> Specifications { get; set; } = new(
        new ConcreteSpecificationModel[]
        {
            new ConcreteSpecificationModel() { Name = "Beam" },
            new ConcreteSpecificationModel() { Name = "Column" },
            new ConcreteSpecificationModel() { Name = "Slab" },
            new ConcreteSpecificationModel() { Name = "Footing" }
        }
    );

    private bool _isResultVisible;
    public bool IsResultVisible
    {
        get { return _isResultVisible; }
        set { SetProperty(ref _isResultVisible, value); }
    }


    private ConcreteSpecificationModel _selectedSpecification;
    public ConcreteSpecificationModel SelectedSpecification
    {
        get { return _selectedSpecification; }
        set { SetProperty(ref _selectedSpecification, value); }
    }

    public ConcreteOtherViewModel(IConcreteCalculatorService cementCalculatorService, IRegionManager regionManager)
    {
        _cementCalculatorService = cementCalculatorService;
    }
    private void ExecuteCalculateCommand()
    {
        decimal volume = InputModel.TotalVolume.StripAndParseAsDecimal();

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
