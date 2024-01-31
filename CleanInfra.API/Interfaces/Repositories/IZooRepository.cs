using CleanInfra.API.Entities;

namespace CleanInfra.API.Interfaces.Repositories;

public interface IZooRepository
{
    Task<bool> AddAsync(Zoo zoo);
    Task<bool> UpdateAsync(Zoo zoo);
    Task<bool> DeleteAsync(int id);
    Task<Zoo?> GetByIdAsync(int id);
    Task<List<Zoo>> GetAllAsync();
}
