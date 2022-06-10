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

        if (!dbContext.Set<Project>().Any())
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

        if (!dbContext.Set<TileworksInput>().Any())
        {
            var tileWorks = new List<TileworksInput>()
            {
                new TileworksInput() { AreaOfWorkDesignation = "3", SelectedMultiplier = "3x3", DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().FirstOrDefault() },
                new TileworksInput() { AreaOfWorkDesignation = "5", SelectedMultiplier = "4x4", DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().Skip(1).FirstOrDefault() },
                new TileworksInput() { AreaOfWorkDesignation = "6", SelectedMultiplier = "4x8", DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().Skip(2).FirstOrDefault() },
                new TileworksInput() { AreaOfWorkDesignation = "7", SelectedMultiplier = "6x6", DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().Skip(3).FirstOrDefault() },
                new TileworksInput() { AreaOfWorkDesignation = "8", SelectedMultiplier = "6x8", DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().Skip(4).FirstOrDefault() },
            };

            dbContext.AddRange(tileWorks);
            dbContext.SaveChanges();
        }

        if (!dbContext.Set<ConcreteColumnInput>().Any())
        {
            var concreteColumnInputs = new List<ConcreteColumnInput>()
            {
                new ConcreteColumnInput() { LengthOfColumn = $"{Random.Shared.Next(12, 50)}", WidthOfColumn = $"{Random.Shared.Next(12, 50)}", HeightOfColumn =  $"{Random.Shared.Next(12, 50)}", NumbersOfCount = $"{Random.Shared.Next(2,20)}", ClassMixture = "B",  DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().FirstOrDefault() },
                new ConcreteColumnInput() { LengthOfColumn = $"{Random.Shared.Next(12, 50)}", WidthOfColumn = $"{Random.Shared.Next(12, 50)}", HeightOfColumn =  $"{Random.Shared.Next(12, 50)}", NumbersOfCount = $"{Random.Shared.Next(2,20)}", ClassMixture = "C",  DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().Skip(1).FirstOrDefault() },
                new ConcreteColumnInput() { LengthOfColumn = $"{Random.Shared.Next(12, 50)}", WidthOfColumn = $"{Random.Shared.Next(12, 50)}", HeightOfColumn =  $"{Random.Shared.Next(12, 50)}", NumbersOfCount = $"{Random.Shared.Next(2,20)}", ClassMixture = "AA",  DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().Skip(2).FirstOrDefault() },
                new ConcreteColumnInput() { LengthOfColumn = $"{Random.Shared.Next(12, 50)}", WidthOfColumn = $"{Random.Shared.Next(12, 50)}", HeightOfColumn =  $"{Random.Shared.Next(12, 50)}", NumbersOfCount = $"{Random.Shared.Next(2,20)}", ClassMixture = "A",  DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().Skip(3).FirstOrDefault() },
                new ConcreteColumnInput() { LengthOfColumn = $"{Random.Shared.Next(12, 50)}", WidthOfColumn = $"{Random.Shared.Next(12, 50)}", HeightOfColumn =  $"{Random.Shared.Next(12, 50)}", NumbersOfCount = $"{Random.Shared.Next(2,20)}", ClassMixture = "AA",  DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().Skip(4).FirstOrDefault() },
            };

            dbContext.AddRange(concreteColumnInputs);
            dbContext.SaveChanges();
        }

        if (!dbContext.Set<ConcreteBeamInput>().Any())
        {
            var concreteBeamInputs = new List<ConcreteBeamInput>()
            {
                new ConcreteBeamInput() { LengthOfBeam = $"{Random.Shared.Next(12, 50)}", WidthOfBeam = $"{Random.Shared.Next(12, 50)}", HeightOfBeam =  $"{Random.Shared.Next(12, 50)}", NumbersOfCount = $"{Random.Shared.Next(2,20)}", ClassMixture = "AA",  DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().FirstOrDefault() },
                new ConcreteBeamInput() { LengthOfBeam = $"{Random.Shared.Next(12, 50)}", WidthOfBeam = $"{Random.Shared.Next(12, 50)}", HeightOfBeam =  $"{Random.Shared.Next(12, 50)}", NumbersOfCount = $"{Random.Shared.Next(2,20)}", ClassMixture = "A",  DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().Skip(1).FirstOrDefault() },
                new ConcreteBeamInput() { LengthOfBeam = $"{Random.Shared.Next(12, 50)}", WidthOfBeam = $"{Random.Shared.Next(12, 50)}", HeightOfBeam =  $"{Random.Shared.Next(12, 50)}", NumbersOfCount = $"{Random.Shared.Next(2,20)}", ClassMixture = "B",  DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().Skip(2).FirstOrDefault() },
                new ConcreteBeamInput() { LengthOfBeam = $"{Random.Shared.Next(12, 50)}", WidthOfBeam = $"{Random.Shared.Next(12, 50)}", HeightOfBeam =  $"{Random.Shared.Next(12, 50)}", NumbersOfCount = $"{Random.Shared.Next(2,20)}", ClassMixture = "C",  DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().Skip(3).FirstOrDefault() },
                new ConcreteBeamInput() { LengthOfBeam = $"{Random.Shared.Next(12, 50)}", WidthOfBeam = $"{Random.Shared.Next(12, 50)}", HeightOfBeam =  $"{Random.Shared.Next(12, 50)}", NumbersOfCount = $"{Random.Shared.Next(2,20)}", ClassMixture = "AA",  DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().Skip(4).FirstOrDefault() },
            };

            dbContext.AddRange(concreteBeamInputs);
            dbContext.SaveChanges();
        }

        if (!dbContext.Set<ConcreteFootingInput>().Any())
        {
            var concreteFootingInput = new List<ConcreteFootingInput>()
            {
                new ConcreteFootingInput() { LengthOfFooting = $"{Random.Shared.Next(12, 50)}", WidthOfFooting = $"{Random.Shared.Next(12, 50)}", ThicknessOfFooting =  $"{Random.Shared.Next(12, 50)}", NumbersOfCount = $"{Random.Shared.Next(2,20)}", ClassMixture = "C",  DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().FirstOrDefault() },
                new ConcreteFootingInput() { LengthOfFooting = $"{Random.Shared.Next(12, 50)}", WidthOfFooting = $"{Random.Shared.Next(12, 50)}", ThicknessOfFooting =  $"{Random.Shared.Next(12, 50)}", NumbersOfCount = $"{Random.Shared.Next(2,20)}", ClassMixture = "B",  DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().Skip(1).FirstOrDefault() },
                new ConcreteFootingInput() { LengthOfFooting = $"{Random.Shared.Next(12, 50)}", WidthOfFooting = $"{Random.Shared.Next(12, 50)}", ThicknessOfFooting =  $"{Random.Shared.Next(12, 50)}", NumbersOfCount = $"{Random.Shared.Next(2,20)}", ClassMixture = "AA",  DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().Skip(2).FirstOrDefault() },
                new ConcreteFootingInput() { LengthOfFooting = $"{Random.Shared.Next(12, 50)}", WidthOfFooting = $"{Random.Shared.Next(12, 50)}", ThicknessOfFooting =  $"{Random.Shared.Next(12, 50)}", NumbersOfCount = $"{Random.Shared.Next(2,20)}", ClassMixture = "C",  DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().Skip(3).FirstOrDefault() },
                new ConcreteFootingInput() { LengthOfFooting = $"{Random.Shared.Next(12, 50)}", WidthOfFooting = $"{Random.Shared.Next(12, 50)}", ThicknessOfFooting =  $"{Random.Shared.Next(12, 50)}", NumbersOfCount = $"{Random.Shared.Next(2,20)}", ClassMixture = "A",  DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().Skip(4).FirstOrDefault() },
            };

            dbContext.AddRange(concreteFootingInput);
            dbContext.SaveChanges();
        }

        if (!dbContext.Set<ConcreteSlabInput>().Any())
        {
            var concreteSlabInput = new List<ConcreteSlabInput>()
            {
                new ConcreteSlabInput() { LengthOfSlab = $"{Random.Shared.Next(12, 50)}", WidthOfSlab = $"{Random.Shared.Next(12, 50)}", ThicknessOfSlab =  $"{Random.Shared.Next(12, 50)}", NumbersOfCount = $"{Random.Shared.Next(2,20)}", ClassMixture = "A",  DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().FirstOrDefault() },
                new ConcreteSlabInput() { LengthOfSlab = $"{Random.Shared.Next(12, 50)}", WidthOfSlab = $"{Random.Shared.Next(12, 50)}", ThicknessOfSlab =  $"{Random.Shared.Next(12, 50)}", NumbersOfCount = $"{Random.Shared.Next(2,20)}", ClassMixture = "A",  DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().Skip(1).FirstOrDefault() },
                new ConcreteSlabInput() { LengthOfSlab = $"{Random.Shared.Next(12, 50)}", WidthOfSlab = $"{Random.Shared.Next(12, 50)}", ThicknessOfSlab =  $"{Random.Shared.Next(12, 50)}", NumbersOfCount = $"{Random.Shared.Next(2,20)}", ClassMixture = "C",  DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().Skip(2).FirstOrDefault() },
                new ConcreteSlabInput() { LengthOfSlab = $"{Random.Shared.Next(12, 50)}", WidthOfSlab = $"{Random.Shared.Next(12, 50)}", ThicknessOfSlab =  $"{Random.Shared.Next(12, 50)}", NumbersOfCount = $"{Random.Shared.Next(2,20)}", ClassMixture = "B",  DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().Skip(3).FirstOrDefault() },
                new ConcreteSlabInput() { LengthOfSlab = $"{Random.Shared.Next(12, 50)}", WidthOfSlab = $"{Random.Shared.Next(12, 50)}", ThicknessOfSlab =  $"{Random.Shared.Next(12, 50)}", NumbersOfCount = $"{Random.Shared.Next(2,20)}", ClassMixture = "AA",  DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().Skip(4).FirstOrDefault() },
            };

            dbContext.AddRange(concreteSlabInput);
            dbContext.SaveChanges();
        }

        if (!dbContext.Set<ConcreteOtherInput>().Any())
        {
            var concreteOtherInput = new List<ConcreteOtherInput>()
            {
                new ConcreteOtherInput() { TotalVolume = $"{Random.Shared.Next(12, 50)}", NumbersOfCount = $"{Random.Shared.Next(2,20)}", ClassMixture = "AA",  DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().FirstOrDefault() },
                new ConcreteOtherInput() { TotalVolume = $"{Random.Shared.Next(12, 50)}", NumbersOfCount = $"{Random.Shared.Next(2,20)}", ClassMixture = "A",  DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().Skip(1).FirstOrDefault() },
                new ConcreteOtherInput() { TotalVolume = $"{Random.Shared.Next(12, 50)}", NumbersOfCount = $"{Random.Shared.Next(2,20)}", ClassMixture = "B",  DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().Skip(2).FirstOrDefault() },
                new ConcreteOtherInput() { TotalVolume = $"{Random.Shared.Next(12, 50)}", NumbersOfCount = $"{Random.Shared.Next(2,20)}", ClassMixture = "C",  DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().Skip(3).FirstOrDefault() },
                new ConcreteOtherInput() { TotalVolume = $"{Random.Shared.Next(12, 50)}", NumbersOfCount = $"{Random.Shared.Next(2,20)}", ClassMixture = "AA",  DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().Skip(4).FirstOrDefault() },
            };

            dbContext.AddRange(concreteOtherInput);
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