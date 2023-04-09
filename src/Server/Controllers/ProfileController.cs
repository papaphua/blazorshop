using System.Security.Claims;
using BlazorShop.Server.Auth.PermissionHandler;
using BlazorShop.Server.Common;
using BlazorShop.Server.Common.Providers.TokenProvider;
using BlazorShop.Server.Facades.ProfileFacade;
using BlazorShop.Shared.Dtos;
using BlazorShop.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorShop.Server.Controllers;

[Route("api/profile")]
[ApiController]
public sealed class ProfileController : ControllerBase
{
    private readonly IProfileFacade _profileFacade;
    private readonly ITokenProvider _tokenProvider;

    public ProfileController(ITokenProvider authTokenProvider, IProfileFacade profileFacade)
    {
        _tokenProvider = authTokenProvider;
        _profileFacade = profileFacade;
    }

    [HasPermission(Permissions.CustomerPermission)]
    [HttpGet]
    public async Task<ProfileDto> GetUserProfile()
    {
        var userId = _tokenProvider.GetUserIdFromContext(HttpContext);

        return await _profileFacade.GetUserProfileAsync(userId);
    }

    [HasPermission(Permissions.CustomerPermission)]
    [HttpPut]
    public async Task<TokenDto> UpdateUserProfile(ProfileDto newProfileDto)
    {
        var userId = _tokenProvider.GetUserIdFromContext(HttpContext);

        return await _profileFacade.UpdateUserProfileAsync(userId, newProfileDto);
    }

    [HasPermission(Permissions.CustomerPermission)]
    [HttpPatch("email/change")]
    public async Task<TokenDto> ChangeEmail(EmailChangeDto emailChangeDto)
    {
        var userId = Guid.Parse(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        return await _profileFacade.ChangeEmailAsync(userId, emailChangeDto);
    }

    [HasPermission(Permissions.CustomerPermission)]
    [HttpPatch("password/change")]
    public async Task ChangePassword(PasswordChangeDto passwordChangeDto)
    {
        var userId = _tokenProvider.GetUserIdFromContext(HttpContext);

        await _profileFacade.ChangePasswordAsync(userId, passwordChangeDto);
    }

    [HasPermission(Permissions.CustomerPermission)]
    [HttpGet("delete/request")]
    public async Task CreateDeleteProfileLink()
    {
        var userId = _tokenProvider.GetUserIdFromContext(HttpContext);

        await _profileFacade.GetDeleteProfileLinkAsync(userId);
    }

    [AllowAnonymous]
    [HttpPost("delete/confirmation")]
    public async Task DeleteProfile(ConfirmationParameters parameters)
    {
        await _profileFacade.DeleteProfileAsync(parameters);
    }
}