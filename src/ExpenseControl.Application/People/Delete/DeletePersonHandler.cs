using ExpenseControl.Application.Common.Interfaces;

namespace ExpenseControl.Application.People.List;

public class DeletePersonHandler
{
    private readonly IPersonRepository _personRepository;

    public DeletePersonHandler(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task Handle(Guid personId)
    {
        // Busca a pessoa via repositório
        var person = await _personRepository.GetByIdAsync(personId);

        if (person is null)
            throw new ApplicationException("Pessoa não encontrada.");

        // Remove a pessoa
        // As transações serão removidas automaticamente via cascade delete
        await _personRepository.DeleteAsync(personId);
    }
}


