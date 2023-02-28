using BlazorShop.Server.Data;
using BlazorShop.Server.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorShop.Server.Services.PermissionService;

public sealed class PermissionService : IPermissionService
{
    private readonly AppDbContext _context;

    public PermissionService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<HashSet<string>> GetUserPermissionsAsync(Guid userId)
    {
        var roles = await _context.Set<User>()
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