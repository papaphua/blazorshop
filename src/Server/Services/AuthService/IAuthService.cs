using BlazorShop.Shared.Dtos;
using BlazorShop.Shared.Models;

namespace BlazorShop.Server.Services.AuthService;

public interface IAuthService
{
    Task RegisterAsync(RegisterDto registerDto);
    Task<TokenDto> LoginAsync(LoginDto loginDto);
    Task<TokenDto> RefreshAsync(TokenDto tokenDto);
    Task GetConfirmationCodeAsync(string email);
    Task GetEmailConfirmationLinkAsync(string email);
    Task GetPasswordResetLinkAsync(string email);
    Task ConfirmEmailAsync(ConfirmationParameters parameters);
    Task ResetPasswordAsync(PasswordResetDto passwordResetDto);
}