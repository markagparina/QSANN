namespace QSANN.Services.Interfaces
{
    public interface IRebarworksBeamCalculatorService
    {
        decimal CalculateBeamArea(decimal lengthOfBeam, decimal widthOfBeam);

        decimal CalculateSteel(decimal area, decimal sizeOfMainBar);

        decimal CalculateMainbarBeam(decimal numbersOfBeam, decimal bsl, decimal steel);

        decimal CalculateStirrups1(decimal lengthOfBeam, decimal widthOfBeam);

        decimal CalculateSpacing(decimal lengthOfBeam);

        decimal CalculateBalance(decimal spacing);

        decimal CalculatePieces(decimal balance);

        decimal CalculateStirrups(decimal stirrups, decimal pieces);

        decimal CalculateTieWire(decimal pieces, decimal steel, decimal numbersOfBeam);

        decimal CalculateBSL(decimal lengthOfBeam);

        decimal CalculateSBL(decimal widthOfBeam, decimal LengthOfBeam, decimal sizeOfStirrups, decimal numbersOfBeam);
    }
}