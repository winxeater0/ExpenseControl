using FluentValidation;

namespace ExpenseControl.Application.People.Create;

public class CreatePersonValidator : AbstractValidator<CreatePersonRequest>
{
    public CreatePersonValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(150);

        RuleFor(x => x.Age)
            .GreaterThan(0);
    }
}

