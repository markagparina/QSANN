using CategoriesModule;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using QSANN.Services;
using QSANN.Services.Interfaces;
using QSANN.Views;
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
        containerRegistry.Register<IMasonryCalculatorService, MasonryCalculatorService>();
        containerRegistry.Register<ICementCalculatorService, CementCalculatorService>();
    }

    protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
    {
        moduleCatalog.AddModule<QSANNCategoriesModule>();
    }

    protected override void ConfigureDefaultRegionBehaviors(IRegionBehaviorFactory regionBehaviors)
    {
        base.ConfigureDefaultRegionBehaviors(regionBehaviors);
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
    }


}

