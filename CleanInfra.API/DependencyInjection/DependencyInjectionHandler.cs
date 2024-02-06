using CleanInfra.API.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace CleanInfra.API.DependencyInjection;

public static class DependencyInjectionHandler
{
    public static void AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            options.UseNpgsql(connectionString);
            options.EnableDetailedErrors();
            options.EnableSensitiveDataLogging();
        });

        services.AddRepositoriesDependencyInjection();
    }
}
