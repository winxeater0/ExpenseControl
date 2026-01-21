using ExpenseControl.Application.Common.Interfaces;
using ExpenseControl.Domain.Entities;
using ExpenseControl.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ExpenseControl.Infrastructure.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly ExpenseControlDbContext _context;

    public TransactionRepository(ExpenseControlDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Transaction transaction)
    {
        await _context.Transactions.AddAsync(transaction);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Transaction>> ListAsync()
    {
        return await _context.Transactions
            .AsNoTracking()
            .Include(t => t.Person)
            .Include(t => t.Category)
            .ToListAsync();
    }
}

