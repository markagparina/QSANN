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
using System.ComponentModel.DataAnnotations;

namespace CategoriesModule.ViewModels
{
    [Display(Name = "Carpentry Works")]
    public class CarpentryworksViewModel : MenuItem<CarpentryworksInputModel, CarpentryworksInput>
    {
        private ObservableCollection<CarpentryworksMultiplierModel> _multipliers;
        private readonly ICarpentryworksCalculatorService _carpentryworksCalculatorService;
        private readonly CarpentryworksInputValidator _validator = new();

        public ObservableCollection<CarpentryworksMultiplierModel> Multipliers
        {
            get { return _multipliers; }
            set { SetProperty(ref _multipliers, value); }
        }

        public override CarpentryworksInputModel InputModel { get; set; } = new();
        public CarpentryworksOutputModel OutputModel { get; set; } = new();

        public override string Title => "Carpentry Works";

        private DelegateCommandWithValidator<CarpentryworksInputModel, CarpentryworksInputValidator> _calculateCommand;

        public DelegateCommandWithValidator<CarpentryworksInputModel, CarpentryworksInputValidator> CalculateCommand => _calculateCommand
            ??= new DelegateCommandWithValidator<CarpentryworksInputModel, CarpentryworksInputValidator>(ExecuteCalculateCommand, InputModel, _validator, new ErrorDialog());

        public CarpentryworksViewModel(IRegionManager regionManager,
            ICarpentryworksCalculatorService carpentryworksCalculatorService,
            AppDbContext context, IEventAggregator eventAggregator) : base(regionManager, context, eventAggregator)
        {
            _carpentryworksCalculatorService = carpentryworksCalculatorService;
            Multipliers = new ObservableCollection<CarpentryworksMultiplierModel>(_carpentryworksCalculatorService.GetMultipliers());
        }

        private void ExecuteCalculateCommand()
        {
            var lumberMultiplier = Multipliers.FirstOrDefault(multiplier => multiplier.SizeOfLumber == InputModel.SizeOfLumber);

            decimal plyboard = _carpentryworksCalculatorService.CalculatePlyboard(InputModel.AreaOfDesignation.StripAndParseAsDecimal());
            decimal lumber = _carpentryworksCalculatorService.CalculateSizeOfLumber(InputModel.AreaOfDesignation.StripAndParseAsDecimal(), lumberMultiplier.Multiplier);
            decimal commonWireNail = _carpentryworksCalculatorService.CalculateCommonWireNail(InputModel.AreaOfDesignation.StripAndParseAsDecimal());

            OutputModel.Plyboard = $"{plyboard:N2} pcs of 4'x8' Plyboard";
            OutputModel.SizeOfLumber = $"{lumber:N2} bd.ft of Lumber @ 40x40 Spacing";
            OutputModel.CommonWireNail = $"{commonWireNail:N2} kg of Coommon Wire Nail";

            IsResultVisible = true;
        }
    }
}