using ExpenseControl.Domain.Entities;

namespace ExpenseControl.Application.Common.Interfaces;

public interface ICategoryRepository
{
    Task<Category?> GetByIdAsync(Guid id);
    Task AddAsync(Category category);
    Task<IEnumerable<Category>> ListAsync();
}

