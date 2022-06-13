using QSANN.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QSANN.Data
{
    public static class DataSeeder
    {
        public static void Seed(AppDbContext dbContext)
        {
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

            if (!dbContext.Set<FormworksBeamInput>().Any())
            {
                var formworksBeamInputs = new List<FormworksBeamInput>()
                {
                    new FormworksBeamInput() { LengthOfBeam = $"{Random.Shared.Next(12, 50)}", WidthOfBeam = $"{Random.Shared.Next(12, 50)}", HeightOfBeam =  $"{Random.Shared.Next(12, 50)}", NumberOfCounts = $"{Random.Shared.Next(2,20)}", LumberSize = "2x3", ThicknessOfPlywood = "1/4",  DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().FirstOrDefault() },
                    new FormworksBeamInput() { LengthOfBeam = $"{Random.Shared.Next(12, 50)}", WidthOfBeam = $"{Random.Shared.Next(12, 50)}", HeightOfBeam =  $"{Random.Shared.Next(12, 50)}", NumberOfCounts = $"{Random.Shared.Next(2,20)}", LumberSize = "2x2",  ThicknessOfPlywood = "1/2", DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().Skip(1).FirstOrDefault() },
                    new FormworksBeamInput() { LengthOfBeam = $"{Random.Shared.Next(12, 50)}", WidthOfBeam = $"{Random.Shared.Next(12, 50)}", HeightOfBeam =  $"{Random.Shared.Next(12, 50)}", NumberOfCounts = $"{Random.Shared.Next(2,20)}", LumberSize = "2x3",  ThicknessOfPlywood = "1/4", DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().Skip(2).FirstOrDefault() },
                    new FormworksBeamInput() { LengthOfBeam = $"{Random.Shared.Next(12, 50)}", WidthOfBeam = $"{Random.Shared.Next(12, 50)}", HeightOfBeam =  $"{Random.Shared.Next(12, 50)}", NumberOfCounts = $"{Random.Shared.Next(2,20)}", LumberSize = "2x2",  ThicknessOfPlywood = "1/2", DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().Skip(3).FirstOrDefault() },
                    new FormworksBeamInput() { LengthOfBeam = $"{Random.Shared.Next(12, 50)}", WidthOfBeam = $"{Random.Shared.Next(12, 50)}", HeightOfBeam =  $"{Random.Shared.Next(12, 50)}", NumberOfCounts = $"{Random.Shared.Next(2,20)}", LumberSize = "2x3", ThicknessOfPlywood = "1/4",  DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().Skip(4).FirstOrDefault() },
                };

                dbContext.AddRange(formworksBeamInputs);
                dbContext.SaveChanges();
            }

            if (!dbContext.Set<FormworksColumnInput>().Any())
            {
                var formworksColumnInputs = new List<FormworksColumnInput>()
                {
                    new FormworksColumnInput() { LengthOfColumn = $"{Random.Shared.Next(12, 50)}", WidthOfColumn = $"{Random.Shared.Next(12, 50)}", HeightOfColumn =  $"{Random.Shared.Next(12, 50)}", NumberOfCounts = $"{Random.Shared.Next(2,20)}", LumberSize = "2x3", ThicknessOfPlywood = "1/4",  DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().FirstOrDefault() },
                    new FormworksColumnInput() { LengthOfColumn = $"{Random.Shared.Next(12, 50)}", WidthOfColumn = $"{Random.Shared.Next(12, 50)}", HeightOfColumn =  $"{Random.Shared.Next(12, 50)}", NumberOfCounts = $"{Random.Shared.Next(2,20)}", LumberSize = "2x2",  ThicknessOfPlywood = "1/2", DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().Skip(1).FirstOrDefault() },
                    new FormworksColumnInput() { LengthOfColumn = $"{Random.Shared.Next(12, 50)}", WidthOfColumn = $"{Random.Shared.Next(12, 50)}", HeightOfColumn =  $"{Random.Shared.Next(12, 50)}", NumberOfCounts = $"{Random.Shared.Next(2,20)}", LumberSize = "2x3",  ThicknessOfPlywood = "1/4", DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().Skip(2).FirstOrDefault() },
                    new FormworksColumnInput() { LengthOfColumn = $"{Random.Shared.Next(12, 50)}", WidthOfColumn = $"{Random.Shared.Next(12, 50)}", HeightOfColumn =  $"{Random.Shared.Next(12, 50)}", NumberOfCounts = $"{Random.Shared.Next(2,20)}", LumberSize = "2x2",  ThicknessOfPlywood = "1/2", DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().Skip(3).FirstOrDefault() },
                    new FormworksColumnInput() { LengthOfColumn = $"{Random.Shared.Next(12, 50)}", WidthOfColumn = $"{Random.Shared.Next(12, 50)}", HeightOfColumn =  $"{Random.Shared.Next(12, 50)}", NumberOfCounts = $"{Random.Shared.Next(2,20)}", LumberSize = "2x3", ThicknessOfPlywood = "1/4",  DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().Skip(4).FirstOrDefault() },
                };

                dbContext.AddRange(formworksColumnInputs);
                dbContext.SaveChanges();
            }

            if (!dbContext.Set<MasonryInput>().Any())
            {
                var masonryInputs = new List<MasonryInput>()
                {
                    new MasonryInput() { LengthOfWall = $"{Random.Shared.Next(12, 50)}", HorizontalBarSpacing = $"{Random.Shared.NextDouble() + 0.1}", VerticalBarSpacing = $"{Random.Shared.NextDouble()}", HeightOfWall =  $"{Random.Shared.Next(12, 50)}", ClassMixtureForMortar = "A", ClassMixtureForPlaster = "C", ThicknessInMillimeter = "8",  DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().FirstOrDefault() },
                    new MasonryInput() { LengthOfWall = $"{Random.Shared.Next(12, 50)}", HorizontalBarSpacing = $"{Random.Shared.NextDouble() + 0.1}", VerticalBarSpacing = $"{Random.Shared.NextDouble()}", HeightOfWall =  $"{Random.Shared.Next(12, 50)}", ClassMixtureForMortar = "B", ClassMixtureForPlaster = "D",  ThicknessInMillimeter = "16", DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().Skip(1).FirstOrDefault() },
                    new MasonryInput() { LengthOfWall = $"{Random.Shared.Next(12, 50)}", HorizontalBarSpacing = $"{Random.Shared.NextDouble() + 0.1}", VerticalBarSpacing = $"{Random.Shared.NextDouble()}", HeightOfWall =  $"{Random.Shared.Next(12, 50)}", ClassMixtureForMortar = "C", ClassMixtureForPlaster = "B",  ThicknessInMillimeter = "12", DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().Skip(2).FirstOrDefault() },
                    new MasonryInput() { LengthOfWall = $"{Random.Shared.Next(12, 50)}", HorizontalBarSpacing = $"{Random.Shared.NextDouble() + 0.1}", VerticalBarSpacing = $"{Random.Shared.NextDouble()}", HeightOfWall =  $"{Random.Shared.Next(12, 50)}", ClassMixtureForMortar = "D", ClassMixtureForPlaster = "A",  ThicknessInMillimeter = "20", DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().Skip(3).FirstOrDefault() },
                    new MasonryInput() { LengthOfWall = $"{Random.Shared.Next(12, 50)}", HorizontalBarSpacing = $"{Random.Shared.NextDouble() + 0.1}", VerticalBarSpacing = $"{Random.Shared.NextDouble()}", HeightOfWall =  $"{Random.Shared.Next(12, 50)}", ClassMixtureForMortar = "D", ClassMixtureForPlaster = "B", ThicknessInMillimeter = "25",  DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().Skip(4).FirstOrDefault() },
                };

                dbContext.AddRange(masonryInputs);
                dbContext.SaveChanges();
            }

            if (!dbContext.Set<CarpentryworksInput>().Any())
            {
                var carpentryInputs = new List<CarpentryworksInput>()
                {
                    new CarpentryworksInput () { AreaOfDesignation = "8",  SizeOfLumber = "1x2", DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().FirstOrDefault() },
                    new CarpentryworksInput () { AreaOfDesignation = "16", SizeOfLumber = "2x3", DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().Skip(1).FirstOrDefault() },
                    new CarpentryworksInput () { AreaOfDesignation = "12", SizeOfLumber = "2x2", DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().Skip(2).FirstOrDefault() },
                    new CarpentryworksInput () { AreaOfDesignation = "20", SizeOfLumber = "2x4", DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().Skip(3).FirstOrDefault() },
                    new CarpentryworksInput () { AreaOfDesignation = "25", SizeOfLumber = "2x3", DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().Skip(4).FirstOrDefault() },
                };

                dbContext.AddRange(carpentryInputs);
                dbContext.SaveChanges();
            }

            if (!dbContext.Set<PaintworksInput>().Any())
            {
                var paintworksInputs = new List<PaintworksInput>()
                {
                    new PaintworksInput () { AreaOfApplication = "8",   Finish = "Fine", DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().FirstOrDefault() },
                    new PaintworksInput () { AreaOfApplication = "16",  Finish = "Coarse", DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().Skip(1).FirstOrDefault() },
                    new PaintworksInput () { AreaOfApplication = "12",  Finish = "Rough", DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().Skip(2).FirstOrDefault() },
                    new PaintworksInput () { AreaOfApplication = "20",  Finish = "Fine", DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().Skip(3).FirstOrDefault() },
                    new PaintworksInput () { AreaOfApplication = "",  Finish = "Coarse", DateCreated = DateTime.UtcNow, Project = dbContext.Set<Project>().Skip(4).FirstOrDefault() },
                };

                dbContext.AddRange(paintworksInputs);
                dbContext.SaveChanges();
            }
        }
    }
}