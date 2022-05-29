namespace QSANN.Services.Interfaces
{
    public interface IFormworksColumnCalculatorService
    {
        decimal CalculatePerimeter(decimal length, decimal width);
        decimal CalculateArea(decimal perimeter, decimal height, decimal numberOfCounts);
        decimal CalculateNumberOfPlywood(decimal area);
        decimal CalculateNumberOfBoardFeetLumber(decimal numberOfPlywood, string lumberSize, string thicknessOfPlywood);
    }
}
