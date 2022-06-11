using QSANN.Services.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSANN.Services.Interfaces
{
    public interface IPaintworksCalculatorService
    {
        List<PaintworksMultiplierModel> GetMultipliers();
        decimal CalculatePrimerPaint(decimal area, decimal multiplier);
        decimal CalculateCoating(decimal area, decimal multiplier);
        public decimal CalculateNeutralizer(decimal primerPaint);
    }
}
