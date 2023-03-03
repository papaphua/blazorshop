using Microsoft.AspNetCore.Authorization;

namespace BlazorShop.Client.Auth.PermissionHandler;

public sealed class HasPermissionAttribute : AuthorizeAttribute
{
    public HasPermissionAttribute(Permissions permission)
        : base(permission.ToString())
    {
    }
}