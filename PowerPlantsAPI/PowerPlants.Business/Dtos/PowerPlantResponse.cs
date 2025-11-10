namespace PowerPlants.Business.Dtos;

public class PowerPlantResponse
{
    public required string Owner { get; set; }
    public double Power { get; set; }
    public DateOnly ValidFrom { get; set; }
    public DateOnly? ValidTo { get; set; }
}
