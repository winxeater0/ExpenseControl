using ExpenseControl.Application.Common.Interfaces;
using ExpenseControl.Application.People.List;

namespace ExpenseControl.Application.Transactions.List;

public class ListTransactionHandler
{
    private readonly ITransactionRepository _transactionRepository;

    public ListTransactionHandler(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task<IEnumerable<TransactionDto>> Handle()
    {
        var transactions = await _transactionRepository.ListAsync();

        return transactions.Select(p =>
            new TransactionDto(
                p.Id,
                p.Description,
                p.Amount,
                p.Type,
                new Categories.List.CategoryDto(p.CategoryId,
                    p.Category.Description,
                    p.Category.Purpose),
                new PersonDto(p.PersonId,
                    p.Person.Name,
                    p.Person.Age)
                ));
    }
}