using CategoriesModule.Dialogs;
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

public class ConcreteFootingViewModel : ViewModelBase<ConcreteFootingInputModel, ConcreteFootingInput, ConcreteFootingOutput, ConcreteFootingInputValidator>
{
    private readonly IConcreteCalculatorService _concreteCalculatorService;
    private readonly AppDbContext _context;
    private DelegateCommandWithValidator<ConcreteFootingInputModel, ConcreteFootingInputValidator> _calculateCommand;
    private readonly ConcreteFootingInputValidator _validator = new();

    public override DelegateCommandWithValidator<ConcreteFootingInputModel, ConcreteFootingInputValidator> CalculateCommand => _calculateCommand
        ??= new DelegateCommandWithValidator<ConcreteFootingInputModel, ConcreteFootingInputValidator>(ExecuteCalculateCommand, InputModel, _validator, new ErrorDialog());

    public override ConcreteFootingInputModel InputModel { get; set; } = new();
    public ConcreteFootingOutputModel OutputModel { get; set; } = new();
    public override ConcreteFootingOutput OutputStorage { get; set; } = new();

    public ConcreteFootingViewModel(IConcreteCalculatorService concreteCalculatorService, AppDbContext context, IEventAggregator eventAggregator)
    : base(context, eventAggregator)
    {
        _concreteCalculatorService = concreteCalculatorService;
        _context = context;
        EventAggregator.GetEvent<ConcreteOtherCategoryCalculatedEvent>().Subscribe(AddOtherToTotal, ThreadOption.UIThread, false, FilterIsEqualToFooting);
    }

    private bool FilterIsEqualToFooting(ConcreteOtherCategoryCalculatedEventPayload payload)
    {
        return payload.SpecificationName == "Footing";
    }

    private void AddOtherToTotal(ConcreteOtherCategoryCalculatedEventPayload payload)
    {
        OutputStorage.CementMixture += payload.Output.CementMixture;
        OutputStorage.Sand += payload.Output.Sand;
        OutputStorage.Gravel += payload.Output.Gravel;

        Context.Update(OutputStorage);

        Context.SaveChanges();
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

        OutputStorage.CementMixture = bagsOfCement;
        OutputStorage.Sand = (volume * .5m);
        OutputStorage.Gravel = (volume * 1m);

        OutputModel.CementMixture = $"{bagsOfCement} Bags of Cement";
        OutputModel.Sand = $"{(volume * .5m)}m\xB3 of Sand";
        OutputModel.Gravel = $"{(volume * 1)}m\xB3 (3/4\") of Gravel";
        IsResultVisible = true;
    }
}