using Prism.Mvvm;

namespace CategoriesModule.Models
{
    public class TileworksOutputModel : BindableBase
    {
        private string _numberOfPieces;

        public string NumberOfPieces
        {
            get { return _numberOfPieces; }
            set { SetProperty(ref _numberOfPieces, value); }
        }

        private string _numberOf40KgBagsOfCement;

        public string NumberOf40KgBagsOfCement
        {
            get { return _numberOf40KgBagsOfCement; }
            set { SetProperty(ref _numberOf40KgBagsOfCement, value); }
        }

        private string _numberOfBagOfAdhesive;

        public string NumberOfBagOfAdhesive
        {
            get { return _numberOfBagOfAdhesive; }
            set { SetProperty(ref _numberOfBagOfAdhesive, value); }
        }

        private string _numberOfKgOfGrout;

        public string NumberOfKgOfGrout
        {
            get { return _numberOfKgOfGrout; }
            set { SetProperty(ref _numberOfKgOfGrout, value); }
        }
    }
}