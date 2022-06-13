using Prism.Mvvm;
using QSANN.Core.Extensions;

namespace CategoriesModule.Models
{
    public class TileworksInputModel : BindableBase
    {
        private string _areaOfWorkDesignation;

        public string AreaOfWorkDesignation
        {
            get { return _areaOfWorkDesignation; }
            set { SetProperty(ref _areaOfWorkDesignation, value.AppendIfNotExists("m\xB2")); }
        }

        private TileworksMultiplierModel _selectedMultiplier;

        public TileworksMultiplierModel SelectedMultiplier
        {
            get { return _selectedMultiplier; }
            set { SetProperty(ref _selectedMultiplier, value); }
        }
    }
}