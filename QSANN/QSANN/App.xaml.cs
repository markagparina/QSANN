using CategoriesModule;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using QSANN.Core;
using QSANN.Data;
using QSANN.Data.Entities;
using QSANN.Dialogs;
using QSANN.Services;
using QSANN.Services.Interfaces;
using QSANN.ViewModels;
using QSANN.Views;
using System;
using System.Collections.Generic;
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
        containerRegistry.RegisterForNavigation<LoadProjectDialog, LoadProjectDialogViewModel>();
    }

    protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
    {
        moduleCatalog.AddModule<QSANNCategoriesModule>();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
#if DEBUG
        var dbContext = Container.Resolve<AppDbContext>();
        dbContext.Database.EnsureCreated();
        DataSeeder.Seed(dbContext);
#endif
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        var regionManager = Container.Resolve<IRegionManager>();

        regionManager.RegisterViewWithRegion(RegionNames.MainWindowDialogHostContentRegion, nameof(LoadProjectDialog));
    }
}