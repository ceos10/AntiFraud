using Company.Services.Application.Interfaces;
using Company.Services.Infraestructure.Persistence.Contexts;
using Company.Services.Infraestructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Company.Services.Infraestructure.Persistence.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ITransactionRepository, TransactionRepository>();
        services.AddDbContext<TransactionsDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("TransactionDb");
            options.UseNpgsql(connectionString);
        });

        return services;
    }
}
