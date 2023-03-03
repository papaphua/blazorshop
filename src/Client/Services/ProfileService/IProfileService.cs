using BlazorShop.Shared.Dtos;
using BlazorShop.Shared.Models;

namespace BlazorShop.Client.Services.ProfileService;

public interface IProfileService
{
    Task<ProfileDto> GetUserProfile();
    Task UpdateUserProfile(ProfileDto newProfileDto);
    Task ChangeEmail(EmailChangeDto emailChangeDto);
    Task ChangePassword(PasswordChangeDto passwordChangeDto);
    Task CreateDeleteProfileLink();
    Task DeleteProfile(ConfirmationParameters parameters);
}