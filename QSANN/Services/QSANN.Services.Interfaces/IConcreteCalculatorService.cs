namespace QSANN.Services.Interfaces;

public interface IConcreteCalculatorService
{
    decimal CalculateVolume(decimal length, decimal width, decimal heightOrThickness, decimal count);
}
