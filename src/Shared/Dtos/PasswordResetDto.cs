using System.ComponentModel.DataAnnotations;
using BlazorShop.Shared.Models;

namespace BlazorShop.Shared.Dtos;

public sealed class PasswordResetDto
{
    [Required(ErrorMessage = "Password is required.")]
    [StringLength(28, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
    [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = "Invalid password.")]
    [DataType(DataType.Password)]
    [Display(Name = "New password")]
    public string NewPassword { get; set; } = null!;

    [Required(ErrorMessage = "Confirm password is required.")]
    [Compare(nameof(NewPassword))]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm new password")]
    public string ConfirmPassword { get; set; } = null!;

    [Required] public ConfirmationParameters ConfirmationParameters { get; set; } = null!;
}