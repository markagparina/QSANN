using QSANN.Services.Interfaces;

namespace QSANN.Services
{
    public class RebarworksFootingCalculatorService : IRebarworksFootingCalculatorService
    {
        public decimal CalculateHorizontalFoootingRebar(decimal lengthOfFooting, decimal widthOfFooting, decimal spacing)
        {
            return (((lengthOfFooting - .15m) / spacing)) * (widthOfFooting - .15m + .32m);
        }

        public decimal CalculateTotalFootingRebar(decimal horizontalFootingRebar, decimal verticalFootingRebar)
        {
            return horizontalFootingRebar + verticalFootingRebar;
        }

        public decimal CalculateVerticalFoootingRebar(decimal widthOfFooting, decimal lengthOfFooting, decimal spacing)
        {
            return (((widthOfFooting - .15m) / spacing)) * (lengthOfFooting - .15m + .32m);
        }

        public decimal CalculateTiewire(decimal widthOfFooting, decimal lengthOfFooting, decimal spacing, decimal numbersOfFooting)
        {
            return ((((lengthOfFooting - .15m) / spacing) * (widthOfFooting - .15m) / spacing) * numbersOfFooting) / 53;
        }
    }
}
