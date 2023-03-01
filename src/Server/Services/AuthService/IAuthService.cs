using BlazorShop.Shared.Dtos;
using BlazorShop.Shared.Models;

namespace BlazorShop.Server.Services.AuthService;

public interface IAuthService
{
    Task RegisterAsync(RegisterDto registerDto);
    Task<string> FindLoginInfoAsync(LoginInfoDto loginInfoDto);
    Task<AuthDto> DefaultLoginAsync(DefaultLoginDto defaultLoginDto);
    Task<AuthDto> TwoAuthLoginAsync(TwoAuthLoginDto twoAuthLoginDto);
    // Task<TokenDto> LoginAsync(DefaultLoginDto defaultLoginDto);
    Task<TokenDto> RefreshAsync(TokenDto tokenDto);
    Task GetConfirmationCodeAsync(string email);
    Task GetEmailConfirmationLinkAsync(string email);
    Task GetPasswordResetLinkAsync(string email);
    Task ConfirmEmailAsync(ConfirmationParameters parameters);
    Task ResetPasswordAsync(PasswordResetDto passwordResetDto);
}