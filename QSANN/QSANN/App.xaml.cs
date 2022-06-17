﻿using CategoriesModule;
using Monitoring;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using QSANN.Core;
using QSANN.Data;
using QSANN.Services;
using QSANN.Services.Interfaces;
using QSANN.ViewModels;
using QSANN.Views;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
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

        regionManager.Regions.Count();
    }
}