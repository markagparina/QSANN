namespace QSANN.Services.Interfaces;

public interface IRebarworksColumnCalculatorService
{
    decimal CalculateColumnArea(decimal lengthOfColumn, decimal widthOfColumn);

    decimal CalculateSteel(decimal area, decimal sizeOfMainBar);

    decimal CalculateMainbarColumn(decimal heightOfColumn, decimal steel, decimal numbersOfColumn);

    decimal CalculateTies(decimal lengthOfColumn, decimal widthOfColumn);

    decimal CalculateSpcaing(decimal heightOfColumn);

    decimal CalculateBalance(decimal spacing);

    decimal CalculatePieces(decimal balance);

    decimal CalculateLateralTies(decimal ties, decimal pieces);

    decimal CalculateTieWire(decimal pieces, decimal steel, decimal numbersOfColumn);
}