using QSANN.Services.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
