using CategoriesModule.Models;
using QSANN.Services.Interfaces;
using System.Collections.Generic;

namespace QSANN.Services
{
    public class TileworksCalculatorService : ITileworksCalculatorService
    {
        public List<TileworksMultiplierModel> GetMultipliers()
        {

            return new List<TileworksMultiplierModel>()
            {
                new TileworksMultiplierModel() { Name = "3x3", Multiplier = 177.8m },
                new TileworksMultiplierModel() { Name = "4x4", Multiplier = 100m },
                new TileworksMultiplierModel() { Name = "4 1/4 x 4 1/4", Multiplier = 88.4m },
                new TileworksMultiplierModel() { Name = "4x8", Multiplier = 50m },
                new TileworksMultiplierModel() { Name = "6x6", Multiplier = 44.44m },
                new TileworksMultiplierModel() { Name = "6x8", Multiplier = 33.33m },
                new TileworksMultiplierModel() { Name = "6x12", Multiplier = 22.22m },
                new TileworksMultiplierModel() { Name = "8x8", Multiplier = 25m },
                new TileworksMultiplierModel() { Name = "8x12", Multiplier = 16.66m },
                new TileworksMultiplierModel() { Name = "8x16", Multiplier = 12.5m },
                new TileworksMultiplierModel() { Name = "10x10", Multiplier = 16m },
                new TileworksMultiplierModel() { Name = "12x12", Multiplier = 11.11m },
                new TileworksMultiplierModel() { Name = "12x4", Multiplier = 5.56m },
                new TileworksMultiplierModel() { Name = "16x16", Multiplier = 6.25m },
                new TileworksMultiplierModel() { Name = "20x20", Multiplier = 4m },
                new TileworksMultiplierModel() { Name = "24x24", Multiplier = 2.78m }

            };

        }

        public decimal CalculateNumberOfPieces(decimal area, decimal multiplier)
        {
            return area * multiplier;
        }

        public decimal CalculateBagsOfCement (decimal area)
        {
            return area * .086m;
        }

        public decimal CalculateBagsOfAdhesive(decimal area)
        {
            return area * 0.11m;
        }

        public decimal CalculateNumberOfGrout(decimal area)
        {
            return area * .5m;
        }
    }
}
