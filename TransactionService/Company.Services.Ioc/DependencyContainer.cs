using Microsoft.Extensions.Configuration;
using Company.Services.Business.Interfaces;
using Company.Services.Business.Services;
using Microsoft.Extensions.DependencyInjection;
using Company.Services.Data.Interface;
using Company.Services.Data;
using Company.Services.Business.Mappers;
using Company.Services.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Company.Services.Ioc;

public static class DependencyContainer
{
    public static IServiceCollection RegisterBusiness(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ITransactionRepository, TransactionRepository>();
        services.AddScoped<ITransactionService, TransactionService>();
        services.AddScoped<TransactionMapper>();

        return services;
    }

    public static IServiceCollection RegisterDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TransactionsDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("TransactionDb");
            options.UseNpgsql(connectionString);
        });

        return services;
    }
}
