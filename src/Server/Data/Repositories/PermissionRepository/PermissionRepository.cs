using BlazorShop.Server.Data.Entities;
using BlazorShop.Server.Data.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace BlazorShop.Server.Data.Repositories.PermissionRepository;

public sealed class PermissionRepository : BaseRepository<Permission>, IPermissionRepository
{
    public PermissionRepository(AppDbContext context) 
        : base(context)
    {
    }
    
    public async Task<HashSet<string>> GetUserPermissionsAsync(Guid userId)
    {
        var roles = await Context.Set<User>()
            .Where(user => user.Id == userId)
            .Include(user => user.Roles)
            .ThenInclude(role => role.Permissions)
            .Select(user => user.Roles)
            .ToArrayAsync();

        return roles
            .SelectMany(roleList => roleList)
            .SelectMany(role => role.Permissions)
            .Select(permission => permission.Name)
            .ToHashSet();
    }
}