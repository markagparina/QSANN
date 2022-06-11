using QSANN.Services.Interfaces;
using QSANN.Services.Interfaces.Models;
using System.Collections.Generic;

namespace QSANN.Services
{
    public class CarpentryworksCalculatorService : ICarpentryworksCalculatorService
    {
        public decimal CalculatePlyboard(decimal area)
        {
            decimal divisor = 2.88m;

            return area / divisor;
        }

        public decimal CalculateCommonWireNail(decimal area)
        {
            decimal multiplier = 0.033m;


            return area * multiplier;
        }

        public decimal CalculateSizeOfLumber(decimal area, decimal multiplier)
        {
            return area * multiplier;
        }

        public List<CarpentryworksMultiplierModel> GetMultipliers()
        {
            return new List<CarpentryworksMultiplierModel>()
            {
                new CarpentryworksMultiplierModel { SizeOfLumber = "1x2", Multiplier = 3.189m },
                new CarpentryworksMultiplierModel { SizeOfLumber = "2x2", Multiplier = 6.379m },
                new CarpentryworksMultiplierModel { SizeOfLumber = "2x3", Multiplier = 9.569m },
                new CarpentryworksMultiplierModel { SizeOfLumber = "2x4", Multiplier = 12.758m },
            };
        }
    }
}
