using BlazorShop.Server.Services.AuthService;
using BlazorShop.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorShop.Server.Controllers;

[Route("api/authentication")]
[ApiController]
public sealed class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    
    [AllowAnonymous]
    [HttpPost("registration")]
    public async Task Register(RegisterDto registerDto)
    {
        await _authService.RegisterAsync(registerDto);
    }
}