using Prism.Mvvm;

namespace CategoriesModule.Models;

public class ConcreteFootingOutputModel : BindableBase
{
    private string _cementM;

    public string CementMixture
    {
        get { return _cementM; }
        set { SetProperty(ref _cementM, value); }
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