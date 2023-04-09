using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Shared.Dtos;

public sealed class AuthDto
{
    [Required] public bool IsSucceeded { get; set; }

    public string? Url { get; set; }

    public TokenDto? Tokens { get; set; }
}