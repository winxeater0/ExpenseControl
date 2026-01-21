namespace ExpenseControl.Application.Reports.PeopleTotals;

public sealed class PeopleTotalsSummaryDto
{
    public IReadOnlyList<PersonTotalsDto> People { get; init; } = [];

    public decimal TotalIncome => People.Sum(p => p.TotalIncome);
    public decimal TotalExpense => People.Sum(p => p.TotalExpense);
    public decimal Balance => TotalIncome - TotalExpense;
}

