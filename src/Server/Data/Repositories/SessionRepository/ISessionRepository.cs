using BlazorShop.Server.Data.Entities;
using BlazorShop.Server.Data.Repositories.BaseRepository;

namespace BlazorShop.Server.Data.Repositories.SessionRepository;

public interface ISessionRepository : IBaseRepository<Session>
{
    Task CreateSessionAsync(Guid userId, string accessToken, string refreshToken);
    Task UpdateSessionAsync(Guid userId, string accessToken, string refreshToken);
}