using BlazorShop.Shared.Auth;
using Microsoft.AspNetCore.Authorization;

namespace BlazorShop.Server.Auth.PermissionHandler;

public sealed class PermissionAuthHandler : AuthorizationHandler<PermissionRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
        PermissionRequirement requirement)
    {
        var claims = context.User.Claims.ToList();

        if (claims.Count == 0)
        {
            context.Fail();
            return Task.CompletedTask;
        }

        var permissions = context.User.Claims
            .Where(claim => claim.Type == CustomClaims.Permissions)
            .Select(claim => claim.Value)
            .ToHashSet();

        if (permissions.Contains(requirement.Permission)) context.Succeed(requirement);

        return Task.CompletedTask;
    }
}