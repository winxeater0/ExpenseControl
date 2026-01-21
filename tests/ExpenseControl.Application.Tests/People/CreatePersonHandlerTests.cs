using ExpenseControl.Application.Common.Interfaces;
using ExpenseControl.Application.People.Create;
using ExpenseControl.Domain.Entities;
using FluentAssertions;
using Moq;

namespace ExpenseControl.Application.Tests.People;

public class CreatePersonHandlerTests
{
    private readonly Mock<IPersonRepository> _repositoryMock;
    private readonly CreatePersonHandler _handler;

    public CreatePersonHandlerTests()
    {
        _repositoryMock = new Mock<IPersonRepository>();
        _handler = new CreatePersonHandler(_repositoryMock.Object);
    }

    [Fact]
    public async Task Should_Create_Person_When_Request_Is_Valid()
    {
        var request = new CreatePersonRequest
        (
            "Matheus",
            30
        );

        var id = await _handler.Handle(request);

        id.Should().NotBeEmpty();
        _repositoryMock.Verify(r => r.AddAsync(It.IsAny<Person>()), Times.Once);
    }
}
