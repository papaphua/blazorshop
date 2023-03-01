using BlazorShop.Server.Data.Entities;
using BlazorShop.Server.Data.Repositories.BaseRepository;

namespace BlazorShop.Server.Data.Repositories.SecurityRepository;

public interface ISecurityRepository : IBaseRepository<Security>
{
    Task CreateSecurityForUser(Guid userId);
    Task GenerateEmailConfirmationCode(Guid userId);
    Task VerifyEmailConfirmationCode(User user, string code);
}