using BlazorShop.Server.Services.ProfileService;
using BlazorShop.Server.Services.TokenService;
using BlazorShop.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BlazorShop.Server.Controllers;


[Route("api/profile")]
[ApiController]
public sealed class ProfileController : ControllerBase
{
    private readonly ITokenService _tokenService;
    private readonly IProfileService _profileService;

    public ProfileController(ITokenService tokenService, IProfileService profileService)
    {
        _tokenService = tokenService;
        _profileService = profileService;
    }
    
    [HttpGet]
    public async Task<ProfileDto> GetUserProfile()
    {
        var userId = _tokenService.GetUserIdFromContext(HttpContext);
        
        return await _profileService.GetUserProfileAsync(userId);
    }
}