using QSANN.Services.Interfaces;
using System;

namespace QSANN.Services
{
    public class FormworksBeamCalculatorService : FormworksColumnCalculatorService, IFormworksBeamCalculatorService
    {
        public override decimal CalculateArea(decimal perimeter, decimal length, decimal numberOfCounts)
        {
            return base.CalculateArea(perimeter, length, numberOfCounts);
        }

        public override decimal CalculatePerimeter(decimal length, decimal width)
        {
            return 2 * (length + width) + .1m;
        }

        public override decimal CalculateNumberOfBoardFeetLumber(decimal numberOfPlywood, string lumberSize, string thicknessOfPlywood)
        {
            return (lumberSize, thicknessOfPlywood) switch
            {
                ("2x2", "1/4") => numberOfPlywood * 25.06m,
                ("2x2", "1/2") => numberOfPlywood * 18.66m,
                ("2x3", "1/4") => numberOfPlywood * 37.60m,
                ("2x3", "1/2") => numberOfPlywood * 28m,
                _ => throw new ArgumentException("Invalid Lumber Size/Thickness of Plywood")
            };
        }
    }
}