using Prism.Mvvm;
using QSANN.Core.Extensions;

namespace CategoriesModule.Models
{
    public class FormworksColumnInputModel : BindableBase
    {
        private string _lengthOfColumn;
        public string LengthOfColumn
        {
            get { return _lengthOfColumn; }
            set { SetProperty(ref _lengthOfColumn, value.AppendIfNotExists(" meters")); }
        }

        private string _widthOfColumn;
        public string WidthOfColumn
        {
            get { return _widthOfColumn; }
            set { SetProperty(ref _widthOfColumn, value.AppendIfNotExists(" meters")); }
        }

        private string _heightOfColumn;
        public string HeightOfColumn
        {
            get { return _heightOfColumn; }
            set { SetProperty(ref _heightOfColumn, value.AppendIfNotExists(" meters")); }
        }

        private string _numbersOfCount;
        public string NumberOfCounts
        {
            get { return _numbersOfCount; }
            set { SetProperty(ref _numbersOfCount, value); }
        }

        private string _lumberSize = "2x2";
        public string LumberSize
        {
            get { return _lumberSize; }
            set { SetProperty(ref _lumberSize, value); }
        }

        private string _thicknessOfPlywood = "1/4";
        public string ThicknessOfPlywood
        {
            get { return _thicknessOfPlywood; }
            set { SetProperty(ref _thicknessOfPlywood, value); }
        }
    }
}
