using BlazorShop.Server.Data.Entities;

namespace BlazorShop.Server.Services.RoleService;

public interface IRoleService
{
    Task AddUserToRoleAsync(User user, Role role);
}