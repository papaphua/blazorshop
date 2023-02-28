using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Shared.Dtos;

public class RegisterDto
{
    [Required(ErrorMessage = "Username is required.")]
    [StringLength(12, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
    [RegularExpression("^[a-zA-Z][a-zA-Z0-9]*$", ErrorMessage = "Invalid username.")]
    [DataType(DataType.Text)]
    public string Username { get; set; } = null!;

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email.")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Password is required.")]
    [StringLength(28, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
    [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = "Invalid password.")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
    
    [Required(ErrorMessage = "Confirm password is required.")]
    [Compare(nameof(Password))]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; } = null!;
}