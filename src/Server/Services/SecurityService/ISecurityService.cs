using BlazorShop.Server.Data.Entities;

namespace BlazorShop.Server.Services.SecurityService;

public interface ISecurityService
{
    Task<Security> CreateSecurityForUserAsync(Guid userId);
    Task<string> GenerateConfirmationTokenAsync(Guid userId);
    Task<string> GenerateConfirmationCodeAsync(Guid userId);
    Task<string> GenerateNewEmailConfirmationCodeAsync(Guid userId);
    Task<bool> IsConfirmationTokenValidAsync(Guid userId, string token);
    Task<bool> IsConfirmationCodeValidAsync(Guid userId, string code);
    Task<bool> IsNewEmailConfirmationCodeValidAsync(Guid userId, string code);
    Task RemoveConfirmationTokenAsync(Guid userId);
    Task RemoveConfirmationCodesAsync(Guid userId);
}