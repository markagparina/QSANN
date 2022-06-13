using Prism.Mvvm;
using QSANN.Core.Extensions;

namespace CategoriesModule.Models
{
    public class ConcreteSlabInputModel : BindableBase
    {
        private string _lengthOfSlab;

        public string LengthOfSlab
        {
            get { return _lengthOfSlab; }
            set { SetProperty(ref _lengthOfSlab, value.AppendIfNotExists("m")); }
        }

        private string _widthOfSlab;

        public string WidthOfSlab
        {
            get { return _widthOfSlab; }
            set { SetProperty(ref _widthOfSlab, value.AppendIfNotExists("m")); }
        }

        private string _thicknessOfSlab;

        public string ThicknessOfSlab
        {
            get { return _thicknessOfSlab; }
            set { SetProperty(ref _thicknessOfSlab, value.AppendIfNotExists("m")); }
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