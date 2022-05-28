using Prism.Mvvm;

namespace CategoriesModule.Models
{
    public class MasonryOutputModel : BindableBase
    {
        private string _cement;
        public string Cement
        {
            get { return _cement; }
            set { SetProperty(ref _cement, value); }
        }
        private string _sand;
        public string Sand
        {
            get { return _sand; }
            set { SetProperty(ref _sand, value); }
        }

        private string _horizontalBars;
        public string HorizontalBars
        {
            get { return _horizontalBars; }
            set { SetProperty(ref _horizontalBars, value); }
        }

        private string _verticalBars;
        public string VerticalBars
        {
            get { return _verticalBars; }
            set { SetProperty(ref _verticalBars, value); }
        }
    }
}
