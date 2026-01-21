using ExpenseControl.Api.Middlewares;
using ExpenseControl.Infrastructure;

namespace ExpenseControl.Api;

internal class Program
{
    protected Program()
    {
    }

    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Controllers (se usar)
        builder.Services.AddControllers();

        // Swagger - SEMPRE antes do Build
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Camadas
        builder.Services.AddInfrastructure(builder.Configuration);
        builder.Services.AddApplication();

        var app = builder.Build();

        // Pipeline
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseMiddleware<ExceptionMiddleware>();

        app.MapControllers();
        app.Run();
    }
}
