using System.ComponentModel.DataAnnotations;

namespace PowerPlants.API.Dtos;

public class PowerPlantResponse
{
    [Required]
    public required string Owner { get; set; }

    [Required]
    public double Power { get; set; }

    [Required]
    public DateOnly ValidFrom { get; set; }

    public DateOnly ValidTo { get; set; }
}
