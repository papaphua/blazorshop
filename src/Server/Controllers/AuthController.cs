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
    
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    
    [HttpPost("registration")]
    public async Task Register(RegisterDto registerDto)
    {
        await _authService.RegisterAsync(registerDto);
    }
    
    [HttpPost("login")]
    public async Task<TokenDto> Login(LoginDto loginDto)
    {
        return await _authService.LoginAsync(loginDto);
    }
    
    [HttpPost("refresh")]
    public async Task<TokenDto> Refresh(TokenDto tokenDto)
    {
        return await _authService.RefreshAsync(tokenDto);
    }
    
    [HttpPost("confirmation-code")]
    public async Task GetConfirmationCode(string email)
    { 
        await _authService.GetConfirmationCodeAsync(email);
    }
    
    [HttpPost("email/confirmation/request")]
    public async Task GetEmailConfirmationLink(string email)
    {
        await _authService.GetEmailConfirmationLinkAsync(email);
    }
    
    [HttpPost("password/reset/request")]
    public async Task GetPasswordResetLink(string email)
    {
        await _authService.GetPasswordResetLinkAsync(email);
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