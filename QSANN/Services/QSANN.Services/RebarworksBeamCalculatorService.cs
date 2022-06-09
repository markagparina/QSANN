using QSANN.Services.Interfaces;

namespace QSANN.Services
{
    public class RebarworksBeamCalculatorService : IRebarworksBeamCalculatorService
    {
        private readonly IRebarworksColumnCalculatorService _rebarworksColumnCalculatorService;

        public RebarworksBeamCalculatorService(IRebarworksColumnCalculatorService rebarworksColumnCalculatorService)
        {
            _rebarworksColumnCalculatorService = rebarworksColumnCalculatorService;
        }

        public decimal CalculateBalance(decimal spacing)
        {
            return spacing * 1.2m;
        }

        public decimal CalculateBSL(decimal lengthOfBeam)
        {
            decimal allowance = 1.55m;

            return lengthOfBeam + allowance;
        }

        public decimal CalculateColumnArea(decimal lengthOfColumn, decimal widthOfColumn)
        {
            throw new System.NotImplementedException();
        }

        public decimal CalculateLateralTies(decimal ties, decimal pieces)
        {
            throw new System.NotImplementedException();
        }

        public decimal CalculateMainbarBeam(decimal numbersOfBeam, decimal bsl, decimal area)
        {
            return numbersOfBeam * bsl * (area + (area * .1m));
        }

        public decimal CalculatePieces(decimal balance)
        {
            throw new System.NotImplementedException();
        }

        public decimal CalculateSBL()
        {
            throw new System.NotImplementedException();
        }

        public decimal CalculateSpcaing(decimal heightOfColumn)
        {
            throw new System.NotImplementedException();
        }

        public decimal CalculateSteel(decimal area, decimal sizeOfMainBar)
        {
            return _rebarworksColumnCalculatorService.CalculateSteel(area, sizeOfMainBar);
        }

        public decimal CalculateTies(decimal lengthOfColumn, decimal widthOfColumn)
        {
            throw new System.NotImplementedException();
        }

        public decimal CalculateTieWire(decimal pieces, decimal steel, decimal numbersOfColumn)
        {
            throw new System.NotImplementedException();
        }
    }
}