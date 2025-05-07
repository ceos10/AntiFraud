using Company.Services.Business.Interfaces;
using Company.Services.Business.Mappers;
using Company.Services.Business.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Company.Services.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddScoped<IAntiFraudService, AntiFraudService>();
        services.AddScoped<AntiFraudMapper>();
        return services;
    }
}
