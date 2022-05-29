using QSANN.Services.Interfaces;
using System;

namespace QSANN.Services
{
    public class FormworksColumnCalculatorService : IFormworksColumnCalculatorService
    {
        public virtual decimal CalculateArea(decimal perimeter, decimal height, decimal numberOfCounts)
        {
            return perimeter * height * numberOfCounts;
        }

        public virtual decimal CalculateNumberOfPlywood(decimal area)
        {
            return area / 2.88m;
        }

        public virtual decimal CalculatePerimeter(decimal length, decimal width)
        {
            return 2m * (length + width) + .20m;
        }

        public virtual decimal CalculateNumberOfBoardFeetLumber(decimal numberOfPlywood, string lumberSize, string thicknessOfPlywood)
        {
            return (lumberSize, thicknessOfPlywood) switch
            {
                ("2x2", "1/4") => numberOfPlywood * 29.67m,
                ("2x2", "1/2") => numberOfPlywood * 20.33m,
                ("2x3", "1/4") => numberOfPlywood * 44.50m,
                ("2x3", "1/2") => numberOfPlywood * 30.50m,
                _ => throw new ArgumentException("Invalid Lumber Size/Thickness of Plywood")
            };

            
        }
    }
}
