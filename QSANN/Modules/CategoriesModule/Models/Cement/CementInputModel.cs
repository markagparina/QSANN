using Prism.Mvvm;
using QSANN.Core.Extensions;

namespace CategoriesModule.Models
{
    public class CementInputModel : BindableBase
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

        private string _numbersOfColumn;
        public string NumbersOfColumn
        {
            get { return _numbersOfColumn; }
            set { SetProperty(ref _numbersOfColumn, value.AppendIfNotExists(" meters")); }
        }
    }
}
