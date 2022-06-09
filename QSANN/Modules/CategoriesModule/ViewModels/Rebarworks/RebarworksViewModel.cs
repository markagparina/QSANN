using Prism.Commands;
using Prism.Regions;
using QSANN.Core;
using QSANN.Core.Navigation;

namespace CategoriesModule.ViewModels
{
    public class RebarworksViewModel : MenuItem
    {
        public override string Title => "Rebarworks";

        private string _selectedTab;
        private readonly IRegionManager _regionManager;

        public string SelectedTab
        {
            get { return _selectedTab; }
            set
            {
                if (SetProperty(ref _selectedTab, value) && !string.IsNullOrEmpty(value))
                {
                    string view = $"Rebarworks{value}View";
                    _regionManager.RequestNavigate(RegionNames.RebarworksContentRegion, view);
                }
            }
        }

        private DelegateCommand<string> _navigateCommand;
        public DelegateCommand<string> NavigateCommand => _navigateCommand ??= new DelegateCommand<string>(ExecuteNavigateCommand);

        public RebarworksViewModel(IRegionManager regionManager) : base(regionManager)
        {
            _regionManager = regionManager;
            SelectedTab = "Column";
        }

        private void ExecuteNavigateCommand(string param)
        {
            SelectedTab = param;
        }
    }
}