using ExpenseControl.Application.Common.Interfaces;
using ExpenseControl.Application.People.List;
using ExpenseControl.Domain.Entities;
using FluentAssertions;
using Moq;

namespace ExpenseControl.Application.Tests.People;

public class DeletePersonHandlerTests
{
    private readonly Mock<IPersonRepository> _personRepo;
    private readonly DeletePersonHandler _handler;

    public DeletePersonHandlerTests()
    {
        _personRepo = new Mock<IPersonRepository>();
        _handler = new DeletePersonHandler(_personRepo.Object);
    }

    [Fact]
    public async Task Should_Delete_Person_When_Person_Exists()
    {
        // Arrange
        var personId = Guid.NewGuid();
        var person = new Person("Matheus", 30);

        // Garante que o Id da entidade seja o mesmo
        typeof(Person)
            .GetProperty("Id")!
            .SetValue(person, personId);

        _personRepo
            .Setup(r => r.GetByIdAsync(personId))
            .ReturnsAsync(person);

        // Act
        await _handler.Handle(personId);

        // Assert
        _personRepo.Verify(
            r => r.DeleteAsync(personId),
            Times.Once);
    }

    [Fact]
    public async Task Should_Throw_When_Person_Does_Not_Exist()
    {
        // Arrange
        var personId = Guid.NewGuid();

        _personRepo
            .Setup(r => r.GetByIdAsync(personId))
            .ReturnsAsync((Person?)null);

        // Act + Assert
        await FluentActions
            .Invoking(() => _handler.Handle(personId))
            .Should()
            .ThrowAsync<ApplicationException>()
            .WithMessage("Pessoa não encontrada.");
    }
}



