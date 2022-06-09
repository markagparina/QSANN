namespace QSANN.Services;

using QSANN.Services.Interfaces;

public class ConcreteCalculatorService : IConcreteCalculatorService
{
    public decimal CalculateVolume(decimal length, decimal width, decimal heightOrThickness, decimal count)
    {
        return length * width * heightOrThickness * count;
    }
}