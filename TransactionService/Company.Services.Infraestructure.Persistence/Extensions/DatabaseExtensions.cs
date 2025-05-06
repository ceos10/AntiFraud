using Company.Services.Infraestructure.Persistence.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Company.Services.Infraestructure.Persistence.Extensions;

public static class DatabaseExtensions
{
    public static IApplicationBuilder EnsureDatabaseCreated(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<TransactionsDbContext>();
            db.Database.EnsureCreated();
        }

        return app;
    }
}

