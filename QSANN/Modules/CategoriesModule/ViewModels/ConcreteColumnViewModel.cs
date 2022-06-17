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

public class ConcreteColumnViewModel : ViewModelBase<ConcreteColumnInputModel, ConcreteColumnInput>
{
    private readonly IConcreteCalculatorService _concreteCalculatorService;
    private readonly AppDbContext _context;
    private DelegateCommandWithValidator<ConcreteColumnInputModel, ConcreteColumnInputValidator> _calculateCommand;
    private readonly ConcreteColumnInputValidator _validator = new();

    public DelegateCommandWithValidator<ConcreteColumnInputModel, ConcreteColumnInputValidator> CalculateCommand => _calculateCommand
        ??= new DelegateCommandWithValidator<ConcreteColumnInputModel, ConcreteColumnInputValidator>(ExecuteCalculateCommand, InputModel, _validator, new ErrorDialog());

    public override ConcreteColumnInputModel InputModel { get; set; } = new();
    public ConcreteColumnOutputModel OutputModel { get; set; } = new();
    public ConcreteColumnOutput OutputStorage { get; set; } = new();

    public ConcreteColumnViewModel(IConcreteCalculatorService concreteCalculatorService, AppDbContext context, IEventAggregator eventAggregator)
    : base(context, eventAggregator)
    {
        _concreteCalculatorService = concreteCalculatorService;
        _context = context;
        //eventAggregator.GetEvent<LoadProjectEvent>().Subscribe(LoadProjectInput);
    }

    private void ExecuteCalculateCommand()
    {
        decimal volume = _concreteCalculatorService.CalculateVolume(
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

        OutputStorage.CementMixture = bagsOfCement;
        OutputStorage.Sand = (volume * .5m);
        OutputStorage.Gravel = (volume * 1m);

        OutputModel.CementMixture = $"{bagsOfCement} Bags of Cement";
        OutputModel.Sand = $"{volume * .5m}m\xB3 of Sand";
        OutputModel.Gravel = $"{volume * 1}m\xB3 (3/4\") of Gravel";
        IsResultVisible = true;
    }

    //private void LoadProjectInput(Guid projectId)
    //{
    //    var columnProject = _context.Set<ConcreteColumnInput>().FirstOrDefault(column => column.ProjectId == projectId);

    //    if (columnProject is not null)
    //    {
    //        InputModel.LengthOfColumn = columnProject.LengthOfColumn;
    //        InputModel.WidthOfColumn = columnProject.WidthOfColumn;
    //        InputModel.HeightOfColumn = columnProject.HeightOfColumn;
    //        InputModel.NumbersOfCount = columnProject.NumbersOfCount;
    //        InputModel.ClassMixture = columnProject.ClassMixture;
    //    }
    //}
}