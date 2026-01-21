using ExpenseControl.Application.Common.Interfaces;

namespace ExpenseControl.Application.People.List;

public class ListPeopleHandler
{
    private readonly IPersonRepository _personRepository;

    public ListPeopleHandler(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task<IEnumerable<PersonDto>> Handle()
    {
        var people = await _personRepository.ListAsync();

        return people.Select(p =>
            new PersonDto(
                p.Id,
                p.Name,
                p.Age));
    }
}


