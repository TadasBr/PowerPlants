using Microsoft.AspNetCore.Mvc;
using PowerPlants.Business.Dtos;
using PowerPlants.Business.Services;
using System.Net;

namespace PowerPlants.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PowerPlantsController(IPowerPlantsService powerPlantsService) : ControllerBase
{
    private readonly IPowerPlantsService _powerPlantsService = powerPlantsService;

    [HttpGet]
    [ProducesResponseType(typeof(List<PowerPlantResponse>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAllPowerPlants([FromQuery] string? ownerFilter)
    {
        var powerPlants = await _powerPlantsService.GetAllPowerPlantsAsync(ownerFilter);
        return Ok(powerPlants);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(PowerPlantResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetPowerPlantById(int id)
    {
        var powerPlant = await _powerPlantsService.GetPowerPlantByIdAsync(id);

        if (powerPlant == null)
        {
            return NotFound();
        }

        return Ok(powerPlant);
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreatePowerPlantResponse), (int)HttpStatusCode.Created)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> CreatePowerPlant([FromBody] CreatePowerPlantRequest powerPlant)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        CreatePowerPlantResponse createdPowerPlant = await _powerPlantsService.AddPowerPlantAsync(powerPlant);

        return CreatedAtAction(
            nameof(GetPowerPlantById),
            new { id = createdPowerPlant.Id },
            createdPowerPlant);
    }
}