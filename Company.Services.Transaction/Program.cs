
using Company.Service.Infraestructure.Bus.Extensions;
using Company.Services.Application.Extensions;
using Company.Services.Infraestructure.Persistence.Extensions;
using Company.Services.Transaction.Extensions;

namespace Company.Services.Transaction;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddApplicationLayer()
            .AddPersistenceInfrastructure(builder.Configuration)
            .RegisterKafka(builder.Configuration);

        var app = builder.Build();

        // Automatically create database and tables if they don't exist
        app.EnsureDatabaseCreated();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapEndpointDefinitions();
        app.MapControllers();

        app.Run();
    }
}
