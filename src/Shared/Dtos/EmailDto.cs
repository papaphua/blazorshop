using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Shared.Dtos;

public class EmailDto
{
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email.")]
    public string Email { get; set; } = null!;
}