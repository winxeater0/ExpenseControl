using ExpenseControl.Application.Common.Interfaces;
using ExpenseControl.Domain.Entities;
using ExpenseControl.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ExpenseControl.Infrastructure.Repositories;

public class PersonRepository : IPersonRepository
{
    private readonly ExpenseControlDbContext _context;

    public PersonRepository(ExpenseControlDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Person person)
    {
        await _context.People.AddAsync(person);
        await _context.SaveChangesAsync();
    }

    public async Task<Person?> GetByIdAsync(Guid id)
    {
        return await _context.People
            .Include(p => p.Transactions)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Person>> ListAsync()
    {
        return await _context.People
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var person = await _context.People.FindAsync(id);

        if (person is null)
            return;

        _context.People.Remove(person);
        await _context.SaveChangesAsync();
    }
}

