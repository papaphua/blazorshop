using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Shared.Dtos;

public sealed class PasswordResetDto
{
    [Required] public string Email { get; set; } = null!;
    [Required] public string Code { get; set; } = null!;
    [Required] public string Password { get; set; } = null!;
    [Required] public string ConfirmPassword { get; set; } = null!;
}