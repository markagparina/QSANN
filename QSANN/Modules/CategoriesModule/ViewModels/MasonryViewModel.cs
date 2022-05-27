using CategoriesModule.Models;
using CategoriesModule.Validators;
using CategoriesModule.Views;
using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Regions;
using Prism.Services.Dialogs;
using QSANN.Core.Extensions;
using QSANN.Core.Navigation;
using QSANN.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace CategoriesModule.ViewModels
{
    public class MasonryViewModel : MenuItem
    {

        public MasonryInputModel InputModel { get; set; } = new();
        public MasonryOutputModel OutputModel { get; set; } = new();

        private DelegateCommand _calculateCommand;
        public DelegateCommand CalculateCommand => _calculateCommand ??= new DelegateCommand(ExecuteCalculateCommandAsync);

        async void ExecuteCalculateCommandAsync()
        {
            var validationResult = _validator.Validate(InputModel);

            if (!validationResult.IsValid)
            {
                var view = new MessageDialog
                {
                    DataContext = new MessageDialogViewModel(null, validationResult.Errors.Select(err => err.ErrorMessage))
                };


                var result = await DialogHost.Show(view);

                return;
            }


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
            OutputModel.Sand = $"{sandTotal} cubic meters of Sand";
            OutputModel.HorizontalBars = $"{horizontalBars} pieces of 6 meter Horizontal Bars";
            OutputModel.VerticalBars = $"{verticalBars} pieces of 6 meter Vertical Bars";
            IsResultVisible = true;

        }

        private string _message;
        private readonly IMasonryCalculatorService _masonryCalculatorService;
        private readonly IDialogService _dialogService;
        private readonly MasonryInputModelValidator _validator = new();

        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        private bool _isResultvisible;
        public bool IsResultVisible
        {
            get { return _isResultvisible; }
            set { SetProperty(ref _isResultvisible, value); }
        }


        public override string Title => "Masonry";

        public MasonryViewModel(IMasonryCalculatorService masonryCalculatorService, IRegionManager regionManager, IDialogService dialogService) : base(regionManager)
        {
            _masonryCalculatorService = masonryCalculatorService;
            _dialogService = dialogService;
        }
    }
}
