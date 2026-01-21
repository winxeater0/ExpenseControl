using ExpenseControl.Domain.Enums;

namespace ExpenseControl.Application.Transactions.Create;

public record CreateTransactionRequest(
    string Description,
    decimal Amount,
    TransactionType Type,
    Guid CategoryId,
    Guid PersonId);

