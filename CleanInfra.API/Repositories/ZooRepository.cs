using CleanInfra.API.DatabaseContexts;
using CleanInfra.API.Entities;
using CleanInfra.API.Interfaces.Repositories;
using CleanInfra.API.Repositories.BaseRepositories;
using Microsoft.EntityFrameworkCore;

namespace CleanInfra.API.Repositories;

public sealed class ZooRepository(AppDbContext dbContext) : BaseRepository<Zoo>(dbContext), IZooRepository
{
    public async Task<bool> AddAsync(Zoo zoo)
    {
        await DbContextSet.AddAsync(zoo);

        return await SaveChangesAsync();
    }

    public async Task<bool> UpdateAsync(Zoo zoo)
    {
        dbContext.Entry(zoo).State = EntityState.Modified;

        return await SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var zoo = await DbContextSet.FindAsync(id);

        DbContextSet.Remove(zoo!);

        return await SaveChangesAsync();
    }

    public Task<Zoo?> GetByIdAsync(int id) =>
        DbContextSet.AsNoTracking()
                    .Include(z => z.Animals)
                    .FirstOrDefaultAsync(z => z.Id == id);

    public Task<List<Zoo>> GetAllAsync() =>
        DbContextSet.AsNoTracking()
                    .Include(z => z.Animals)
                    .ToListAsync();
}
