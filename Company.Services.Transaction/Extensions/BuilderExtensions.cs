using Company.Services.Transaction.Interfaces;
using System.Reflection;

namespace Company.Services.Transaction.Extensions;

public static class BuilderExtensions
{
    public static IApplicationBuilder MapEndpointDefinitions(this WebApplication app, Assembly assembly = null)
    {
        assembly ??= Assembly.GetCallingAssembly();

        var endpointDefinitions = assembly.GetTypes()
                .Where(x => x.IsAssignableTo(typeof(IEndpointRouteDefinition)) && !x.IsAbstract && !x.IsInterface)
                .Select(Activator.CreateInstance)
                .Cast<IEndpointRouteDefinition>();

        foreach (var item in endpointDefinitions)
            item.RegisterEndpoints(app);

        return app;
    }
}
