using CategoriesModule;
using CategoriesModule.Dialogs;
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
        containerRegistry.RegisterForNavigation<LoadProjectDialog, LoadProjectDialogViewModel>();
    }

    protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
    {
        moduleCatalog.AddModule<QSANNCategoriesModule>();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var dbContext = Container.Resolve<AppDbContext>();

        dbContext.Database.EnsureCreated();

        if (!dbContext.Projects.Any())
        {
            var projects = new List<Project>()
            {
                new Project() { Name = "Test Project 1", DateCreated = DateTime.UtcNow },
                new Project() { Name = "Test Project 2", DateCreated = DateTime.UtcNow },
                new Project() { Name = "Test Project 3", DateCreated = DateTime.UtcNow },
                new Project() { Name = "Test Project 4", DateCreated = DateTime.UtcNow },
                new Project() { Name = "Test Project 5", DateCreated = DateTime.UtcNow },
                new Project() { Name = "Test Project 6", DateCreated = DateTime.UtcNow }
            };

            dbContext.AddRange(projects);
            dbContext.SaveChanges();
        }

        if (!dbContext.Tileworks.Any())
        {
            var tileWorks = new List<TileworksInput>()
            {
                new TileworksInput() { AreaOfWorkDesignation = "3", SelectedMultiplier = "3x3", DateCreated = DateTime.UtcNow, Project = dbContext.Projects.FirstOrDefault() },
                new TileworksInput() { AreaOfWorkDesignation = "5", SelectedMultiplier = "4x4", DateCreated = DateTime.UtcNow, Project = dbContext.Projects.Skip(1).FirstOrDefault() },
                new TileworksInput() { AreaOfWorkDesignation = "6", SelectedMultiplier = "4x8", DateCreated = DateTime.UtcNow, Project = dbContext.Projects.Skip(2).FirstOrDefault() },
                new TileworksInput() { AreaOfWorkDesignation = "7", SelectedMultiplier = "6x6", DateCreated = DateTime.UtcNow, Project = dbContext.Projects.Skip(3).FirstOrDefault() },
                new TileworksInput() { AreaOfWorkDesignation = "8", SelectedMultiplier = "6x8", DateCreated = DateTime.UtcNow, Project = dbContext.Projects.Skip(4).FirstOrDefault() },
            };

            dbContext.AddRange(tileWorks);
            dbContext.SaveChanges();
        }
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        var regionManager = Container.Resolve<IRegionManager>();

        regionManager.RegisterViewWithRegion(RegionNames.MainWindowDialogHostContentRegion, nameof(LoadProjectDialog));
    }
}