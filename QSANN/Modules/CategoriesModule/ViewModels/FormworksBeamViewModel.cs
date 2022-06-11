using CategoriesModule.Dialogs;
using CategoriesModule.Models;
using CategoriesModule.Validators;
using Prism.Events;
using Prism.Mvvm;
using QSANN.Core.Commands;
using QSANN.Core.Events;
using QSANN.Core.Extensions;
using QSANN.Data;
using QSANN.Data.Entities;
using QSANN.Services.Interfaces;
using System;
using System.Linq;

namespace CategoriesModule.ViewModels
{
    public class FormworksBeamViewModel : BindableBase
    {
        private readonly IFormworksBeamCalculatorService _formworksBeamCalculatorService;
        private readonly AppDbContext _context;
        private DelegateCommandWithValidator<FormworksBeamInputModel, FormworksBeamInputValidator> _calculateCommand;
        private readonly FormworksBeamInputValidator _validator = new();

        public DelegateCommandWithValidator<FormworksBeamInputModel, FormworksBeamInputValidator> CalculateCommand => _calculateCommand
            ??= new DelegateCommandWithValidator<FormworksBeamInputModel, FormworksBeamInputValidator>(ExecuteCalculateCommand, InputModel, _validator, new ErrorDialog());

        public FormworksBeamInputModel InputModel { get; set; } = new();
        public FormworksBeamOutputModel OutputModel { get; set; } = new();

        private bool _isResultVisible;

        public bool IsResultVisible
        {
            get { return _isResultVisible; }
            set { SetProperty(ref _isResultVisible, value); }
        }

        public FormworksBeamViewModel(IFormworksBeamCalculatorService formworksBeamCalculatorService, AppDbContext context, IEventAggregator eventAggregator)
        {
            _formworksBeamCalculatorService = formworksBeamCalculatorService;
            _context = context;
            eventAggregator.GetEvent<LoadProjectEvent>().Subscribe(LoadProjectInput, ThreadOption.UIThread);
        }

        private void ExecuteCalculateCommand()
        {
            decimal perimeter = _formworksBeamCalculatorService.CalculatePerimeter(InputModel.LengthOfBeam.StripAndParseAsDecimal(), InputModel.WidthOfBeam.StripAndParseAsDecimal());
            decimal area = _formworksBeamCalculatorService.CalculateArea(perimeter, InputModel.LengthOfBeam.StripAndParseAsDecimal(), InputModel.NumberOfCounts.StripAndParseAsDecimal());
            decimal numberOfPlywood = _formworksBeamCalculatorService.CalculateNumberOfPlywood(area);
            decimal numberOfBoardFeetLumber = _formworksBeamCalculatorService.CalculateNumberOfBoardFeetLumber(numberOfPlywood, InputModel.LumberSize, InputModel.ThicknessOfPlywood);

            OutputModel.NumberOfPlywood = $"{numberOfPlywood:N2} pcs of 4'x8' Plywood";
            OutputModel.NumberOfBoardFeetLumber = $"{numberOfBoardFeetLumber:N2} Bd.ft Lumber";

            IsResultVisible = true;
        }

        private void LoadProjectInput(Guid projectId)
        {
            var beamProject = _context.Set<FormworksBeamInput>().FirstOrDefault(Beam => Beam.ProjectId == projectId);

            if (beamProject is not null)
            {
                InputModel.LengthOfBeam = beamProject.LengthOfBeam;
                InputModel.WidthOfBeam = beamProject.WidthOfBeam;
                InputModel.HeightOfBeam = beamProject.HeightOfBeam;
                InputModel.NumberOfCounts = beamProject.NumberOfCounts;
                InputModel.LumberSize = beamProject.LumberSize;
                InputModel.ThicknessOfPlywood = beamProject.ThicknessOfPlywood;
            }
        }
    }
}