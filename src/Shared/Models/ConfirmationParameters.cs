using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Shared.Models;

public class ConfirmationParameters
{
    public ConfirmationParameters(string token, string email)
    {
        Token = token;
        Email = email;
    }

    [Required] public string Token { get; set; }
    [Required] public string Email { get; set; }
}