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

    public async Task AddUserToRoleAsync(User user, Role role)
    {
        var userRole = new UserRole(user.Id, role.Id);

        await _context.Set<UserRole>().AddAsync(userRole);
        
        await _context.SaveChangesAsync();
    }
}