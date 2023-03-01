using BlazorShop.Server.Data.Entities;
using BlazorShop.Server.Data.Repositories.BaseRepository;

namespace BlazorShop.Server.Data.Repositories.SecurityRepository;

public interface ISecurityRepository : IBaseRepository<Security>
{
    Task CreateSecurityForUserAsync(Guid userId);
    Task<string> GenerateConfirmationCode(Guid userId);
    Task<bool> VerifyConfirmationCode(User user, string code);
    Task RemoveVerificationCode(Guid userId);
}