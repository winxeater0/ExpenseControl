using ExpenseControl.Domain.Exceptions;

namespace ExpenseControl.Domain.Entities;

public class Person
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = null!;
    public int Age { get; private set; }

    // Navegação
    public IReadOnlyCollection<Transaction> Transactions => _transactions;
    private readonly List<Transaction> _transactions = new();

    protected Person() { } // EF Core

    public Person(string name, int age)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Nome da pessoa é obrigatório.");

        if (age <= 0)
            throw new DomainException("Idade deve ser maior que zero.");

        Id = Guid.NewGuid();
        Name = name;
        Age = age;
    }
}

