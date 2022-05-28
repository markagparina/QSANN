namespace QSANN.Services;

using QSANN.Services.Interfaces;

public class CementCalculatorService : ICementCalculatorService
{
    public decimal CalculateVolume(decimal length, decimal width, decimal height, decimal count)
    {
        return length * width * height * count;
    }
}
