namespace ExpenseControl.Application.Reports.CategoryTotals;


public sealed class CategoryTotalsDto
{
    public Guid CategoryId { get; init; }
    public string Description { get; init; } = string.Empty;

    public decimal TotalIncome { get; init; }
    public decimal TotalExpense { get; init; }

    public decimal Balance => TotalIncome - TotalExpense;
}