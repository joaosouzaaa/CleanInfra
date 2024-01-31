using CleanInfra.API.DatabaseContexts;
using CleanInfra.API.Interfaces.Repositories;
using CleanInfra.API.Repositories;
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

        services.AddScoped<IAnimalRepository, AnimalRepository>();
        services.AddScoped<IZooRepository, ZooRepository>();
    }
}
