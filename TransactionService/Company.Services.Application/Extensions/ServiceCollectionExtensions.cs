using Company.Services.Application.Interfaces;
using Company.Services.Application.Mappers;
using Company.Services.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Company.Services.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddScoped<ITransactionService, TransactionService>();
        services.AddScoped<TransactionMapper>();

        return services;
    }
}
