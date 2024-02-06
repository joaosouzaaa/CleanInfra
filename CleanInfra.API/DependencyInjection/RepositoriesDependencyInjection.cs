using CleanInfra.API.Interfaces.Repositories;
using CleanInfra.API.Repositories;

namespace CleanInfra.API.DependencyInjection;

public static class RepositoriesDependencyInjection
{
    public static void AddRepositoriesDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IAnimalRepository, AnimalRepository>();
        services.AddScoped<IZooRepository, ZooRepository>();
    }
}
