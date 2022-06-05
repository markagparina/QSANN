using CategoriesModule.Models;
using System.Collections.Generic;

namespace QSANN.Services.Interfaces
{
    public interface ITileworksCalculatorService
    {
        List<TileworksMultiplierModel> GetMultipliers();
        decimal CalculateNumberOfPieces(decimal area, decimal multiplier);
        decimal CalculateBagsOfCement(decimal area);
        decimal CalculateBagsOfAdhesive(decimal area);
        decimal CalculateNumberOfGrout(decimal area);
    }
}
