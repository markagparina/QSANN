using CategoriesModule.Dialogs;
using CategoriesModule.Models;
using CategoriesModule.Validators;
using Prism.Regions;
using QSANN.Core.Commands;
using QSANN.Core.Extensions;
using QSANN.Core.Navigation;
using QSANN.Services.Interfaces;
using System.Threading.Tasks;

namespace CategoriesModule.ViewModels
{
    public class MasonryViewModel : MenuItem
    {
        private readonly IMasonryCalculatorService _masonryCalculatorService;
        private readonly MasonryInputModelValidator _validator = new();

        public MasonryInputModel InputModel { get; set; } = new();
        public MasonryOutputModel OutputModel { get; set; } = new();
        public ErrorDialog ErrorDialog { get; set; } = new();

        private DelegateCommandWithValidator<MasonryInputModel, MasonryInputModelValidator> _calculateCommand;

        public DelegateCommandWithValidator<MasonryInputModel, MasonryInputModelValidator> CalculateCommand
            => _calculateCommand ??= new DelegateCommandWithValidator<MasonryInputModel, MasonryInputModelValidator>
            (async () => await ExecuteCalculateCommandAsync(), InputModel, _validator, ErrorDialog);

        private bool _isResultvisible;

        public bool IsResultVisible
        {
            get { return _isResultvisible; }
            set { SetProperty(ref _isResultvisible, value); }
        }

        public override string Title => "Masonry";

        public MasonryViewModel(IMasonryCalculatorService masonryCalculatorService, IRegionManager regionManager) : base(regionManager)
        {
            _masonryCalculatorService = masonryCalculatorService;
        }

        private Task ExecuteCalculateCommandAsync()
        {
            var model = _masonryCalculatorService.CalculateThicknessAndSandMultipliers(InputModel.ThicknessInMillimeter.StripAndParseAsDecimal(), InputModel.ClassMixtureForPlaster);

            decimal area = _masonryCalculatorService.CalculateWallArea(InputModel.HeightOfWall.StripAndParseAsDecimal(), InputModel.LengthOfWall.StripAndParseAsDecimal());
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

            OutputModel.Cement = $"{cementTotal} Bags of Cement";
            OutputModel.Sand = $"{sandTotal}m\xB3 of Sand";
            OutputModel.HorizontalBars = $"{horizontalBars} pieces of 6 meter Horizontal Bars";
            OutputModel.VerticalBars = $"{verticalBars} pieces of 6 meter Vertical Bars";
            IsResultVisible = true;
            return Task.CompletedTask;
        }
    }
}