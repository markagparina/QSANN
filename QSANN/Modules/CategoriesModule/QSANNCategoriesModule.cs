using CategoriesModule.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using QSANN.Core;

namespace CategoriesModule
{
    public class QSANNCategoriesModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public QSANNCategoriesModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate(RegionNames.MainContentRegion, "CementView");
            _regionManager.RequestNavigate(RegionNames.FormworksContentRegion, "FormworksColumnView");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<CementView>("CementView");
            containerRegistry.RegisterForNavigation<MasonryView>("MasonryView");
            containerRegistry.RegisterForNavigation<FormworksView>("FormworksView");
            containerRegistry.RegisterForNavigation<FormworksColumnView>("FormworksColumnView");

            containerRegistry.RegisterForNavigation<FormworksBeamView>("FormworksBeamView");
        }
    }
}