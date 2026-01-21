using FluentValidation;

namespace ExpenseControl.Application.Categories.Create;

public class CreateCategoryValidator
    : AbstractValidator<CreateCategoryRequest>
{
    public CreateCategoryValidator()
    {
        RuleFor(x => x.Description)
            .NotEmpty()
            .MaximumLength(150);

        RuleFor(x => x.Purpose)
            .IsInEnum();
    }
}

