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

        public decimal CalculateBeamArea(decimal lengthOfBeam, decimal widthOfBeam)
        {
            return _rebarworksColumnCalculatorService.CalculateColumnArea(lengthOfBeam, widthOfBeam);
        }

        public decimal CalculateStirrups(decimal stirrups, decimal pieces)
        {
            return _rebarworksColumnCalculatorService.CalculateLateralTies(stirrups, pieces);
        }

        public decimal CalculateMainbarBeam(decimal numbersOfBeam, decimal bsl, decimal steel)
        {
            return (numbersOfBeam * bsl * (steel + (steel * .1m))) / 6;
        }

        public decimal CalculatePieces(decimal balance)
        {
            return _rebarworksColumnCalculatorService.CalculatePieces(balance);
        }

        public decimal CalculateSBL(decimal widthOfBeam, decimal LengthOfBeam, decimal sizeOfStirrups, decimal numbersOfBeam)
        {
            return ((widthOfBeam + (LengthOfBeam / 4) + (sizeOfStirrups * .01m)) * numbersOfBeam) / 6;
        }

        public decimal CalculateSpacing(decimal lengthOfBeam)
        {
            return _rebarworksColumnCalculatorService.CalculateSpcaing(lengthOfBeam);
        }

        public decimal CalculateSteel(decimal area, decimal sizeOfMainBar)
        {
            return _rebarworksColumnCalculatorService.CalculateSteel(area, sizeOfMainBar);
        }

        public decimal CalculateStirrups1(decimal lengthOfBeam, decimal widthOfBeam)
        {
            return _rebarworksColumnCalculatorService.CalculateTies(lengthOfBeam, widthOfBeam);
        }

        public decimal CalculateTieWire(decimal pieces, decimal steel, decimal numbersOfBeam)
        {
            return _rebarworksColumnCalculatorService.CalculateTieWire(pieces, steel, numbersOfBeam);
        }
    }
}