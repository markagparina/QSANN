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

public class ConcreteBeamViewModel : ViewModelBase<ConcreteBeamInputModel, ConcreteBeamInput>
{
    private readonly IConcreteCalculatorService _concreteCalculatorService;
    private readonly AppDbContext _context;
    private DelegateCommandWithValidator<ConcreteBeamInputModel, ConcreteBeamInputValidator> _calculateCommand;
    private readonly ConcreteBeamInputValidator _validator = new();

    public DelegateCommandWithValidator<ConcreteBeamInputModel, ConcreteBeamInputValidator> CalculateCommand => _calculateCommand
        ??= new DelegateCommandWithValidator<ConcreteBeamInputModel, ConcreteBeamInputValidator>(ExecuteCalculateCommand, InputModel, _validator, new ErrorDialog());

    public override ConcreteBeamInputModel InputModel { get; set; } = new();
    public ConcreteBeamOutputModel OutputModel { get; set; } = new();

    private bool _isResultVisible;

    public bool IsResultVisible
    {
        get { return _isResultVisible; }
        set { SetProperty(ref _isResultVisible, value); }
    }

    public ConcreteBeamViewModel(IConcreteCalculatorService concreteCalculatorService, AppDbContext context, IEventAggregator eventAggregator)
    : base(context, eventAggregator)
    {
        _concreteCalculatorService = concreteCalculatorService;
        _context = context;
        //eventAggregator.GetEvent<LoadProjectEvent>().Subscribe(LoadProjectInput, ThreadOption.UIThread);
    }

    private void ExecuteCalculateCommand()
    {
        decimal volume = _concreteCalculatorService.CalculateVolume(
                    InputModel.LengthOfBeam.StripAndParseAsDecimal(),
                    InputModel.WidthOfBeam.StripAndParseAsDecimal(),
                    InputModel.HeightOfBeam.StripAndParseAsDecimal(),
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
    //    var beamProject = _context.Set<ConcreteBeamInput>().FirstOrDefault(beam => beam.ProjectId == projectId);

    //    if (beamProject is not null)
    //    {
    //        InputModel.LengthOfBeam = beamProject.LengthOfBeam;
    //        InputModel.WidthOfBeam = beamProject.WidthOfBeam;
    //        InputModel.HeightOfBeam = beamProject.HeightOfBeam;
    //        InputModel.NumbersOfCount = beamProject.NumbersOfCount;
    //        InputModel.ClassMixture = beamProject.ClassMixture;
    //    }
    //}
}