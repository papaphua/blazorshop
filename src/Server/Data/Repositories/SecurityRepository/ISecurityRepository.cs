using BlazorShop.Server.Data.Entities;
using BlazorShop.Server.Data.Repositories.BaseRepository;

namespace BlazorShop.Server.Data.Repositories.SecurityRepository;

public interface ISecurityRepository : IBaseRepository<Security>
{
    Task CreateSecurityForUserAsync(Guid userId);
    Task<string> GenerateConfirmationToken(Guid userId);
    Task<string> GenerateConfirmationCode(Guid userId);
    Task<bool> VerifyConfirmationCode(Guid userId, string code);
    Task<bool> VerifyConfirmationToken(Guid userId, string token);
    Task RemoveConfirmationCode(Guid userId);
    Task RemoveConfirmationToken(Guid userId);
}