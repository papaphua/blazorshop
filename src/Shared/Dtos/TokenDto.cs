using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Shared.Dtos;

public class TokenDto
{
    [Required] public string AccessToken { get; set; } = null!;
    [Required] public string RefreshToken { get; set; } = null!;
}