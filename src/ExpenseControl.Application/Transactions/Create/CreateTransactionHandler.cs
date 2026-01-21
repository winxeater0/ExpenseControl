using ExpenseControl.Application.Common.Interfaces;
using ExpenseControl.Domain.Entities;

namespace ExpenseControl.Application.Transactions.Create;

public class CreateTransactionHandler
{
    private readonly IPersonRepository _personRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly ITransactionRepository _transactionRepository;

    public CreateTransactionHandler(
        IPersonRepository personRepository,
        ICategoryRepository categoryRepository,
        ITransactionRepository transactionRepository)
    {
        _personRepository = personRepository;
        _categoryRepository = categoryRepository;
        _transactionRepository = transactionRepository;
    }

    public async Task<Guid> Handle(CreateTransactionRequest request)
    {
        var person = await _personRepository.GetByIdAsync(request.PersonId)
            ?? throw new ApplicationException("Pessoa não encontrada.");

        var category = await _categoryRepository.GetByIdAsync(request.CategoryId)
            ?? throw new ApplicationException("Categoria não encontrada.");

        var transaction = new Transaction(
            request.Description,
            request.Amount,
            request.Type,
            category,
            person);

        await _transactionRepository.AddAsync(transaction);

        return transaction.Id;
    }
}


