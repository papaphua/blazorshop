using BlazorShop.Shared.Dtos;
using BlazorShop.Shared.Models;

namespace BlazorShop.Server.Facades.ProfileFacade;

public interface IProfileFacade
{
    Task<ProfileDto> GetUserProfileAsync(Guid userId);
    Task<TokenDto> UpdateUserProfileAsync(Guid userId, ProfileDto newProfileDto);
    Task<TokenDto> ChangeEmailAsync(Guid userId, EmailChangeDto emailChangeDto);
    Task ChangePasswordAsync(Guid userId, PasswordChangeDto passwordChangeDto);
    Task GetDeleteProfileLinkAsync(Guid userId);
    Task DeleteProfileAsync(ConfirmationParameters parameters);
}