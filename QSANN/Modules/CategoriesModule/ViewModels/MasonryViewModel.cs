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
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CategoriesModule.ViewModels
{
    [Display(Name = "Masonry")]
    public class MasonryViewModel : MenuItem<MasonryInputModel, MasonryInput>
    {
        private readonly IMasonryCalculatorService _masonryCalculatorService;
        private readonly AppDbContext _context;
        private readonly MasonryInputModelValidator _validator = new();

        public override MasonryInputModel InputModel { get; set; } = new();
        public MasonryOutputModel OutputModel { get; set; } = new();
        public ErrorDialog ErrorDialog { get; set; } = new();

        private DelegateCommandWithValidator<MasonryInputModel, MasonryInputModelValidator> _calculateCommand;

        public DelegateCommandWithValidator<MasonryInputModel, MasonryInputModelValidator> CalculateCommand
            => _calculateCommand ??= new DelegateCommandWithValidator<MasonryInputModel, MasonryInputModelValidator>
            (async () => await ExecuteCalculateCommandAsync(), InputModel, _validator, ErrorDialog);

        public override string Title => "Masonry";

        public MasonryViewModel(IMasonryCalculatorService masonryCalculatorService, IRegionManager regionManager, AppDbContext context, IEventAggregator eventAggregator) :
        base(regionManager, context, eventAggregator)
        {
            _masonryCalculatorService = masonryCalculatorService;
            _context = context;
            //eventAggregator.GetEvent<LoadProjectEvent>().Subscribe(LoadProjectInput, ThreadOption.UIThread);
        }

        private Task ExecuteCalculateCommandAsync()
        {
            var model = _masonryCalculatorService.CalculateThicknessAndSandMultipliers(InputModel.ThicknessInMillimeter.StripAndParseAsDecimal(), InputModel.ClassMixtureForPlaster);

            decimal area = _masonryCalculatorService.CalculateWallArea(InputModel.HeightOfWall.StripAndParseAsDecimal(), InputModel.LengthOfWall.StripAndParseAsDecimal());
            decimal concreteHollowblocks = _masonryCalculatorService.CalculateCHB(area);

            decimal cementM = area * _masonryCalculatorService.CalculateClassMixtureForMortarMultiplier(InputModel.ClassMixtureForMortar);
            decimal sandM = area * 1;
            decimal cementP = area * InputModel.ThicknessInMillimeter.StripAndParseAsDecimal();
            decimal sandP = area * model.Sand;

            decimal cementTotal = cementM + cementP;
            decimal sandTotal = sandM + sandP;

            decimal numberOfPiecesByHeight = InputModel.HeightOfWall.StripAndParseAsDecimal() / InputModel.HorizontalBarSpacing.StripAndParseAsDecimal();
            decimal numberOfPiecesByLength = InputModel.LengthOfWall.StripAndParseAsDecimal() / InputModel.HorizontalBarSpacing.StripAndParseAsDecimal();

            decimal horizontalBars = numberOfPiecesByHeight * InputModel.LengthOfWall.StripAndParseAsDecimal() * 1.1m / 6m;
            decimal verticalBars = numberOfPiecesByLength * InputModel.HeightOfWall.StripAndParseAsDecimal() * 1.2m / 6m;

            OutputModel.ConcreteHollowBlocks = $"{concreteHollowblocks} pcs of Hollowblocks";
            OutputModel.Cement = $"{cementTotal} Bags of Cement";
            OutputModel.Sand = $"{sandTotal}m\xB3 of Sand";
            OutputModel.HorizontalBars = $"{horizontalBars} pieces of 6 meter Horizontal Bars";
            OutputModel.VerticalBars = $"{verticalBars} pieces of 6 meter Vertical Bars";
            IsResultVisible = true;
            return Task.CompletedTask;
        }

        //private void LoadProjectInput(Guid projectId)
        //{
        //    var masonryProject = _context.Set<MasonryInput>().FirstOrDefault(masonry => masonry.ProjectId == projectId);

        //    if (masonryProject is not null)
        //    {
        //        InputModel.LengthOfWall = masonryProject.LengthOfWall;
        //        InputModel.HeightOfWall = masonryProject.HeightOfWall;
        //        InputModel.HorizontalBarSpacing = masonryProject.HorizontalBarSpacing;
        //        InputModel.VerticalBarSpacing = masonryProject.VerticalBarSpacing;
        //        InputModel.ClassMixtureForMortar = masonryProject.ClassMixtureForMortar;
        //        InputModel.ClassMixtureForPlaster = masonryProject.ClassMixtureForPlaster;
        //        InputModel.ThicknessInMillimeter = masonryProject.ThicknessInMillimeter;
        //    }

        //}
    }
}