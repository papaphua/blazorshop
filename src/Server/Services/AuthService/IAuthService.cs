using BlazorShop.Shared.Dtos;
using BlazorShop.Shared.Models;

namespace BlazorShop.Server.Services.AuthService;

public interface IAuthService
{
    Task RegisterAsync(RegisterDto registerDto);
    Task<string> FindLoginInfoAsync(LoginDto loginDto);
    Task<AuthDto> DefaultLoginAsync(DefaultLoginDto defaultLoginDto);
    Task<AuthDto> TwoAuthLoginAsync(TwoAuthLoginDto twoAuthLoginDto);
    Task<AuthDto> RefreshAsync(TokenDto tokenDto);
    Task GetConfirmationCodeAsync(Guid userId);
    Task GetNewEmailConfirmationCodesAsync(Guid userId);
    Task GetEmailConfirmationLinkAsync(Guid userId);
    Task GetPasswordResetLinkAsync(EmailDto emailDto);
    Task ConfirmEmailAsync(ConfirmationParameters parameters);
    Task ResetPasswordAsync(PasswordResetDto passwordResetDto);
}