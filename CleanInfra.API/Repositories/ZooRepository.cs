using CleanInfra.API.DatabaseContexts;
using CleanInfra.API.Entities;
using CleanInfra.API.Interfaces.Repositories;
using CleanInfra.API.Repositories.BaseRepositories;

namespace CleanInfra.API.Repositories;

public sealed class ZooRepository(AppDbContext dbContext) : BaseRepository<Zoo>(dbContext), IZooRepository
{
}
