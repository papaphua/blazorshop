using BlazorShop.Server.Auth.PermissionHandler;
using BlazorShop.Server.Common;
using BlazorShop.Server.Common.Providers.TokenProvider;
using BlazorShop.Server.Facades.AuthFacade;
using BlazorShop.Shared.Dtos;
using BlazorShop.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorShop.Server.Controllers;

[Route("api/authentication")]
[ApiController]
public sealed class AuthController : ControllerBase
{
    private readonly IAuthFacade _authFacade;
    private readonly ITokenProvider _tokenProvider;
    
    public AuthController(IAuthFacade authFacade, ITokenProvider tokenProvider)
    {
        _authFacade = authFacade;
        _tokenProvider = tokenProvider;
    }
    
    [AllowAnonymous]
    [HttpPost("registration")]
    public async Task Register(RegisterDto registerDto)
    {
        await _authFacade.RegisterAsync(registerDto);
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<string> FindLoginInfo(LoginDto loginDto)
    {
        return await _authFacade.FindLoginInfoAsync(loginDto);
    }
    
    [AllowAnonymous]
    [HttpPost("login/default")]
    public async Task<AuthDto> DefaultLogin(DefaultLoginDto defaultLoginDto)
    {
        return await _authFacade.DefaultLoginAsync(defaultLoginDto);
    }
    
    [AllowAnonymous]
    [HttpPost("login/2fa")]
    public async Task<AuthDto> TwoAuthLogin(TwoAuthLoginDto twoAuthLoginDto)
    {
        return await _authFacade.TwoAuthLoginAsync(twoAuthLoginDto);
    }
    
    [AllowAnonymous]
    [HttpPost("refresh")]
    public async Task<AuthDto> Refresh(TokenDto tokenDto)
    {
        return await _authFacade.RefreshAsync(tokenDto);
    }
    
    [HasPermission(Permissions.CustomerPermission)]
    [HttpGet("confirmation-code")]
    public async Task GetConfirmationCode()
    {
        var userId = _tokenProvider.GetUserIdFromContext(HttpContext);
        
        await _authFacade.GetConfirmationCodeAsync(userId);
    }
    
    [HasPermission(Permissions.CustomerPermission)]
    [HttpPost("new-email/confirmation-code")]
    public async Task GetNewEmailConfirmationCode(EmailDto emailDto)
    { 
        var userId = _tokenProvider.GetUserIdFromContext(HttpContext);
        
        await _authFacade.GetNewEmailConfirmationCodesAsync(userId, emailDto.Email);
    }
    
    [HasPermission(Permissions.CustomerPermission)]
    [HttpGet("email/confirmation/request")]
    public async Task GetEmailConfirmationLink()
    {
        var userId = _tokenProvider.GetUserIdFromContext(HttpContext);
        
        await _authFacade.GetEmailConfirmationLinkAsync(userId);
    }
    
    [AllowAnonymous]
    [HttpPost("password/reset/request")]
    public async Task GetPasswordResetLink(EmailDto emailDto)
    {
        await _authFacade.GetPasswordResetLinkAsync(emailDto);
    }
    
    [AllowAnonymous]
    [HttpPost("email/confirmation")]
    public async Task<ResponseDto> ConfirmEmail(ConfirmationParameters parameters)
    {
        return await _authFacade.ConfirmEmailAsync(parameters);
    }
    
    [AllowAnonymous]
    [HttpPost("password/reset")]
    public async Task ResetPassword(PasswordResetDto passwordResetDto)
    {
        await _authFacade.ResetPasswordAsync(passwordResetDto);
    }
}