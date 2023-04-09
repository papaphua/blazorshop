using BlazorShop.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorShop.Server.Services.PermissionService;

public sealed class PermissionService : IPermissionService
{
    private readonly AppDbContext _db;

    public PermissionService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<HashSet<string>> GetUserPermissionsAsync(Guid userId)
    {
        var roles = await _db.Users
            .Where(user => user.Id.Equals(userId))
            .Include(user => user.Role)
            .ThenInclude(role => role.Permissions)
            .Select(user => user.Role)
            .ToListAsync();

        return roles
            .Select(role => role.Permissions)
            .SelectMany(permissions => permissions)
            .Select(permission => permission.Name)
            .ToHashSet();
    }
}