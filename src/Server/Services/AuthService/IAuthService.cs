using BlazorShop.Shared.Dtos;

namespace BlazorShop.Server.Services.AuthService;

public interface IAuthService
{
    Task RegisterAsync(RegisterDto registerDto);
    Task<TokenDto> LoginAsync(LoginDto loginDto);
    Task<TokenDto> RefreshAsync(TokenDto tokenDto);
}