﻿using Prism.Mvvm;
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

        private string _thicknessOfFooting;

        public string ThicknessOfFooting
        {
            get { return _thicknessOfFooting; }
            set { SetProperty(ref _thicknessOfFooting, value.AppendIfNotExists(" meters")); }
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