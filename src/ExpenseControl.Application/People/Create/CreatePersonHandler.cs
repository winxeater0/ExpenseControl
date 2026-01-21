using ExpenseControl.Application.Common.Interfaces;
using ExpenseControl.Domain.Entities;

namespace ExpenseControl.Application.People.Create;

public class CreatePersonHandler
{
    private readonly IPersonRepository _personRepository;

    public CreatePersonHandler(
        IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task<Guid> Handle(CreatePersonRequest request)
    {
        var person = new Person(request.Name, request.Age);

        await _personRepository.AddAsync(person);

        return person.Id;
    }
}


