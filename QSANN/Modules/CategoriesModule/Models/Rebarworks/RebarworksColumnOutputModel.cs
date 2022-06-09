using Prism.Mvvm;

namespace CategoriesModule.Models;

public class RebarworksColumnOutputModel : BindableBase
{
    private string _steelbar;

    public string Steelbar
    {
        get { return _steelbar; }
        set { SetProperty(ref _steelbar, value); }
    }

    private string _tiewire;

    public string Tiewire
    {
        get { return _tiewire; }
        set { SetProperty(ref _tiewire, value); }
    }
}