using BlazorShop.Server.Data.Entities;
using BlazorShop.Server.Data.Repositories.BaseRepository;
using BlazorShop.Shared.Pagination.Parameters;

namespace BlazorShop.Server.Data.Repositories.UserRepository;

public interface IUserRepository : IBaseRepository<User>
{
    Task<List<User>> GetByParametersAsync(BaseParameters parameters);
    Task<User?> GetByIdAsync(Guid id);
    Task<User?> GetByUsernameAsync(string username);
    Task<User?> GetByEmailAsync(string email);
}