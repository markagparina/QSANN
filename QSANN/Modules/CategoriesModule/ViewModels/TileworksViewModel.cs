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
using QSANN.Services.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace CategoriesModule.ViewModels
{
    public class TileworksViewModel : MenuItem
    {
        private ObservableCollection<TileworksMultiplierModel> _multipliers;
        private readonly ITileworksCalculatorService _tileworksCalculatorService;
        private readonly AppDbContext _context;
        private readonly TileworksInputValidator _validator = new();

        public ObservableCollection<TileworksMultiplierModel> Multipliers
        {
            get { return _multipliers; }
            set { SetProperty(ref _multipliers, value); }
        }

        public TileworksInputModel InputModel { get; set; } = new();
        public TileworksOutputModel OutputModel { get; set; } = new();

        private bool _isResultVisible;

        public bool IsResultVisible
        {
            get { return _isResultVisible; }
            set { SetProperty(ref _isResultVisible, value); }
        }

        public override string Title => "Tileworks";

        private DelegateCommandWithValidator<TileworksInputModel, TileworksInputValidator> _calculateCommand;

        public DelegateCommandWithValidator<TileworksInputModel, TileworksInputValidator> CalculateCommand => _calculateCommand
            ??= new DelegateCommandWithValidator<TileworksInputModel, TileworksInputValidator>(ExecuteCalculateCommand, InputModel, _validator, new ErrorDialog());

        public TileworksViewModel(IRegionManager regionManager,
            ITileworksCalculatorService tileworksCalculatorService,
            IEventAggregator eventAggregator,
            AppDbContext context) : base(regionManager)
        {
            _tileworksCalculatorService = tileworksCalculatorService;
            _context = context;
            eventAggregator.GetEvent<LoadProjectEvent>().Subscribe(LoadProjectInput, ThreadOption.UIThread);
            Multipliers = new ObservableCollection<TileworksMultiplierModel>(_tileworksCalculatorService.GetMultipliers());
        }

        private void ExecuteCalculateCommand()
        {
            decimal pieces = _tileworksCalculatorService.CalculateNumberOfPieces(InputModel.AreaOfWorkDesignation.StripAndParseAsDecimal(), InputModel.SelectedMultiplier.Multiplier);
            decimal numberOf40KgBagsOfCement = _tileworksCalculatorService.CalculateBagsOfCement(InputModel.AreaOfWorkDesignation.StripAndParseAsDecimal());
            decimal numberOfBagsOfAdhesive = _tileworksCalculatorService.CalculateBagsOfAdhesive(InputModel.AreaOfWorkDesignation.StripAndParseAsDecimal());
            decimal numberOfGrout = _tileworksCalculatorService.CalculateNumberOfGrout(InputModel.AreaOfWorkDesignation.StripAndParseAsDecimal());

            OutputModel.NumberOfPieces = $"{pieces} number of pieces";
            OutputModel.NumberOf40KgBagsOfCement = $"{numberOf40KgBagsOfCement} number of 40 kg. bag of Cement";
            OutputModel.NumberOfBagOfAdhesive = $"{numberOfBagsOfAdhesive} number of bag of Adhesive";
            OutputModel.NumberOfKgOfGrout = $"{numberOfGrout} kg/s of grout";

            IsResultVisible = true;
        }

        private void LoadProjectInput(Guid obj)
        {
            var tileworkProject = _context.Tileworks.FirstOrDefault(tilework => tilework.ProjectId == obj);

            if (tileworkProject is not null)
            {
                InputModel.SelectedMultiplier = Multipliers.FirstOrDefault(multiplier => multiplier.Name == tileworkProject.SelectedMultiplier);
                InputModel.AreaOfWorkDesignation = tileworkProject.AreaOfWorkDesignation;
            }
        }
    }
}