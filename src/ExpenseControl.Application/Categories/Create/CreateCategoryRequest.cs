using ExpenseControl.Domain.Enums;

namespace ExpenseControl.Application.Categories.Create;

public record CreateCategoryRequest(string Description, CategoryPurpose Purpose);

