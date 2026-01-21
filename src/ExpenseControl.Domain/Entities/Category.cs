using ExpenseControl.Domain.Enums;
using ExpenseControl.Domain.Exceptions;

namespace ExpenseControl.Domain.Entities;

public class Category
{
    public Guid Id { get; private set; }
    public string Description { get; private set; } = null!;
    public CategoryPurpose Purpose { get; private set; }

    protected Category() { }

    public Category(string description, CategoryPurpose purpose)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new DomainException("Descrição da categoria é obrigatória.");

        Id = Guid.NewGuid();
        Description = description;
        Purpose = purpose;
    }
}

