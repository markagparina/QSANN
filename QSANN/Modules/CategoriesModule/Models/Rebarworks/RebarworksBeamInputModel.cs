﻿using Prism.Mvvm;
using QSANN.Core.Extensions;

namespace CategoriesModule.Models
{
    public class RebarworksBeamInputModel : BindableBase
    {
        private string _lengthOfBeam;

        public string LengthOfBeam
        {
            get { return _lengthOfBeam; }
            set { SetProperty(ref _lengthOfBeam, value.AppendIfNotExists(" meters")); }
        }

        private string _widthOfBeam;

        public string WidthOfBeam
        {
            get { return _widthOfBeam; }
            set { SetProperty(ref _widthOfBeam, value.AppendIfNotExists(" meters")); }
        }

        private string _heightOfBeam;

        public string HeightOfBeam
        {
            get { return _heightOfBeam; }
            set { SetProperty(ref _heightOfBeam, value.AppendIfNotExists(" meters")); }
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