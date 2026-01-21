using ExpenseControl.Domain.Entities;

namespace ExpenseControl.Application.Common.Interfaces;

public interface IPersonRepository
{
    Task<Person?> GetByIdAsync(Guid id);
    Task AddAsync(Person person);
    Task DeleteAsync(Guid id);
    Task<IEnumerable<Person>> ListAsync();
}

