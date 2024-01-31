using CleanInfra.API.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace CleanInfra.API.Repositories.BaseRepositories;

public abstract class BaseRepository<TEntity>(AppDbContext dbContext) : IDisposable
    where TEntity : class
{
    protected DbSet<TEntity> DbContextSet => dbContext.Set<TEntity>();

    public void Dispose()
    {
        dbContext.Dispose();

        GC.SuppressFinalize(this);
    }

    protected async Task<bool> SaveChangesAsync() =>
        await dbContext.SaveChangesAsync() > 0;
}
