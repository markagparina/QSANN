namespace QSANN.Services.Interfaces
{
    public interface IFormworksBeamCalculatorService
    {
        decimal CalculatePerimeter(decimal length, decimal width);

        decimal CalculateArea(decimal perimeter, decimal length, decimal numberOfCounts);

        decimal CalculateNumberOfPlywood(decimal area);

        decimal CalculateNumberOfBoardFeetLumber(decimal numberOfPlywood, string lumberSize, string thicknessOfPlywood);
    }
}