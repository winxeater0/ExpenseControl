using ExpenseControl.Application.Common.Interfaces;
using ExpenseControl.Application.Reports.PeopleTotals;
using ExpenseControl.Domain.Entities;
using ExpenseControl.Domain.Enums;
using FluentAssertions;
using Moq;

namespace ExpenseControl.Application.Tests.Reports;

public class GetPeopleTotalsHandlerTests
{
    [Fact]
    public async Task Should_Calculate_Totals_Correctly()
    {
        var person = new Person("Matheus", 30);
        var category = new Category("descrip", CategoryPurpose.Expense);
        var category2 = new Category("descrip", CategoryPurpose.Income);

        var peopleRepo = new Mock<IPersonRepository>();
        var transactionRepo = new Mock<ITransactionRepository>();
        var categoryRepo = new Mock<ICategoryRepository>();

        peopleRepo.Setup(r => r.ListAsync())
            .ReturnsAsync(new[] { person });

        categoryRepo.Setup(r => r.ListAsync())
            .ReturnsAsync(new[] { category, category2 });

        transactionRepo.Setup(r => r.ListAsync())
            .ReturnsAsync(new[]
            {
                new Transaction("Salário", 1000, TransactionType.Income, category2, person),
                new Transaction("Aluguel", 500, TransactionType.Expense, category, person)
            });

        var handler = new GetPeopleTotalsHandler(
            peopleRepo.Object,
            transactionRepo.Object);

        var result = await handler.Handle();

        result.People.Single().Balance.Should().Be(500);
        result.TotalIncome.Should().Be(1000);
        result.TotalExpense.Should().Be(500);
    }
}

