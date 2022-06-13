using Prism.Mvvm;
using QSANN.Core.Extensions;

namespace CategoriesModule.Models
{
    public class FormworksBeamInputModel : BindableBase
    {
        private string _lengthOfBeam;

        public string LengthOfBeam
        {
            get { return _lengthOfBeam; }
            set { SetProperty(ref _lengthOfBeam, value.AppendIfNotExists("m")); }
        }

        private string _widthOfBeam;

        public string WidthOfBeam
        {
            get { return _widthOfBeam; }
            set { SetProperty(ref _widthOfBeam, value.AppendIfNotExists("m")); }
        }

        private string _heightOfBeam;

        public string HeightOfBeam
        {
            get { return _heightOfBeam; }
            set { SetProperty(ref _heightOfBeam, value.AppendIfNotExists("m")); }
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