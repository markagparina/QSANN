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

public class ConcreteSlabViewModel : ViewModelBase<ConcreteSlabInputModel, ConcreteSlabInput>
{
    private readonly IConcreteCalculatorService _concreteCalculatorService;
    private readonly AppDbContext _context;
    private DelegateCommandWithValidator<ConcreteSlabInputModel, ConcreteSlabInputValidator> _calculateCommand;
    private readonly ConcreteSlabInputValidator _validator = new();

    public DelegateCommandWithValidator<ConcreteSlabInputModel, ConcreteSlabInputValidator> CalculateCommand => _calculateCommand
        ??= new DelegateCommandWithValidator<ConcreteSlabInputModel, ConcreteSlabInputValidator>(ExecuteCalculateCommand, InputModel, _validator, new ErrorDialog());

    public override ConcreteSlabInputModel InputModel { get; set; } = new();
    public ConcreteSlabOutputModel OutputModel { get; set; } = new();

    public ConcreteSlabViewModel(IConcreteCalculatorService concreteCalculatorService, AppDbContext context, IEventAggregator eventAggregator)
    : base(context, eventAggregator)
    {
        _concreteCalculatorService = concreteCalculatorService;
        _context = context;
        //eventAggregator.GetEvent<LoadProjectEvent>().Subscribe(LoadProjectInput, ThreadOption.UIThread);
    }

    private void ExecuteCalculateCommand()
    {
        decimal volume = _concreteCalculatorService.CalculateVolume(
                    InputModel.LengthOfSlab.StripAndParseAsDecimal(),
                    InputModel.WidthOfSlab.StripAndParseAsDecimal(),
                    InputModel.ThicknessOfSlab.StripAndParseAsDecimal(),
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

    //private void LoadProjectInput(Guid projectId)
    //{
    //    var slabProject = _context.Set<ConcreteSlabInput>().FirstOrDefault(slab => slab.ProjectId == projectId);

    //    if (slabProject is not null)
    //    {
    //        InputModel.LengthOfSlab = slabProject.LengthOfSlab;
    //        InputModel.WidthOfSlab = slabProject.WidthOfSlab;
    //        InputModel.ThicknessOfSlab = slabProject.ThicknessOfSlab;
    //        InputModel.NumbersOfCount = slabProject.NumbersOfCount;
    //        InputModel.ClassMixture = slabProject.ClassMixture;
    //    }
    //}
}