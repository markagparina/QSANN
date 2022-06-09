using QSANN.Services.Interfaces.Models;

namespace QSANN.Services.Interfaces
{
    public interface IMasonryCalculatorService
    {
        decimal CalculateWallArea(decimal height, decimal length);

        decimal CalculateCHB(decimal area);

        decimal CalculateClassMixtureForMortarMultiplier(string classMixture);

        ThicknessSandModel CalculateThicknessAndSandMultipliers(decimal thickness, string classMixture);
    }
}