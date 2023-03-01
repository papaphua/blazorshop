using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Shared.Dtos;

public sealed class EmailConfirmationDto
{
    [Required] public string Email { get; set; } = null!;
    [Required] public string Code { get; set; } = null!;
}