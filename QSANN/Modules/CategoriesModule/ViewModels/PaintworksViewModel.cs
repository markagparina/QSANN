using CategoriesModule.Dialogs;
using CategoriesModule.Models;
using CategoriesModule.Validators;
using Prism.Events;
using Prism.Regions;
using QSANN.Core.Commands;
using QSANN.Core.Extensions;
using QSANN.Core.Navigation;
using QSANN.Data;
using QSANN.Data.Entities;
using QSANN.Services.Interfaces;
using QSANN.Services.Interfaces.Models;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CategoriesModule.ViewModels
{
    [Display(Name = "Paint works")]
    public class PaintworksViewModel : MenuItem<PaintworksInputModel, PaintworksInput, PaintworksOutput, PaintworksInputValidator>
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

        public override PaintworksInputModel InputModel { get; set; } = new();
        public PaintworksOutputModel OutputModel { get; set; } = new();
        public override PaintworksOutput OutputStorage { get; set; } = new();

        public override string Title => "Paint works";

        private DelegateCommandWithValidator<PaintworksInputModel, PaintworksInputValidator> _calculateCommand;

        public override DelegateCommandWithValidator<PaintworksInputModel, PaintworksInputValidator> CalculateCommand => _calculateCommand
            ??= new DelegateCommandWithValidator<PaintworksInputModel, PaintworksInputValidator>(ExecuteCalculateCommand, InputModel, _validator, new ErrorDialog());

        public PaintworksViewModel(IRegionManager regionManager,
            IPaintworksCalculatorService paintworksCalculatorService,
            IEventAggregator eventAggregator,
            AppDbContext context) : base(regionManager, context, eventAggregator)
        {
            _paintWorksCalculatorService = paintworksCalculatorService;
            _context = context;
            Multipliers = new ObservableCollection<PaintworksMultiplierModel>(_paintWorksCalculatorService.GetMultipliers());
        }

        private void ExecuteCalculateCommand()
        {
            var paintWorksMultiplier = Multipliers.FirstOrDefault(multiplier => multiplier.Finish == InputModel.Finish);

            decimal primerPaint = _paintWorksCalculatorService.CalculatePrimerPaint(InputModel.AreaOfApplication.StripAndParseAsDecimal(),
                paintWorksMultiplier.Multiplier);

            decimal coating = _paintWorksCalculatorService.CalculateCoating(InputModel.AreaOfApplication.StripAndParseAsDecimal(), paintWorksMultiplier.Multiplier);

            decimal neutralizer = _paintWorksCalculatorService.CalculateNeutralizer(primerPaint);

            OutputStorage.PrimerPaint = primerPaint;
            OutputStorage.SideBySideCoating = coating;
            OutputStorage.Neutralizer = neutralizer;

            OutputModel.PrimerPaint = $"{primerPaint:N2} gallons of Primer Paint";
            OutputModel.SideBySideCoating = $"{coating:N2} gallons of Coating (Side by Side)";
            OutputModel.Neutralizer = $"{neutralizer:N2} liters of Neutralizer";

            IsResultVisible = true;
        }
    }
}