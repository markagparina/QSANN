using CategoriesModule;
using Monitoring;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using QSANN.Core;
using QSANN.Data;
using QSANN.ViewModels;
using QSANN.Views;
using System.Linq;
using System.Windows;

namespace QSANN;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App
{
    protected override Window CreateShell()
    {
        return Container.Resolve<MainWindow>();
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterScoped<AppDbContext>();
        containerRegistry.RegisterScoped<ProjectDialogViewModel>();
    }

    protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
    {
        moduleCatalog.AddModule<QSANNCategoriesModule>();
        moduleCatalog.AddModule<MonitoringModule>();
        moduleCatalog.Initialize();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var dbContext = Container.Resolve<AppDbContext>();
        dbContext.Database.EnsureCreated();
#if DEBUG
        DataSeeder.Seed(dbContext);
#endif
        var regionManager = Container.Resolve<IRegionManager>();
        regionManager.RegisterViewWithRegion<HomeView>(RegionNames.ModuleRegion);
        regionManager.RegisterViewWithRegion<QuantitySurveyingView>(RegionNames.ModuleRegion);
        regionManager.RegisterViewWithRegion<MonitoringView>(RegionNames.ModuleRegion);

        regionManager.Regions.Count();
    }
}