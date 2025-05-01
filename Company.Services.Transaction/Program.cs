
using Company.Services.Transaction.Extensions;
using Company.Services.Ioc;
using Company.Services.Data.Extensions;

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
        builder.Services.RegisterBusiness(builder.Configuration)
            .RegisterDatabase(builder.Configuration)
            .RegisterKafka(builder.Configuration);

        var app = builder.Build();

        //// Automatically create database and tables if they don't exist
        //using (var scope = app.Services.CreateScope())
        //{
        //    var db = scope.ServiceProvider.GetRequiredService<TransactionsDbContext>();
        //    db.Database.EnsureCreated();
        //}

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
