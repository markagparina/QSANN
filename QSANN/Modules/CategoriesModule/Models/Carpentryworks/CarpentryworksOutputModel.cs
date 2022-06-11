using Prism.Mvvm;

namespace CategoriesModule.Models
{
    public class CarpentryworksOutputModel : BindableBase
    {
        private string _plyboard;

        public string Plyboard
        {
            get { return _plyboard; }
            set { SetProperty(ref _plyboard, value); }
        }

        private string _sizeOfLumber;

        public string SizeOfLumber
        {
            get { return _sizeOfLumber; }
            set { SetProperty(ref _sizeOfLumber, value); }
        }

        private string _commonWireNail;

        public string CommonWireNail
        {
            get { return _commonWireNail; }
            set { SetProperty(ref _commonWireNail, value); }
        }

    }
}
