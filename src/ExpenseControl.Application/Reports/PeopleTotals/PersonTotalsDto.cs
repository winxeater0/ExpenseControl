namespace ExpenseControl.Application.Reports.PeopleTotals;

public sealed class PersonTotalsDto
{
    public Guid PersonId { get; init; }
    public string Name { get; init; } = string.Empty;

    public decimal TotalIncome { get; init; }
    public decimal TotalExpense { get; init; }

    public decimal Balance => TotalIncome - TotalExpense;
}
