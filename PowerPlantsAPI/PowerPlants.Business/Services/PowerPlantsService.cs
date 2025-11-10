using AutoMapper;
using PowerPlants.Business.Dtos;
using PowerPlants.Persistence.Entities;
using PowerPlants.Persistence.Repositories;

namespace PowerPlants.Business.Services;

public class PowerPlantsService(IPowerPlantsRepository powerPlantsRepository, IMapper mapper) : IPowerPlantsService
{
    private readonly IPowerPlantsRepository _powerPlantsRepository = powerPlantsRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<List<PowerPlantResponse>> GetAllPowerPlantsAsync(string? ownerFilter = null)
    {
        List<PowerPlant> powerPlants = await _powerPlantsRepository.GetAllAsync(ownerFilter);
        return _mapper.Map<List<PowerPlantResponse>>(powerPlants);
    }

    public async Task<PowerPlantResponse?> GetPowerPlantByIdAsync(int id)
    {
        PowerPlant? powerPlant = await _powerPlantsRepository.GetByIdAsync(id);
        return powerPlant == null ? null : _mapper.Map<PowerPlantResponse>(powerPlant);
    }

    public async Task<CreatePowerPlantResponse> AddPowerPlantAsync(CreatePowerPlantRequest powerPlant)
    {
        PowerPlant entity = _mapper.Map<PowerPlant>(powerPlant);
        await _powerPlantsRepository.AddAsync(entity);
        return _mapper.Map<CreatePowerPlantResponse>(entity);
    }
}