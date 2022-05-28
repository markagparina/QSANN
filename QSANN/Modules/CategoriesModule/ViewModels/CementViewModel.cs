using CategoriesModule.Dialogs;
using CategoriesModule.Models;
using CategoriesModule.Validators;
using Prism.Regions;
using QSANN.Core.Commands;
using QSANN.Core.Extensions;
using QSANN.Core.Navigation;
using QSANN.Services.Interfaces;

namespace CategoriesModule.ViewModels;

public class CementViewModel : MenuItem
{
    private readonly ICementCalculatorService _cementCalculatorService;
    private DelegateCommandWithValidator<CementInputModel, CementInputModelValidator> _calculateCommand;
    private CementInputModelValidator _validator = new();

    public DelegateCommandWithValidator<CementInputModel, CementInputModelValidator> CalculateCommand => _calculateCommand
        ??= new DelegateCommandWithValidator<CementInputModel, CementInputModelValidator>(ExecuteCalculateCommand, InputModel, _validator, new ErrorDialog());
    public override string Title => "Cement";
    public CementInputModel InputModel { get; set; } = new();
    public CementOutputModel OutputModel { get; set; } = new();

    private bool _isResultVisible;
    public bool IsResultVisible
    {
        get { return _isResultVisible; }
        set { SetProperty(ref _isResultVisible, value); }
    }

    public CementViewModel(ICementCalculatorService cementCalculatorService, IRegionManager regionManager) : base(regionManager)
    {
        _cementCalculatorService = cementCalculatorService;

    }
    private void ExecuteCalculateCommand()
    {
        decimal volume = _cementCalculatorService.CalculateVolume(
                    InputModel.LengthOfColumn.StripAndParseAsDecimal(),
                    InputModel.WidthOfColumn.StripAndParseAsDecimal(),
                    InputModel.HeightOfColumn.StripAndParseAsDecimal(),
                    InputModel.NumbersOfColumn.StripAndParseAsDecimal());


        OutputModel.CementM = $"{(volume * 9m)}";

        OutputModel.Sand = $"{(volume * .5m)}";

        OutputModel.Gravel = $"{(volume * .9m)}";

        IsResultVisible = true;
    }


}
