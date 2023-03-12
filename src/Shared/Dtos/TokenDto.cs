using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Shared.Dtos;

public sealed class TokenDto
{
    public TokenDto(string accessToken, string refreshToken)
    {
        AccessToken = accessToken;
        RefreshToken = refreshToken;
    }
    
    [Required] public string AccessToken { get; set; }
    [Required] public string RefreshToken { get; set; }
}