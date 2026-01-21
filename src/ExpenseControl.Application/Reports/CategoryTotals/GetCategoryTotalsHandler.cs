using ExpenseControl.Application.Common.Interfaces;
using ExpenseControl.Domain.Enums;

namespace ExpenseControl.Application.Reports.CategoryTotals;

public sealed class GetCategoryTotalsHandler
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly ITransactionRepository _transactionRepository;

    public GetCategoryTotalsHandler(
        ICategoryRepository categoryRepository,
        ITransactionRepository transactionRepository)
    {
        _categoryRepository = categoryRepository;
        _transactionRepository = transactionRepository;
    }

    public async Task<CategoryTotalsSummaryDto> Handle()
    {
        var categories = await _categoryRepository.ListAsync();
        var transactions = await _transactionRepository.ListAsync();

        var result = categories.Select(category =>
        {
            var categoryTransactions = transactions
                .Where(t => t.CategoryId == category.Id);

            var income = categoryTransactions
                .Where(t => t.Type == TransactionType.Income)
                .Sum(t => t.Amount);

            var expense = categoryTransactions
                .Where(t => t.Type == TransactionType.Expense)
                .Sum(t => t.Amount);

            return new CategoryTotalsDto
            {
                CategoryId = category.Id,
                Description = category.Description,
                TotalIncome = income,
                TotalExpense = expense
            };
        }).ToList();

        return new CategoryTotalsSummaryDto
        {
            Categories = result
        };
    }
}

