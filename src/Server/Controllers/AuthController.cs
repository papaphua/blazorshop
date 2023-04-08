using BlazorShop.Server.Auth.PermissionHandler;
using BlazorShop.Server.Common;
using BlazorShop.Server.Common.Providers;
using BlazorShop.Server.Common.Providers.TokenProvider;
using BlazorShop.Server.Services.AuthService;
using BlazorShop.Shared.Dtos;
using BlazorShop.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorShop.Server.Controllers;

[Route("api/authentication")]
[ApiController]
public sealed class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly ITokenProvider _tokenProvider;
    
    public AuthController(IAuthService authService, ITokenProvider tokenProvider)
    {
        _authService = authService;
        _tokenProvider = tokenProvider;
    }
    
    [AllowAnonymous]
    [HttpPost("registration")]
    public async Task Register(RegisterDto registerDto)
    {
        await _authService.RegisterAsync(registerDto);
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<string> FindLoginInfo(LoginDto loginDto)
    {
        return await _authService.FindLoginInfoAsync(loginDto);
    }
    
    [AllowAnonymous]
    [HttpPost("login/default")]
    public async Task<AuthDto> DefaultLogin(DefaultLoginDto defaultLoginDto)
    {
        return await _authService.DefaultLoginAsync(defaultLoginDto);
    }
    
    [AllowAnonymous]
    [HttpPost("login/2fa")]
    public async Task<AuthDto> TwoAuthLogin(TwoAuthLoginDto twoAuthLoginDto)
    {
        return await _authService.TwoAuthLoginAsync(twoAuthLoginDto);
    }
    
    [AllowAnonymous]
    [HttpPost("refresh")]
    public async Task<AuthDto> Refresh(TokenDto tokenDto)
    {
        return await _authService.RefreshAsync(tokenDto);
    }
    
    [HasPermission(Permissions.CustomerPermission)]
    [HttpGet("confirmation-code")]
    public async Task GetConfirmationCode()
    {
        var userId = _tokenProvider.GetUserIdFromContext(HttpContext);
        
        await _authService.GetConfirmationCodeAsync(userId);
    }
    
    [HasPermission(Permissions.CustomerPermission)]
    [HttpPost("new-email/confirmation-code")]
    public async Task GetNewEmailConfirmationCode(EmailDto emailDto)
    { 
        var userId = _tokenProvider.GetUserIdFromContext(HttpContext);
        
        await _authService.GetNewEmailConfirmationCodesAsync(userId, emailDto.Email);
    }
    
    [HasPermission(Permissions.CustomerPermission)]
    [HttpGet("email/confirmation/request")]
    public async Task GetEmailConfirmationLink()
    {
        var userId = _tokenProvider.GetUserIdFromContext(HttpContext);
        
        await _authService.GetEmailConfirmationLinkAsync(userId);
    }
    
    [AllowAnonymous]
    [HttpPost("password/reset/request")]
    public async Task GetPasswordResetLink(EmailDto emailDto)
    {
        await _authService.GetPasswordResetLinkAsync(emailDto);
    }
    
    [AllowAnonymous]
    [HttpPost("email/confirmation")]
    public async Task<ResponseDto> ConfirmEmail(ConfirmationParameters parameters)
    {
        return await _authService.ConfirmEmailAsync(parameters);
    }
    
    [AllowAnonymous]
    [HttpPost("password/reset")]
    public async Task ResetPassword(PasswordResetDto passwordResetDto)
    {
        await _authService.ResetPasswordAsync(passwordResetDto);
    }
}