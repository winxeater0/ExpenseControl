using ExpenseControl.Domain.Entities;

namespace ExpenseControl.Application.Common.Interfaces;

public interface ITransactionRepository
{
    Task AddAsync(Transaction transaction);
    Task<IEnumerable<Transaction>> ListAsync();
}

