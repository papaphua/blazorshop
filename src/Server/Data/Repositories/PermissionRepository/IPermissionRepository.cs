using BlazorShop.Server.Data.Entities;
using BlazorShop.Server.Data.Repositories.BaseRepository;

namespace BlazorShop.Server.Data.Repositories.PermissionRepository;

public interface IPermissionRepository : IBaseRepository<Permission>
{
    Task<HashSet<string>> GetUserPermissionsAsync(Guid userId);
}