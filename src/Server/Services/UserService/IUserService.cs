using BlazorShop.Server.Data.Entities;
using BlazorShop.Shared.Pagination.Parameters;

namespace BlazorShop.Server.Services.UserService;

public interface IUserService
{
    Task<List<User>> GetUsersByParametersAsync(BaseParameters parameters);
    Task<User?> GetUserByIdAsync(Guid id);
    Task<User?> GetUserByUsernameAsync(string username);
    Task<User?> GetUserByEmailAsync(string email);
}