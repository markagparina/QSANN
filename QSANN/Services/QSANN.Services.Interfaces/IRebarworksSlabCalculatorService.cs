using QSANN.Services.Interfaces.Models;
using System.Collections.Generic;

namespace QSANN.Services.Interfaces
{
    public interface IRebarworksSlabCalculatorService
    {
        List<RebarworksSlabTypeMultiplier> GetMultipliers();
        decimal CalculateSteelbar(decimal area, decimal multiplier);
        decimal CalculateTiewire(decimal area, decimal multiplier);

    }
}
