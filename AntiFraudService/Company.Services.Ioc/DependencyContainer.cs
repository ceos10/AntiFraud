using Company.Services.Business.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Company.Services.Business.Interfaces;

namespace Company.Services.Ioc;

public static class DependencyContainer
{
    public static IServiceCollection RegisterBusiness(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IAntiFraudService, AntiFraudService>();
        return services;
    }
}
