namespace ExpenseControl.Application.Reports.CategoryTotals;

public sealed class CategoryTotalsSummaryDto
{
    public IReadOnlyList<CategoryTotalsDto> Categories { get; init; } = [];

    public decimal TotalIncome => Categories.Sum(c => c.TotalIncome);
    public decimal TotalExpense => Categories.Sum(c => c.TotalExpense);
    public decimal Balance => TotalIncome - TotalExpense;
}

