using BlazorShop.Server.Auth.AuthTokenProvider;
using BlazorShop.Server.Services.AuthService;
using BlazorShop.Shared.Dtos;
using BlazorShop.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorShop.Server.Controllers;

[AllowAnonymous]
[Route("api/authentication")]
[ApiController]
public sealed class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IAuthTokenProvider _authTokenProvider;
    
    public AuthController(IAuthService authService, IAuthTokenProvider authTokenProvider)
    {
        _authService = authService;
        _authTokenProvider = authTokenProvider;
    }
    
    [HttpPost("registration")]
    public async Task Register(RegisterDto registerDto)
    {
        await _authService.RegisterAsync(registerDto);
    }

    [HttpPost("login")]
    public async Task<string> FindLoginInfo(LoginDto loginDto)
    {
        return await _authService.FindLoginInfoAsync(loginDto);
    }
    
    [HttpPost("login/default")]
    public async Task<AuthDto> DefaultLogin(DefaultLoginDto defaultLoginDto)
    {
        return await _authService.DefaultLoginAsync(defaultLoginDto);
    }
    
    [HttpPost("login/2fa")]
    public async Task<AuthDto> TwoAuthLogin(TwoAuthLoginDto twoAuthLoginDto)
    {
        return await _authService.TwoAuthLoginAsync(twoAuthLoginDto);
    }
    
    [HttpPost("refresh")]
    public async Task<TokenDto> Refresh(TokenDto tokenDto)
    {
        return await _authService.RefreshAsync(tokenDto);
    }
    
    [HttpGet("confirmation-code")]
    public async Task GetConfirmationCode()
    {
        var userId = _authTokenProvider.GetUserIdFromContext(HttpContext);
        
        await _authService.GetConfirmationCodeAsync(userId);
    }
    
    [HttpGet("new-email/confirmation-code")]
    public async Task GetNewEmailConfirmationCode()
    { 
        var userId = _authTokenProvider.GetUserIdFromContext(HttpContext);
        
        await _authService.GetNewEmailConfirmationCodesAsync(userId);
    }
    
    [HttpGet("email/confirmation/request")]
    public async Task GetEmailConfirmationLink()
    {
        var userId = _authTokenProvider.GetUserIdFromContext(HttpContext);
        
        await _authService.GetEmailConfirmationLinkAsync(userId);
    }
    
    [HttpGet("password/reset/request")]
    public async Task GetPasswordResetLink()
    {
        var userId = _authTokenProvider.GetUserIdFromContext(HttpContext);
        
        await _authService.GetPasswordResetLinkAsync(userId);
    }
    
    [HttpPost("email/confirmation")]
    public async Task ConfirmEmail(ConfirmationParameters parameters)
    {
        await _authService.ConfirmEmailAsync(parameters);
    }
    
    [HttpPost("password/reset")]
    public async Task ResetPassword(PasswordResetDto passwordResetDto)
    {
        await _authService.ResetPasswordAsync(passwordResetDto);
    }
}