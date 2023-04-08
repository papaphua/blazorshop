using BlazorShop.Server.Common;
using BlazorShop.Server.Data;
using BlazorShop.Server.Data.Entities;
using BlazorShop.Server.Data.Entities.JointEntities;

namespace BlazorShop.Server.Services.RoleService;

public sealed class RoleService : IRoleService
{
    private readonly AppDbContext _context;

    public RoleService(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddUserToRoleAsync(User user, Roles role)
    {
        var userRole = new UserRole(user.Id, (int)role);

        await _context.Set<UserRole>().AddAsync(userRole);
        
        await _context.SaveChangesAsync();
    }
}