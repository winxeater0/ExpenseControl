using ExpenseControl.Domain.Enums;
using ExpenseControl.Domain.Exceptions;

namespace ExpenseControl.Domain.Entities;

public class Transaction
{
    public Guid Id { get; private set; }
    public string Description { get; private set; } = null!;
    public decimal Amount { get; private set; }
    public TransactionType Type { get; private set; }

    public Guid CategoryId { get; private set; }
    public Category Category { get; private set; } = null!;

    public Guid PersonId { get; private set; }
    public Person Person { get; private set; } = null!;

    protected Transaction() { }

    public Transaction(
        string description,
        decimal amount,
        TransactionType type,
        Category category,
        Person person)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new DomainException("Descrição da transação é obrigatória.");

        if (amount <= 0)
            throw new DomainException("Valor da transação deve ser positivo.");

        // Regra: menor de idade não pode ter receita
        if (person.Age < 18 && type == TransactionType.Income)
            throw new DomainException("Menores de idade não podem possuir receitas.");

        // Regra: categoria deve ser compatível
        if (!IsCategoryCompatible(type, category.Purpose))
            throw new DomainException("Categoria incompatível com o tipo da transação.");

        Id = Guid.NewGuid();
        Description = description;
        Amount = amount;
        Type = type;
        Category = category;
        CategoryId = category.Id;
        Person = person;
        PersonId = person.Id;
    }

    private static bool IsCategoryCompatible(TransactionType type, CategoryPurpose purpose)
    {
        return purpose == CategoryPurpose.Both ||
               (type == TransactionType.Expense && purpose == CategoryPurpose.Expense) ||
               (type == TransactionType.Income && purpose == CategoryPurpose.Income);
    }
}

