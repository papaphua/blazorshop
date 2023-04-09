using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Shared.Dtos;

public sealed class EmailChangeDto
{
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email.")]
    public string NewEmail { get; set; } = null!;

    [Required(ErrorMessage = "Confirmation code is required.")]
    public string CurrentConfirmationCode { get; set; } = null!;

    [Required(ErrorMessage = "Confirmation code is required.")]
    public string NewConfirmationCode { get; set; } = null!;
}