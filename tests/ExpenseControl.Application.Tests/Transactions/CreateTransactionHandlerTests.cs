using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseControl.Application.Common.Interfaces;
using ExpenseControl.Application.Transactions.Create;
using ExpenseControl.Domain.Entities;
using ExpenseControl.Domain.Enums;
using ExpenseControl.Domain.Exceptions;
using FluentAssertions;
using Moq;

namespace ExpenseControl.Application.Tests.Transactions;

public class CreateTransactionHandlerTests
{
    private readonly Mock<ITransactionRepository> _transactionRepo;
    private readonly Mock<IPersonRepository> _personRepo;
    private readonly Mock<ICategoryRepository> _categoryRepo;

    private readonly CreateTransactionHandler _handler;

    public CreateTransactionHandlerTests()
    {
        _transactionRepo = new Mock<ITransactionRepository>();
        _personRepo = new Mock<IPersonRepository>();
        _categoryRepo = new Mock<ICategoryRepository>();

        _handler = new CreateTransactionHandler(
            _personRepo.Object,
            _categoryRepo.Object,
            _transactionRepo.Object
            );
    }

    [Fact]
    public async Task Should_Not_Allow_Income_For_Minor()
    {
        var request = new CreateTransactionRequest
        (
            "Salário",
            100,
            TransactionType.Income,
            Guid.NewGuid(),
            Guid.NewGuid()
        );

        _personRepo.Setup(r => r.GetByIdAsync(request.PersonId))
            .ReturnsAsync(new Person("João", 15));

        _categoryRepo.Setup(r => r.GetByIdAsync(request.CategoryId))
            .ReturnsAsync(new Category("Salário", CategoryPurpose.Income));

        await FluentActions
            .Invoking(() => _handler.Handle(request))
            .Should()
            .ThrowAsync<DomainException>();
    }
}

