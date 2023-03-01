using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Shared.Dtos;

public sealed class ProfileDto
{
    [Required(ErrorMessage = "Username is required.")]
    [StringLength(12, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
    [RegularExpression("^[a-zA-Z][a-zA-Z0-9]*$")]
    [DataType(DataType.Text)]
    public string Username { get; set; } = null!;

    [RegularExpression(@"^[a-zA-Z]+$")] public string? FirstName { get; set; }

    [RegularExpression(@"^[a-zA-Z]+$")] public string? LastName { get; set; }

    [RegularExpression(@"^[a-zA-Z]+$")] public string? Gender { get; set; }

    public DateTime? BirthDate { get; set; }
}