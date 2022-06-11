using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoriesModule.Models.Rebarworks
{
    public class RebarworksFootingOutputModel : BindableBase
    {
        private string _steelbar;

        public string Steelbar
        {
            get { return _steelbar; }
            set { SetProperty(ref _steelbar, value); }
        }

        private string _tiewire;

        public string Tiewire
        {
            get { return _tiewire; }
            set { SetProperty(ref _tiewire, value); }
        }
    }
}
