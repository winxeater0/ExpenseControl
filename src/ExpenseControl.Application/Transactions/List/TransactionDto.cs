using ExpenseControl.Application.Categories.List;
using ExpenseControl.Application.People.List;
using ExpenseControl.Domain.Enums;

namespace ExpenseControl.Application.Transactions.List;

public record TransactionDto(Guid Id, string Description, decimal Amount, TransactionType TransactionType,
    CategoryDto Category, PersonDto Person);
