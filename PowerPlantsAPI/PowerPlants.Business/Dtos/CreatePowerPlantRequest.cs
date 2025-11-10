using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PowerPlants.Business.Dtos;

public class CreatePowerPlantRequest : IValidatableObject
{
    [Required(ErrorMessage = "Missing field 'Owner'")]
    public required string Owner { get; set; }

    [Required(ErrorMessage = "Missing field 'Power")]
    [Range(0, 200, ErrorMessage = "Power must be between 0 and 200")]
    public double? Power { get; set; }

    [Required(ErrorMessage = "Missing field 'ValidFrom")]
    public DateOnly? ValidFrom { get; set; }

    public DateOnly? ValidTo { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (!string.IsNullOrWhiteSpace(Owner))
        {
            var pattern = @"^[a-zA-ZÀ-ž]+\s[a-zA-ZÀ-ž]+$";

            if (!Regex.IsMatch(Owner.Trim(), pattern))
            {
                yield return new ValidationResult(
                    "Owner must consist of exactly two words (text-only characters) separated by a whitespace",
                    new[] { nameof(Owner)});
            }
        }

        //Was not in the requirements, but I thought it would make sense
        if (ValidTo.HasValue && ValidTo.Value <= ValidFrom)
        {
            yield return new ValidationResult(
                "ValidTo date must be later than the ValidFrom date.",
                new[] { nameof(ValidTo) });
        }
    }
}