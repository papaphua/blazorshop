using BlazorShop.Server.Auth.AuthTokenProvider;
using BlazorShop.Server.Services.ProfileService;
using BlazorShop.Shared.Dtos;
using BlazorShop.Shared.Models;
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
    
    [HttpPut]
    public async Task<TokenDto> UpdateUserProfile(ProfileDto newProfileDto)
    {
        var userId = _authAuthTokenProvider.GetUserIdFromContext(HttpContext);
        
        return await _profileService.UpdateUserProfileAsync(userId, newProfileDto);
    }
    
    [HttpPatch("email/change")]
    public async Task<TokenDto> ChangeEmail(EmailChangeDto emailChangeDto)
    {
        var userId = _authAuthTokenProvider.GetUserIdFromContext(HttpContext);
        
        return await _profileService.ChangeEmailAsync(userId, emailChangeDto);
    }
    
    
    [HttpPatch("password/change")]
    public async Task ChangePassword(PasswordChangeDto passwordChangeDto)
    {
        var userId = _authAuthTokenProvider.GetUserIdFromContext(HttpContext);
        
        await _profileService.ChangePasswordAsync(userId, passwordChangeDto);
    }
    
    [HttpGet("delete/request")]
    public async Task CreateDeleteProfileLink()
    {
        var userId = _authAuthTokenProvider.GetUserIdFromContext(HttpContext);

        await _profileService.GetDeleteProfileLinkAsync(userId);
    }
    
    [HttpPost("delete/confirmation")]
    public async Task DeleteProfile(ConfirmationParameters parameters)
    {
        await _profileService.DeleteProfileAsync(parameters);
    }
}