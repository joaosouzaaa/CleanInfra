using CleanInfra.API.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace CleanInfra.API.Settings.MigrationSettings;

public static class MigrationHandler
{
    public static void MigrateDatabase(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        using var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        try
        {
            dbContext.Database.Migrate();
        }
        catch
        {
            throw;
        }
    }
}
