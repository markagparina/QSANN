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
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CategoriesModule.ViewModels
{
    [Display(Name = "Tile works")]
    public class TileworksViewModel : MenuItem<TileworksInputModel, TileworksInput>
    {
        private ObservableCollection<TileworksMultiplierModel> _multipliers;
        private readonly ITileworksCalculatorService _tileworksCalculatorService;
        private readonly TileworksInputValidator _validator = new();

        public ObservableCollection<TileworksMultiplierModel> Multipliers
        {
            get { return _multipliers; }
            set { SetProperty(ref _multipliers, value); }
        }

        public override TileworksInputModel InputModel { get; set; } = new();
        public TileworksOutputModel OutputModel { get; set; } = new();

        public override string Title => "Tile works";

        private DelegateCommandWithValidator<TileworksInputModel, TileworksInputValidator> _calculateCommand;

        public DelegateCommandWithValidator<TileworksInputModel, TileworksInputValidator> CalculateCommand => _calculateCommand
            ??= new DelegateCommandWithValidator<TileworksInputModel, TileworksInputValidator>(ExecuteCalculateCommand, InputModel, _validator, new ErrorDialog());

        public TileworksViewModel(IRegionManager regionManager,
            ITileworksCalculatorService tileworksCalculatorService,
            IEventAggregator eventAggregator,
            AppDbContext context) : base(regionManager, context, eventAggregator)
        {
            _tileworksCalculatorService = tileworksCalculatorService;
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

        protected override void LoadProjectInput(Guid projectId)
        {
            var tileworkProject = Context.Set<TileworksInput>().FirstOrDefault(tilework => tilework.ProjectId == projectId);

            if (tileworkProject is not null)
            {
                InputModel.SelectedMultiplier = Multipliers.FirstOrDefault(multiplier => multiplier.Name == tileworkProject.SelectedMultiplier);
                InputModel.AreaOfWorkDesignation = tileworkProject.AreaOfWorkDesignation;
            }
        }

        protected override void SaveProjectInput(Guid projectId)
        {
            var tileworkProject = Context.Set<TileworksInput>().FirstOrDefault(tilework => tilework.ProjectId == projectId);

            var projectToSaveTo = tileworkProject ?? new TileworksInput();
            bool saveMode = tileworkProject is null;

            projectToSaveTo.SelectedMultiplier = InputModel.SelectedMultiplier?.Name;
            projectToSaveTo.AreaOfWorkDesignation = InputModel.AreaOfWorkDesignation;
            projectToSaveTo.ProjectId = projectId;

            if (saveMode)
            {
                Context.Set<TileworksInput>().Add(projectToSaveTo);
            }
            else
            {
                Context.Set<TileworksInput>().Update(projectToSaveTo);
            }

            Context.SaveChanges();
        }
    }
}