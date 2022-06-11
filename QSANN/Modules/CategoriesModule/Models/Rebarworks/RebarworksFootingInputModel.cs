using Prism.Mvvm;
using QSANN.Core.Extensions;

namespace CategoriesModule.Models
{
    public class RebarworksFootingInputModel : BindableBase
    {
        private string _lengthOfFooting;

        public string LengthOfFooting
        {
            get { return _lengthOfFooting; }
            set { SetProperty(ref _lengthOfFooting, value.AppendIfNotExists(" meters")); }
        }

        private string _widthOfFooting;

        public string WidthOfFooting
        {
            get { return _widthOfFooting; }
            set { SetProperty(ref _widthOfFooting, value.AppendIfNotExists(" meters")); }
        }

        private string _numbersOfFooting;

        public string NumbersOfFooting
        {
            get { return _numbersOfFooting; }
            set { SetProperty(ref _numbersOfFooting, value); }
        }

        private string _sizeOfSteelbar;

        public string SizeOfSteelbar
        {
            get { return _sizeOfSteelbar; }
            set { SetProperty(ref _sizeOfSteelbar, value); }
        }

        private string _spacingOfSteelbar;

        public string SpacingOfSteelbar
        {
            get { return _spacingOfSteelbar; }
            set { SetProperty(ref _spacingOfSteelbar, value); }
        }   
    }
}