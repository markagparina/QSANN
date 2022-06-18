using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using QSANN.Core;
using QSANN.Core.Mvvm;

namespace QSANN.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private DelegateCommand<string> _navigateCommand;
        private readonly IRegionManager _regionManager;

        public DelegateCommand<string> NavigateCommand => _navigateCommand ??= new DelegateCommand<string>(ExecuteNavigateCommand);

        private void ExecuteNavigateCommand(string view)
        {
            switch (view)
            {
                case "QuantitySurveying":
                    _regionManager.RequestNavigate(RegionNames.ModuleRegion, "QuantitySurveyingView");
                    break;

                case "Monitoring":
                    _regionManager.RequestNavigate(RegionNames.ModuleRegion, "MonitoringView");
                    break;
            }
        }

        public HomeViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
    }
}