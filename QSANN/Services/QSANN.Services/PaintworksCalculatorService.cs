using QSANN.Services.Interfaces;
using QSANN.Services.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSANN.Services
{
    public class PaintworksCalculatorService : IPaintworksCalculatorService
    {
        public List<PaintworksMultiplierModel> GetMultipliers()
        {
            return new List<PaintworksMultiplierModel>()
            {
                new PaintworksMultiplierModel() { Finish = "Rough", Multiplier = 30m },
                new PaintworksMultiplierModel() { Finish = "Coarse", Multiplier = 35m },
                new PaintworksMultiplierModel() { Finish = "Fine", Multiplier = 40m },
            };
        }

        public decimal CalculatePrimerPaint(decimal area, decimal multiplier)
        {
            return (area * 2) / multiplier;
        }

        public decimal CalculateCoating(decimal area, decimal multiplier)
        {
            return ((area * 2) / multiplier) * 2;
        }

        public decimal CalculateNeutralizer(decimal primerPaint)
        {
            decimal divisor = 2.5m;

            return primerPaint / divisor;
        }
    }
}
