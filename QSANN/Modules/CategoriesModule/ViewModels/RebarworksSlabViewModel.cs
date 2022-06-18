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
    public class RebarworksSlabViewModel : ViewModelBase<RebarworksSlabInputModel, RebarworksSlabInput, RebarworksSlabOutput>
    {
        private ObservableCollection<RebarworksSlabTypeMultiplier> _multipliers;
        private readonly IRebarworksSlabCalculatorService _rebarworksSlabCalculatorService;
        private readonly AppDbContext _context;
        private readonly RebarworksSlabInputValidator _validator = new();

        public ObservableCollection<RebarworksSlabTypeMultiplier> Multipliers
        {
            get { return _multipliers; }
            set { SetProperty(ref _multipliers, value); }
        }

        public override RebarworksSlabInputModel InputModel { get; set; } = new();
        public RebarworksSlabOutputModel OutputModel { get; set; } = new();

        public override RebarworksSlabOutput OutputStorage { get; set; } = new();

        private DelegateCommandWithValidator<RebarworksSlabInputModel, RebarworksSlabInputValidator> _calculateCommand;

        public DelegateCommandWithValidator<RebarworksSlabInputModel, RebarworksSlabInputValidator> CalculateCommand => _calculateCommand
            ??= new DelegateCommandWithValidator<RebarworksSlabInputModel, RebarworksSlabInputValidator>(ExecuteCalculateCommand, InputModel, _validator, new ErrorDialog());

        public RebarworksSlabViewModel(IRebarworksSlabCalculatorService rebarworksSlabCalculatorService,
            IEventAggregator eventAggregator,
            AppDbContext context) : base(context, eventAggregator)
        {
            _rebarworksSlabCalculatorService = rebarworksSlabCalculatorService;
            _context = context;
            Multipliers = new ObservableCollection<RebarworksSlabTypeMultiplier>(_rebarworksSlabCalculatorService.GetMultipliers());
        }

        private void ExecuteCalculateCommand()
        {
            var multiplier = Multipliers.FirstOrDefault(multiplier => multiplier.SlabType == (int)InputModel.OneWayOrTwoWay
                                                                           && multiplier.Name == InputModel.SteelbarSpacing);

            decimal steelbar = OutputStorage.Steelbar = _rebarworksSlabCalculatorService.CalculateSteelbar(InputModel.FloorArea.StripAndParseAsDecimal(), multiplier.SteelbarMultiplier);
            decimal tiewire = OutputStorage.Tiewire = _rebarworksSlabCalculatorService.CalculateSteelbar(InputModel.FloorArea.StripAndParseAsDecimal(), multiplier.TiewireMultiplier);

            OutputModel.Steelbar = $"{steelbar} pcs of 6m Steel Bar";
            OutputModel.Tiewire = $"{tiewire} kgs of #16 Tie Wire";

            IsResultVisible = true;
        }

        //private void LoadProjectInput(Guid obj)
        //{
        //    var tileworkProject = _context.Set<RebarworksSlabInput>().FirstOrDefault(tilework => tilework.ProjectId == obj);

        //    if (tileworkProject is not null)
        //    {
        //        InputModel.SelectedMultiplier = Multipliers.FirstOrDefault(multiplier => multiplier.Name == tileworkProject.SelectedMultiplier);
        //        InputModel.AreaOfWorkDesignation = tileworkProject.AreaOfWorkDesignation;
        //    }
        //}
    }
}