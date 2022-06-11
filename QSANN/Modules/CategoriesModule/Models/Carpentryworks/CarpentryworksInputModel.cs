using Prism.Mvvm;

namespace CategoriesModule.Models
{
    public class CarpentryworksInputModel : BindableBase
    {
        private string _areaOfDesignation;

        public string AreaOfDesignation
        {
            get { return _areaOfDesignation; }
            set { SetProperty(ref _areaOfDesignation, value); }
        }

        private string _sizeOfLumber;

        public string SizeOfLumber
        {
            get { return _sizeOfLumber; }
            set { SetProperty(ref _sizeOfLumber, value); }
        }
    }
}
