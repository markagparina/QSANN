namespace QSANN.Services.Interfaces;

public interface ICementCalculatorService
{
    decimal CalculateVolume(decimal length, decimal width, decimal height, decimal count);
}
