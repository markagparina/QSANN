using QSANN.Services.Interfaces;
using System;

namespace QSANN.Services;

public class RebarworksColumnCalculatorService : IRebarworksColumnCalculatorService
{
    public decimal CalculateBalance(decimal spacing)
    {
        return spacing / .2m;
    }

    public decimal CalculateColumnArea(decimal lengthOfColumn, decimal widthOfColumn)
    {
        return (lengthOfColumn * widthOfColumn) * 2;
    }

    public decimal CalculateLateralTies(decimal ties, decimal pieces)
    {
        return (ties * pieces) / 6m;
    }

    public decimal CalculateMainbarColumn(decimal heightOfColumn, decimal steel, decimal numbersOfColumn)
    {
        decimal allowance = 1.55m;

        return (((heightOfColumn + allowance) * steel) * numbersOfColumn) / 6;
    }

    public decimal CalculatePieces(decimal balance)
    {
        return balance + 22 + 1;
    }

    public decimal CalculateSpcaing(decimal heightOfColumn)
    {
        return heightOfColumn - 2.2m;
    }

    public decimal CalculateSteel(decimal area, decimal sizeOfMainBar)
    {
        return area / ((sizeOfMainBar * sizeOfMainBar) * .0001m);
    }

    public decimal CalculateTies(decimal lengthOfColumn, decimal widthOfColumn)
    {
        return (lengthOfColumn - .08m) + (widthOfColumn - .08m) + .15m;
    }

    public decimal CalculateTieWire(decimal pieces, decimal steel, decimal numbersOfColumn)
    {
        return ((pieces * steel) * numbersOfColumn) / 53;
    }
}