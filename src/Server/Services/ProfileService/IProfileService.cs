using BlazorShop.Server.Data.Entities;
using BlazorShop.Shared.Dtos;

namespace BlazorShop.Server.Services.ProfileService;

public interface IProfileService
{
    Task<ProfileDto> GetUserProfileAsync(Guid userId);
    Task<TokenDto> UpdateUserProfileAsync(User user, ProfileDto newProfileDto);
    Task<TokenDto> ChangeEmailAsync(User user, EmailChangeDto emailChangeDto);
    Task ChangePasswordAsync(User user, PasswordChangeDto passwordChangeDto);
}