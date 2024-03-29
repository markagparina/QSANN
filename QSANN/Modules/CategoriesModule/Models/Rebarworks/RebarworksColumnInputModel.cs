﻿using Prism.Mvvm;
using QSANN.Core.Extensions;

namespace CategoriesModule.Models
{
    public class RebarworksColumnInputModel : BindableBase
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

        private string _numbersOfColumn;

        public string NumbersOfColumn
        {
            get { return _numbersOfColumn; }
            set { SetProperty(ref _numbersOfColumn, value); }
        }

        private string _sizeOfMainbar;

        public string SizeOfMainbar
        {
            get { return _sizeOfMainbar; }
            set { SetProperty(ref _sizeOfMainbar, value.AppendIfNotExists(" mm")); }
        }

        private string _sizeOfLateralties;

        public string SizeOfLateralties
        {
            get { return _sizeOfLateralties; }
            set { SetProperty(ref _sizeOfLateralties, value.AppendIfNotExists(" mm")); }
        }
    }
}