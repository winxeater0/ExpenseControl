using ExpenseControl.Application.Common.Interfaces;
using ExpenseControl.Domain.Enums;

namespace ExpenseControl.Application.Reports.PeopleTotals;

public sealed class GetPeopleTotalsHandler
{
    private readonly IPersonRepository _personRepository;
    private readonly ITransactionRepository _transactionRepository;

    public GetPeopleTotalsHandler(
        IPersonRepository personRepository,
        ITransactionRepository transactionRepository)
    {
        _personRepository = personRepository;
        _transactionRepository = transactionRepository;
    }

    public async Task<PeopleTotalsSummaryDto> Handle()
    {
        var people = await _personRepository.ListAsync();
        var transactions = await _transactionRepository.ListAsync();

        var result = people.Select(person =>
        {
            var personTransactions = transactions
                .Where(t => t.PersonId == person.Id);

            var income = personTransactions
                .Where(t => t.Type == TransactionType.Income)
                .Sum(t => t.Amount);

            var expense = personTransactions
                .Where(t => t.Type == TransactionType.Expense)
                .Sum(t => t.Amount);

            return new PersonTotalsDto
            {
                PersonId = person.Id,
                Name = person.Name,
                TotalIncome = income,
                TotalExpense = expense
            };
        }).ToList();

        return new PeopleTotalsSummaryDto
        {
            People = result
        };
    }
}

