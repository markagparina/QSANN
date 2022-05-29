using Prism.Mvvm;
using QSANN.Core.Extensions;

namespace CategoriesModule.Models
{
    public class ConcreteOtherInputModel : BindableBase
    {
        private string _totalVolume;
        public string TotalVolume
        {
            get { return _totalVolume; }
            set { SetProperty(ref _totalVolume, value.AppendIfNotExists("m\xB3")); }
        }

        private string _numbersOfCount;
        public string NumbersOfCount
        {
            get { return _numbersOfCount; }
            set { SetProperty(ref _numbersOfCount, value); }
        }

        private string _classMixture = "AA";
        public string ClassMixture
        {
            get { return _classMixture; }
            set { SetProperty(ref _classMixture, value); }
        }

    }
}
