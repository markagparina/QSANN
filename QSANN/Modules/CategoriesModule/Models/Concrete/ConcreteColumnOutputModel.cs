using Prism.Mvvm;

namespace CategoriesModule.Models;

public class ConcreteColumnOutputModel : BindableBase
{
    private string _cementMixture;

    public string CementMixture
    {
        get { return _cementMixture; }
        set { SetProperty(ref _cementMixture, value); }
    }

    private string _sand;

    public string Sand
    {
        get { return _sand; }
        set { SetProperty(ref _sand, value); }
    }

    private string _gravel;

    public string Gravel
    {
        get { return _gravel; }
        set { SetProperty(ref _gravel, value); }
    }
}