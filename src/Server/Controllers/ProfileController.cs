using BlazorShop.Server.Auth.AuthTokenProvider;
using BlazorShop.Server.Services.ProfileService;
using BlazorShop.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BlazorShop.Server.Controllers;


[Route("api/profile")]
[ApiController]
public sealed class ProfileController : ControllerBase
{
    private readonly IAuthTokenProvider _authAuthTokenProvider;
    private readonly IProfileService _profileService;

    public ProfileController(IAuthTokenProvider authTokenProvider, IProfileService profileService)
    {
        _authAuthTokenProvider = authTokenProvider;
        _profileService = profileService;
    }
    
    [HttpGet]
    public async Task<ProfileDto> GetUserProfile()
    {
        var userId = _authAuthTokenProvider.GetUserIdFromContext(HttpContext);
        
        return await _profileService.GetUserProfileAsync(userId);
    }
    
    [HttpPost]
    public async Task UpdateUserProfile(ProfileDto newProfileDto)
    {
        var userId = _authAuthTokenProvider.GetUserIdFromContext(HttpContext);
        
        await _profileService.UpdateUserProfileAsync(userId, newProfileDto);
    }
    
    [HttpPost("email/change")]
    public async Task<TokenDto> ChangeEmail(EmailChangeDto emailChangeDto)
    {
        var userId = _authAuthTokenProvider.GetUserIdFromContext(HttpContext);
        
        return await _profileService.ChangeEmailAsync(userId, emailChangeDto);
    }
    
    
    [HttpPost("password/change")]
    public async Task ChangePassword(PasswordChangeDto passwordChangeDto)
    {
        var userId = _authAuthTokenProvider.GetUserIdFromContext(HttpContext);
        
        await _profileService.ChangePasswordAsync(userId, passwordChangeDto);
    }
}