using CategoriesModule.Dialogs;
using CategoriesModule.Models;
using CategoriesModule.Validators;
using Prism.Events;
using Prism.Regions;
using QSANN.Core.Commands;
using QSANN.Core.Events;
using QSANN.Core.Extensions;
using QSANN.Core.Navigation;
using QSANN.Data;
using QSANN.Data.Entities;
using QSANN.Services.Interfaces;
using QSANN.Services.Interfaces.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace CategoriesModule.ViewModels
{
    public class PaintworksViewModel : MenuItem
    {
        private ObservableCollection<PaintworksMultiplierModel> _multipliers;
        private readonly IPaintworksCalculatorService _paintWorksCalculatorService;
        private readonly AppDbContext _context;
        private readonly PaintworksInputValidator _validator = new();

        public ObservableCollection<PaintworksMultiplierModel> Multipliers
        {
            get { return _multipliers; }
            set { SetProperty(ref _multipliers, value); }
        }

        public PaintworksInputModel InputModel { get; set; } = new();
        public PaintworksOutputModel OutputModel { get; set; } = new();

        private bool _isResultVisible;

        public bool IsResultVisible
        {
            get { return _isResultVisible; }
            set { SetProperty(ref _isResultVisible, value); }
        }

        public override string Title => "Paintworks";

        private DelegateCommandWithValidator<PaintworksInputModel, PaintworksInputValidator> _calculateCommand;

        public DelegateCommandWithValidator<PaintworksInputModel, PaintworksInputValidator> CalculateCommand => _calculateCommand
            ??= new DelegateCommandWithValidator<PaintworksInputModel, PaintworksInputValidator>(ExecuteCalculateCommand, InputModel, _validator, new ErrorDialog());

        public PaintworksViewModel(IRegionManager regionManager,
            IPaintworksCalculatorService paintworksCalculatorService,
            IEventAggregator eventAggregator,
            AppDbContext context) : base(regionManager)
        {
            _paintWorksCalculatorService = paintworksCalculatorService;
            _context = context;
            eventAggregator.GetEvent<LoadProjectEvent>().Subscribe(LoadProjectInput, ThreadOption.UIThread);
            Multipliers = new ObservableCollection<PaintworksMultiplierModel>(_paintWorksCalculatorService.GetMultipliers());
        }

        private void ExecuteCalculateCommand()
        {
            var paintWorksMultiplier = Multipliers.FirstOrDefault(multiplier => multiplier.Finish == InputModel.Finish);

            decimal primerPaint = _paintWorksCalculatorService.CalculatePrimerPaint(InputModel.AreaOfApplication.StripAndParseAsDecimal(),
                paintWorksMultiplier.Multiplier);

            decimal coating = _paintWorksCalculatorService.CalculateCoating(InputModel.AreaOfApplication.StripAndParseAsDecimal(), paintWorksMultiplier.Multiplier);

            decimal neutralizer = _paintWorksCalculatorService.CalculateNeutralizer(primerPaint);

            OutputModel.PrimerPaint = $"{primerPaint:N2} gallons of Primer Paint";
            OutputModel.SideBySideCoating = $"{coating:N2} gallons of Coating (Side by Side)";
            OutputModel.Neutralizer = $"{neutralizer:N2} liters of Neutralizer";

            IsResultVisible = true;
        }

        private void LoadProjectInput(Guid obj)
        {
            //var tileworkProject = _context.Set<PaintworksInput>().FirstOrDefault(tilework => tilework.ProjectId == obj);

            //if (tileworkProject is not null)
            //{
            //    InputModel.SelectedMultiplier = Multipliers.FirstOrDefault(multiplier => multiplier.Name == tileworkProject.SelectedMultiplier);
            //    InputModel.AreaOfWorkDesignation = tileworkProject.AreaOfWorkDesignation;
            //}
        }
    }
}