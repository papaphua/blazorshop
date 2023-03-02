using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Shared.Dtos;

public sealed class EmailChangeDto
{
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email.")]
    [Display(Name = "New email")]
    public string NewEmail { get; set; } = null!;

    [Required(ErrorMessage = "Confirmation code is required.")]
    [Display(Name = "Confirmation code from current email")]
    public string CurrentConfirmationCode { get; set; } = null!;
    
    [Required(ErrorMessage = "Confirmation code is required.")]
    [Display(Name = "Confirmation code from new email")]
    public string NewConfirmationCode { get; set; } = null!;
}