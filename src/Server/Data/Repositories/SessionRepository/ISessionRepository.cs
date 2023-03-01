using BlazorShop.Server.Data.Entities;
using BlazorShop.Server.Data.Repositories.BaseRepository;

namespace BlazorShop.Server.Data.Repositories.SessionRepository;

public interface ISessionRepository : IBaseRepository<Session>
{
    Task CreateSession(Guid userId, string accessToken, string refreshToken);
    Task UpdateSession(Guid userId, string accessToken, string refreshToken);
}