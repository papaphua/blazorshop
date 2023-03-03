using BlazorShop.Shared.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace BlazorShop.Client.Auth.PermissionHandler;

public sealed class PermissionAuthHandler : AuthorizationHandler<PermissionRequirement>
{
    private const string NotAccessibleUri = "/deny/not-accessible";
    private const string NotAuthorizedUri = "deny/not-authorized";

    private readonly NavigationManager _navigationManager;

    public PermissionAuthHandler(NavigationManager navigationManager)
    {
        _navigationManager = navigationManager;
    }

    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        PermissionRequirement requirement)
    {
        var claims = context.User.Claims.ToList();

        if (claims.Count == 0)
        {
            context.Fail();
            _navigationManager.NavigateTo(NotAccessibleUri);
            return Task.CompletedTask;
        }

        var permissions = context.User.Claims.First(claim => claim.Type == CustomClaims.Permissions).Value;

        if (permissions.Contains(requirement.Permission))
        {
            context.Succeed(requirement);
        }
        else
        {
            _navigationManager.NavigateTo(NotAuthorizedUri);
            context.Fail();
        }

        return Task.CompletedTask;
    }
}