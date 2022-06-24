using Monitoring.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using QSANN.Core;

namespace Monitoring
{
    public class MonitoringModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public MonitoringModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion<CarpentryworksMonitoringView>(RegionNames.MonitoringContentRegion);
            _regionManager.RegisterViewWithRegion<ConcreteMonitoringView>(RegionNames.MonitoringContentRegion);
            _regionManager.RegisterViewWithRegion<PaintworksMonitoringView>(RegionNames.MonitoringContentRegion);
            _regionManager.RegisterViewWithRegion<PaintworksMonitoringView>(RegionNames.MonitoringContentRegion);
            _regionManager.RegisterViewWithRegion<MasonryMonitoringView>(RegionNames.MonitoringContentRegion);
            _regionManager.RegisterViewWithRegion<OthersMonitoringView>(RegionNames.MonitoringContentRegion);
            _regionManager.RegisterViewWithRegion<TileworksMonitoringView>(RegionNames.MonitoringContentRegion);
            _regionManager.RegisterViewWithRegion<FormworksMonitoringView>(RegionNames.MonitoringContentRegion);
            _regionManager.RegisterViewWithRegion<RebarworksMonitoringView>(RegionNames.MonitoringContentRegion);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}