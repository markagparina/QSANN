using Prism.Mvvm;
using QSANN.Core.Extensions;

namespace CategoriesModule.Models
{
    public class ConcreteColumnInputModel : BindableBase
    {
        private string _lengthOfColumn;

        public string LengthOfColumn
        {
            get { return _lengthOfColumn; }
            set { SetProperty(ref _lengthOfColumn, value.AppendIfNotExists("m")); }
        }

        private string _widthOfColumn;

        public string WidthOfColumn
        {
            get { return _widthOfColumn; }
            set { SetProperty(ref _widthOfColumn, value.AppendIfNotExists("m")); }
        }

        private string _heightOfColumn;

        public string HeightOfColumn
        {
            get { return _heightOfColumn; }
            set { SetProperty(ref _heightOfColumn, value.AppendIfNotExists("m")); }
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