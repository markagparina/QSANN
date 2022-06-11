using Prism.Mvvm;

namespace CategoriesModule.Models
{
    public class PaintworksInputModel : BindableBase
    {
        private string _areaOfApplication;

        public string AreaOfApplication
        {
            get { return _areaOfApplication; }
            set { SetProperty(ref _areaOfApplication, value); }
        }

        private string _finish;

        public string Finish
        {
            get { return _finish; }
            set { SetProperty(ref _finish, value); }
        }

    }
}
