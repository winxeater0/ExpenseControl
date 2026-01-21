using ExpenseControl.Domain.Enums;

namespace ExpenseControl.Application.Categories.List;

public record CategoryDto(Guid Id, string Description, CategoryPurpose Purpose);
