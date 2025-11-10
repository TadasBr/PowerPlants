using PowerPlants.Business.Dtos;

namespace PowerPlants.Business.Services;

public interface IPowerPlantsService
{
    Task<List<PowerPlantResponse>> GetAllPowerPlantsAsync(string? ownerFilter = null);
    Task<PowerPlantResponse?> GetPowerPlantByIdAsync(int id);
    Task<CreatePowerPlantResponse> AddPowerPlantAsync(CreatePowerPlantRequest powerPlant);
}