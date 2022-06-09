using Prism.Mvvm;
using QSANN.Core.Extensions;

namespace CategoriesModule.Models
{
    public class MasonryInputModel : BindableBase
    {
        private string _heightOfWall;

        public string HeightOfWall
        {
            get { return _heightOfWall; }
            set { SetProperty(ref _heightOfWall, value.AppendIfNotExists(" meters")); }
        }

        private string _lengthOfWall;

        public string LengthOfWall
        {
            get { return _lengthOfWall; }
            set { SetProperty(ref _lengthOfWall, value.AppendIfNotExists(" meters")); }
        }

        private string _horizontalBarSpacing;

        public string HorizontalBarSpacing
        {
            get { return _horizontalBarSpacing; }
            set { SetProperty(ref _horizontalBarSpacing, value.AppendIfNotExists(" meters")); }
        }

        private string _verticalBarSpacing;

        public string VerticalBarSpacing
        {
            get { return _verticalBarSpacing; }
            set { SetProperty(ref _verticalBarSpacing, value.AppendIfNotExists(" meters")); }
        }

        private string _classMixtureForMortar = "A";

        public string ClassMixtureForMortar
        {
            get { return _classMixtureForMortar; }
            set { SetProperty(ref _classMixtureForMortar, value); }
        }

        private string _classMixtureForPlaster = "A";

        public string ClassMixtureForPlaster
        {
            get { return _classMixtureForPlaster; }
            set { SetProperty(ref _classMixtureForPlaster, value); }
        }

        private string _thicknessInMillimeter = "8";

        public string ThicknessInMillimeter
        {
            get { return _thicknessInMillimeter; }
            set { SetProperty(ref _thicknessInMillimeter, value); }
        }
    }
}