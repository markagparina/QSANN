using Prism.Mvvm;
using QSANN.Core.Extensions;

namespace CategoriesModule.Models
{
    public class CarpentryworksInputModel : BindableBase
    {
        private string _areaOfDesignation;

        public string AreaOfDesignation
        {
            get { return _areaOfDesignation; }
            set { SetProperty(ref _areaOfDesignation, value.AppendIfNotExists("m\xB2")); }
        }

        private string _sizeOfLumber;

        public string SizeOfLumber
        {
            get { return _sizeOfLumber; }
            set { SetProperty(ref _sizeOfLumber, value); }
        }
    }
}
