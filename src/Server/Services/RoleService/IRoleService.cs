using BlazorShop.Server.Common;
using BlazorShop.Server.Data.Entities;

namespace BlazorShop.Server.Services.RoleService;

public interface IRoleService
{
    Task AddUserToRoleAsync(User user, Roles role);
}