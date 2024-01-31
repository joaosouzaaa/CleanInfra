using CleanInfra.API.Entities;

namespace CleanInfra.API.Interfaces.Repositories;

public interface IAnimalRepository
{
    Task<bool> AddAsync(Animal animal);
    Task<bool> UpdateAsync(Animal animal);
    Task<bool> DeleteAsync(int id);
    Task<Animal?> GetByIdAsync(int id);
    Task<List<Animal>> GetAllAsync();
}
