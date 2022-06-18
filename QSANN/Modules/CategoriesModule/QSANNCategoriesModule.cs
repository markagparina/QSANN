using CategoriesModule.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using QSANN.Core;
using QSANN.Services;
using QSANN.Services.Interfaces;

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
            // Carpentry works
            _regionManager.RegisterViewWithRegion<CarpentryworksView>(RegionNames.MainContentRegion);

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

            // Masonry
            _regionManager.RegisterViewWithRegion<MasonryView>(RegionNames.MainContentRegion);

            // Rebarworks Tabs
            _regionManager.RegisterViewWithRegion<RebarworksView>(RegionNames.MainContentRegion);
            _regionManager.RegisterViewWithRegion<RebarworksColumnView>(RegionNames.RebarworksContentRegion);
            _regionManager.RegisterViewWithRegion<RebarworksBeamView>(RegionNames.RebarworksContentRegion);
            _regionManager.RegisterViewWithRegion<RebarworksSlabView>(RegionNames.RebarworksContentRegion);
            _regionManager.RegisterViewWithRegion<RebarworksFootingView>(RegionNames.RebarworksContentRegion);

            // Tileworks
            _regionManager.RegisterViewWithRegion<TileworksView>(RegionNames.MainContentRegion);

            // Paintworks
            _regionManager.RegisterViewWithRegion<PaintworksView>(RegionNames.MainContentRegion);

            // Others
            _regionManager.RegisterViewWithRegion<OthersView>(RegionNames.MainContentRegion);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IMasonryCalculatorService, MasonryCalculatorService>();
            containerRegistry.Register<IConcreteCalculatorService, ConcreteCalculatorService>();
            containerRegistry.Register<IFormworksColumnCalculatorService, FormworksColumnCalculatorService>();
            containerRegistry.Register<IFormworksBeamCalculatorService, FormworksBeamCalculatorService>();
            containerRegistry.Register<ITileworksCalculatorService, TileworksCalculatorService>();
            containerRegistry.Register<IRebarworksColumnCalculatorService, RebarworksColumnCalculatorService>();
            containerRegistry.Register<IRebarworksBeamCalculatorService, RebarworksBeamCalculatorService>();
            containerRegistry.Register<IRebarworksFootingCalculatorService, RebarworksFootingCalculatorService>();
            containerRegistry.Register<IRebarworksSlabCalculatorService, RebarworksSlabCalculatorService>();
            containerRegistry.Register<IPaintworksCalculatorService, PaintworksCalculatorService>();
            containerRegistry.Register<ICarpentryworksCalculatorService, CarpentryworksCalculatorService>();
        }
    }
}