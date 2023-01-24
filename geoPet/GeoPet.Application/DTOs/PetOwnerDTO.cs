using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GeoPet.Application.DTOs;

public class PetOwnerDTO
{
    [JsonIgnore]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Name is required")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must have at least 3 characters")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must have at least 6 characters")]
    public string Password { get; set; }

}