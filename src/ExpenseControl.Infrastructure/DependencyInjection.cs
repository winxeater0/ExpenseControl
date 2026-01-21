using ExpenseControl.Application.Categories.Create;
using ExpenseControl.Application.Categories.List;
using ExpenseControl.Application.Common.Interfaces;
using ExpenseControl.Application.People.Create;
using ExpenseControl.Application.People.List;
using ExpenseControl.Application.Reports.CategoryTotals;
using ExpenseControl.Application.Reports.PeopleTotals;
using ExpenseControl.Application.Transactions.Create;
using ExpenseControl.Application.Transactions.List;
using ExpenseControl.Infrastructure.Persistence;
using ExpenseControl.Infrastructure.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseControl.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ExpenseControlDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IPersonRepository, PersonRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ITransactionRepository, TransactionRepository>();

        return services;
    }

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

        services.AddScoped<CreatePersonHandler>();
        services.AddScoped<ListPeopleHandler>();
        services.AddScoped<DeletePersonHandler>();

        services.AddScoped<CreateCategoryHandler>();
        services.AddScoped<ListCategoryHandler>();

        services.AddScoped<CreateTransactionHandler>();
        services.AddScoped<ListTransactionHandler>();

        services.AddScoped<GetCategoryTotalsHandler>();

        services.AddScoped<GetPeopleTotalsHandler>();

        return services;
    }
}

