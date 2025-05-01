using Company.Services.Business.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Company.Services.Business.Interfaces;
using Company.Services.Business.Mappers;

namespace Company.Services.Ioc;

public static class DependencyContainer
{
    public static IServiceCollection RegisterBusiness(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IAntiFraudService, AntiFraudService>();
        services.AddScoped<AntiFraudMapper>();
        return services;
    }
}
