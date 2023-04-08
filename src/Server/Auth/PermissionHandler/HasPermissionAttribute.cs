using BlazorShop.Server.Common;
using Microsoft.AspNetCore.Authorization;

namespace BlazorShop.Server.Auth.PermissionHandler;

public sealed class HasPermissionAttribute : AuthorizeAttribute
{
    public HasPermissionAttribute(Permissions permission) : 
        base(permission.ToString())
    {
    }
}