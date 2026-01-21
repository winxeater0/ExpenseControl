using ExpenseControl.Application.Common.Interfaces;
using ExpenseControl.Domain.Entities;
using ExpenseControl.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ExpenseControl.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ExpenseControlDbContext _context;

    public CategoryRepository(ExpenseControlDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
    }

    public async Task<Category?> GetByIdAsync(Guid id)
    {
        return await _context.Categories.FindAsync(id);
    }

    public async Task<IEnumerable<Category>> ListAsync()
    {
        return await _context.Categories
            .AsNoTracking()
            .ToListAsync();
    }
}


