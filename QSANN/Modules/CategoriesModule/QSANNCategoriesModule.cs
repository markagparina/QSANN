using CategoriesModule.Dialogs;
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
            // Concrete Tabs
            _regionManager.RegisterViewWithRegion<ConcreteView>(RegionNames.MainContentRegion);
            _regionManager.RegisterViewWithRegion<ConcreteColumnView>(RegionNames.ConcreteContentRegion);
            _regionManager.RegisterViewWithRegion<ConcreteBeamView>(RegionNames.ConcreteContentRegion);
            _regionManager.RegisterViewWithRegion<ConcreteSlabView>(RegionNames.ConcreteContentRegion);
            _regionManager.RegisterViewWithRegion<ConcreteFootingView>(RegionNames.ConcreteContentRegion);
            _regionManager.RegisterViewWithRegion<ConcreteOtherView>(RegionNames.ConcreteContentRegion);

            // Formworks Tabs
            _regionManager.RegisterViewWithRegion<FormworksView>(RegionNames.MainContentRegion);
            _regionManager.RegisterViewWithRegion<FormworksColumnView>(RegionNames.FormworksContentRegion);
            _regionManager.RegisterViewWithRegion<FormworksBeamView>(RegionNames.FormworksContentRegion);

            // Rebarworks Tabs
            _regionManager.RegisterViewWithRegion<RebarworksView>(RegionNames.MainContentRegion);
            _regionManager.RegisterViewWithRegion<RebarworksColumnView>(RegionNames.RebarworksContentRegion);
            _regionManager.RegisterViewWithRegion<RebarworksBeamView>(RegionNames.RebarworksContentRegion);

            // Tileworks
            _regionManager.RegisterViewWithRegion<TileworksView>(RegionNames.MainContentRegion);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MasonryView>(nameof(MasonryView));

            // Concrete Tabs
            //containerRegistry.RegisterForNavigation<ConcreteView>(nameof(ConcreteView));
            //containerRegistry.RegisterForNavigation<ConcreteColumnView>(nameof(ConcreteColumnView));
            //containerRegistry.RegisterForNavigation<ConcreteBeamView>(nameof(ConcreteBeamView));
            //containerRegistry.RegisterForNavigation<ConcreteSlabView>(nameof(ConcreteSlabView));
            //containerRegistry.RegisterForNavigation<ConcreteFootingView>(nameof(ConcreteFootingView));
            //containerRegistry.RegisterForNavigation<ConcreteOtherView>(nameof(ConcreteOtherView));

            //// Formworks Tabs
            //containerRegistry.RegisterForNavigation<FormworksView>(nameof(FormworksView));
            //containerRegistry.RegisterForNavigation<FormworksColumnView>(nameof(FormworksColumnView));
            //containerRegistry.RegisterForNavigation<FormworksBeamView>(nameof(FormworksBeamView));

            //// Tile works
            //containerRegistry.RegisterForNavigation<TileworksView>(nameof(TileworksView));

            //// Rebarworks
            //containerRegistry.RegisterForNavigation<RebarworksView>(nameof(RebarworksView));
            //containerRegistry.RegisterForNavigation<RebarworksColumnView>(nameof(RebarworksColumnView));
            //containerRegistry.RegisterForNavigation<RebarworksBeamView>(nameof(RebarworksBeamView));
        }
    }
}