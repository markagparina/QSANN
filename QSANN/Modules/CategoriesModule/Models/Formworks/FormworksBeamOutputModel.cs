using Prism.Mvvm;

namespace CategoriesModule.Models
{
    public class FormworksBeamOutputModel : BindableBase
    {
        private string _numberOfPlywood;

        public string NumberOfPlywood
        {
            get { return _numberOfPlywood; }
            set { SetProperty(ref _numberOfPlywood, value); }
        }

        private string _numberOfBoardFeetLumber;

        public string NumberOfBoardFeetLumber
        {
            get { return _numberOfBoardFeetLumber; }
            set { SetProperty(ref _numberOfBoardFeetLumber, value); }
        }
    }
}