using PowerPlants.Persistence.Entities;

namespace PowerPlants.Persistence.Repositories;

public interface IPowerPlantsRepository
{
    Task<List<PowerPlant>> GetAllAsync(string? ownerFilter = null);
    Task<PowerPlant?> GetByIdAsync(int id);
    Task AddAsync(PowerPlant powerPlant);
}