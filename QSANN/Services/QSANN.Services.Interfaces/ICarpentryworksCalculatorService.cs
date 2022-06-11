using QSANN.Services.Interfaces.Models;
using System.Collections.Generic;

namespace QSANN.Services.Interfaces
{
    public interface ICarpentryworksCalculatorService
    {
        decimal CalculatePlyboard(decimal area);

        decimal CalculateCommonWireNail(decimal area);

        decimal CalculateSizeOfLumber(decimal area, decimal multiplier);

        List<CarpentryworksMultiplierModel> GetMultipliers();
    }
}
