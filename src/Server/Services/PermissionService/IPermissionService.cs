namespace BlazorShop.Server.Services.PermissionService;

public interface IPermissionService
{
    Task<HashSet<string>> GetUserPermissionsAsync(Guid userId);
}