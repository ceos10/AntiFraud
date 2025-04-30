using Microsoft.Extensions.Configuration;
using Company.Services.Business.Interfaces;
using Company.Services.Business.Services;
using Microsoft.Extensions.DependencyInjection;
using Company.Services.Data.Interface;
using Company.Services.Data;

namespace Company.Services.Ioc;

public static class DependencyContainer
{
    public static IServiceCollection RegisterBusiness(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ITransactionRepository, TransactionRepository>();
        services.AddScoped<ITransactionService, TransactionService>();

        return services;
    }
}
