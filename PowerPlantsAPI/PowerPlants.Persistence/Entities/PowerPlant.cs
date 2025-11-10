using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PowerPlants.Persistence.Entities;

public class PowerPlant
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public required string Owner { get; set; }

    [Required]
    public double Power { get; set; }

    [Required]
    public DateOnly ValidFrom { get; set; }

    public DateOnly? ValidTo { get; set; }
}
