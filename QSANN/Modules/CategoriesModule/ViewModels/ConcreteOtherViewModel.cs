using CategoriesModule.Dialogs;
using CategoriesModule.Models;
using CategoriesModule.Validators;
using Prism.Events;
using QSANN.Core.Commands;
using QSANN.Core.Events;
using QSANN.Core.Extensions;
using QSANN.Core.Mvvm;
using QSANN.Data;
using QSANN.Data.Entities;
using QSANN.Data.Microsoft.EntityFrameworkCore;
using QSANN.Services.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace CategoriesModule.ViewModels;

public class ConcreteOtherViewModel : ViewModelBase<ConcreteOtherInputModel, ConcreteOtherInput, ConcreteOtherOutput, ConcreteOtherInputValidator>
{
    private readonly IConcreteCalculatorService _concreteCalculatorService;
    private DelegateCommandWithValidator<ConcreteOtherInputModel, ConcreteOtherInputValidator> _calculateCommand;
    private readonly ConcreteOtherInputValidator _validator = new();

    public override DelegateCommandWithValidator<ConcreteOtherInputModel, ConcreteOtherInputValidator> CalculateCommand => _calculateCommand
        ??= new DelegateCommandWithValidator<ConcreteOtherInputModel, ConcreteOtherInputValidator>(ExecuteCalculateCommand, InputModel, _validator, new ErrorDialog());

    public override ConcreteOtherInputModel InputModel { get; set; } = new();
    public ConcreteOtherOutputModel OutputModel { get; set; } = new();
    public override ConcreteOtherOutput OutputStorage { get; set; } = new();

    public ObservableCollection<ConcreteSpecificationModel> Specifications { get; set; } = new(
        new ConcreteSpecificationModel[]
        {
            new ConcreteSpecificationModel() { Name = "Beam" },
            new ConcreteSpecificationModel() { Name = "Column" },
            new ConcreteSpecificationModel() { Name = "Slab" },
            new ConcreteSpecificationModel() { Name = "Footing" }
        }
    );

    private ConcreteSpecificationModel _selectedSpecification;

    public ConcreteSpecificationModel SelectedSpecification
    {
        get { return _selectedSpecification; }
        set { SetProperty(ref _selectedSpecification, value); }
    }

    public ConcreteOtherViewModel(IConcreteCalculatorService concreteCalculatorService, AppDbContext context, IEventAggregator eventAggregator)
    : base(context, eventAggregator)
    {
        _concreteCalculatorService = concreteCalculatorService;
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

        OutputStorage.CementMixture = bagsOfCement;
        OutputStorage.Sand = volume * .5m;
        OutputStorage.Gravel = volume * 1;

        OutputModel.CementMixture = $"{bagsOfCement} Bags of Cement";
        OutputModel.Sand = $"{(volume * .5m)}m\xB3 of Sand";
        OutputModel.Gravel = $"{(volume * 1)}m\xB3 (3/4\") of Gravel";
        IsResultVisible = true;
    }

    protected override void SaveProjectOutput(Guid monitoringProjectId)
    {
        var specificationName = SelectedSpecification?.Name;

        EventAggregator.GetEvent<ConcreteOtherCategoryCalculatedEvent>()
        .Publish(new ConcreteOtherCategoryCalculatedEventPayload()
        {
            SpecificationName = specificationName,
            Output = OutputStorage
        });
    }
}