namespace QSANN.Services.Interfaces
{
    public interface IRebarworksFootingCalculatorService
    {
        decimal CalculateHorizontalFoootingRebar(decimal lengthOfFooting, decimal widthOfFooting, decimal spacing);
        decimal CalculateVerticalFoootingRebar(decimal widthOfFooting, decimal lengthOfFooting, decimal spacing);
        decimal CalculateTotalFootingRebar(decimal horizontalFootingRebar, decimal verticalFootingRebar);
        decimal CalculateTiewire(decimal widthOfFooting, decimal lengthOfFooting, decimal spacing, decimal numbersOfFooting);
    }
}
