using ExpenseControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpenseControl.Infrastructure.Persistence;

public class ExpenseControlDbContext : DbContext
{
    public ExpenseControlDbContext(DbContextOptions<ExpenseControlDbContext> options)
        : base(options)
    {
    }

    public DbSet<Person> People => Set<Person>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Transaction> Transactions => Set<Transaction>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Aplica automaticamente todos os mappings deste assembly
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ExpenseControlDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}

