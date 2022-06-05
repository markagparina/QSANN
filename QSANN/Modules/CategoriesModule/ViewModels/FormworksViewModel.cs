using Prism.Commands;
using Prism.Regions;
using QSANN.Core;
using QSANN.Core.Navigation;

namespace CategoriesModule.ViewModels
{
    public class FormworksViewModel : MenuItem
    {
        private readonly IRegionManager _regionManager;
        public override string Title => "Formworks and Scaffoldings";

        private string _selectedTab;
        public string SelectedTab
        {
            get { return _selectedTab; }
            set
            {
                if (SetProperty(ref _selectedTab, value))
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        string view = $"Formworks{value}View";
                        _regionManager.RequestNavigate(RegionNames.FormworksContentRegion, view);
                    }
                }
            }
        }

        private DelegateCommand<string> _navigateCommand;
        public DelegateCommand<string> NavigateCommand => _navigateCommand ??= new DelegateCommand<string>(ExecuteNavigateCommand);


        public FormworksViewModel(IRegionManager regionManager) : base(regionManager)
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
