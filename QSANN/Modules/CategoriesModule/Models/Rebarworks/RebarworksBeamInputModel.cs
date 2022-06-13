using Prism.Mvvm;
using QSANN.Core.Extensions;

namespace CategoriesModule.Models
{
    public class RebarworksBeamInputModel : BindableBase
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

        private string _widthOfColumn;

        public string WidthOfColumn
        {
            get { return _widthOfColumn; }
            set { SetProperty(ref _widthOfColumn, value.AppendIfNotExists("m")); }
        }

        private string _heightOfBeam;

        public string HeightOfBeam
        {
            get { return _heightOfBeam; }
            set { SetProperty(ref _heightOfBeam, value.AppendIfNotExists("m")); }
        }

        private string _numbersOfBeam;

        public string NumbersOfBeam
        {
            get { return _numbersOfBeam; }
            set { SetProperty(ref _numbersOfBeam, value); }
        }

        private string _sizeOfMainbar;

        public string SizeOfMainbar
        {
            get { return _sizeOfMainbar; }
            set { SetProperty(ref _sizeOfMainbar, value.AppendIfNotExists(" mm")); }
        }

        private string _sizeOfStirrups;

        public string SizeOfStirrups
        {
            get { return _sizeOfStirrups; }
            set { SetProperty(ref _sizeOfStirrups, value.AppendIfNotExists(" mm")); }
        }
    }
}