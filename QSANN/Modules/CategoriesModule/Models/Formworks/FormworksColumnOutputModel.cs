using Prism.Mvvm;
using QSANN.Core.Extensions;

namespace CategoriesModule.Models
{
    public class FormworksColumnOutputModel : BindableBase
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
