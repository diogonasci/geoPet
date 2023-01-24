using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GeoPet.Application.DTOs;

// Entender melhor o momento onde as validações são feitas

public class PetDTO
{
    [JsonIgnore]
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must have at least 3 characters")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Breed is required")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Breed must have at least 3 characters")]
    public string Breed { get; set; }

    [Required(ErrorMessage = "Gender is required")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Gender must have at least 3 characters")]
    public string Gender { get; set; }

    [Required(ErrorMessage = "Weight is required")]
    [Range(0, 300, ErrorMessage = "Invalid weight")]
    public double Weight { get; set; }

    [Required(ErrorMessage = "Age is required")]
    [Range(0, 20, ErrorMessage = "Invalid age")]
    public int Age { get; set; }

}
