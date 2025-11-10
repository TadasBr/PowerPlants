using AutoMapper;
using PowerPlants.Business.Dtos;
using PowerPlants.Persistence.Entities;

namespace PowerPlants.Business.Mappings;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<PowerPlant, PowerPlantResponse>();
        CreateMap<PowerPlant, CreatePowerPlantResponse>();
        CreateMap<CreatePowerPlantRequest, PowerPlant>();
    }
}
