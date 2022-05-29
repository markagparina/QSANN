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
            _regionManager.RequestNavigate(RegionNames.MainContentRegion, nameof(ConcreteView));


            // Concrete Tabs
            _regionManager.RegisterViewWithRegion(RegionNames.ConcreteContentRegion, nameof(ConcreteColumnView));

            // Formworks Tabs
            _regionManager.RegisterViewWithRegion(RegionNames.FormworksContentRegion, nameof(FormworksColumnView));

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MasonryView>(nameof(MasonryView));

            // Concrete Tabs
            containerRegistry.RegisterForNavigation<ConcreteView>(nameof(ConcreteView));
            containerRegistry.RegisterForNavigation<ConcreteColumnView>(nameof(ConcreteColumnView));
            containerRegistry.RegisterForNavigation<ConcreteBeamView>(nameof(ConcreteBeamView));
            containerRegistry.RegisterForNavigation<ConcreteSlabView>(nameof(ConcreteSlabView));
            containerRegistry.RegisterForNavigation<ConcreteFootingView>(nameof(ConcreteFootingView));
            containerRegistry.RegisterForNavigation<ConcreteOtherView>(nameof(ConcreteOtherView));

            // Formworks Tabs
            containerRegistry.RegisterForNavigation<FormworksView>(nameof(FormworksView));
            containerRegistry.RegisterForNavigation<FormworksColumnView>(nameof(FormworksColumnView));
            containerRegistry.RegisterForNavigation<FormworksBeamView>(nameof(FormworksBeamView));
        }
    }
}