using CleanInfra.API.DatabaseContexts;
using CleanInfra.API.Entities;
using CleanInfra.API.Interfaces.Repositories;
using CleanInfra.API.Repositories.BaseRepositories;
using Microsoft.EntityFrameworkCore;

namespace CleanInfra.API.Repositories;

public sealed class AnimalRepository(AppDbContext dbContext) : BaseRepository<Animal>(dbContext), IAnimalRepository
{
    public async Task<bool> AddAsync(Animal animal)
    {
        await DbContextSet.AddAsync(animal);

        return await SaveChangesAsync();
    }

    public async Task<bool> UpdateAsync(Animal animal)
    {
        dbContext.Entry(animal).State = EntityState.Modified;

        return await SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var animal = await DbContextSet.FindAsync(id);

        DbContextSet.Remove(animal!);

        return await SaveChangesAsync();
    }

    public Task<Animal?> GetByIdAsync(int id) =>
        DbContextSet.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);

    public Task<List<Animal>> GetAllAsync() =>
        DbContextSet.AsNoTracking().ToListAsync();
}
