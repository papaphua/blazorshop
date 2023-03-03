using Microsoft.AspNetCore.Authorization;

namespace BlazorShop.Client.Auth.PermissionHandler;

public sealed class PermissionRequirement : IAuthorizationRequirement
{
    public PermissionRequirement(string permission)
    {
        Permission = permission;
    }

    public string Permission { get; }
}