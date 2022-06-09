namespace QSANN.Services.Interfaces
{
    public interface IRebarworksBeamCalculatorService
    {
        decimal CalculateColumnArea(decimal lengthOfColumn, decimal widthOfColumn);

        decimal CalculateSteel(decimal area, decimal sizeOfMainBar);

        decimal CalculateMainbarBeam(decimal numbersOfBeam, decimal bsl, decimal area);

        decimal CalculateTies(decimal lengthOfColumn, decimal widthOfColumn);

        decimal CalculateSpcaing(decimal heightOfColumn);

        decimal CalculateBalance(decimal spacing);

        decimal CalculatePieces(decimal balance);

        decimal CalculateLateralTies(decimal ties, decimal pieces);

        decimal CalculateTieWire(decimal pieces, decimal steel, decimal numbersOfColumn);

        decimal CalculateBSL(decimal lengthOfBeam);

        decimal CalculateSBL();
    }
}