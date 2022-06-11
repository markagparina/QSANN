using Prism.Mvvm;

namespace CategoriesModule.Models
{
    public class PaintworksOutputModel : BindableBase
    {
        private string _primerPaint;

        public string PrimerPaint
        {
            get { return _primerPaint; }
            set { SetProperty(ref _primerPaint, value); }
        }

        private string _sideBySideCoating;

        public string SideBySideCoating
        {
            get { return _sideBySideCoating; }
            set { SetProperty(ref _sideBySideCoating, value); }
        }

        private string _neutralizer;

        public string Neutralizer
        {
            get { return _neutralizer; }
            set { SetProperty(ref _neutralizer, value); }
        }
    }
}
