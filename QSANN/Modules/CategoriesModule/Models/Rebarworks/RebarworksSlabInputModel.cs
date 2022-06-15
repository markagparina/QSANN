using Prism.Mvvm;
using QSANN.Core.Enums;
using QSANN.Core.Extensions;
using System;

namespace CategoriesModule.Models
{
    public class RebarworksSlabInputModel : BindableBase
    {
        private string _floorArea;

        public string FloorArea
        {
            get { return _floorArea; }
            set { SetProperty(ref _floorArea, value.AppendIfNotExists("")); }
        }

        private string _steelBarSpacing;

        public string SteelbarSpacing
        {
            get { return _steelBarSpacing; }
            set { SetProperty(ref _steelBarSpacing, value); }
        }

        private string _sizeOfSteelbar;

        public string SizeOfSteelbar
        {
            get { return _sizeOfSteelbar; }
            set { SetProperty(ref _sizeOfSteelbar, value); }
        }

        private SlabType _oneWayOrTwoWay;

        public SlabType OneWayOrTwoWay
        {
            get { return _oneWayOrTwoWay; }
            set { SetProperty(ref _oneWayOrTwoWay, value); }
        }
    }
}