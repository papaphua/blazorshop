using BlazorShop.Client.Auth.PermissionHandler;
using BlazorShop.Client.Services.HttpInterceptorService;
using BlazorShop.Client.Services.UserService;
using BlazorShop.Shared.Dtos;
using BlazorShop.Shared.Pagination;
using BlazorShop.Shared.Pagination.Parameters;
using Microsoft.AspNetCore.Components;

namespace BlazorShop.Client.Pages.Management;

[HasPermission(Permissions.AdminPermission)]
public sealed partial class Users : IDisposable
{
    private readonly BaseParameters _userParameters = new() { PageSize = 5 };
    [Inject] private IUserService UserService { get; set; } = null!;
    [Inject] private HttpInterceptorService HttpInterceptorService { get; set; } = null!;

    private List<UserDto> Items { get; set; } = new();
    private MetaData MetaData { get; set; } = new();

    public void Dispose()
    {
        HttpInterceptorService.DisposeEvent();
    }

    protected override async Task OnInitializedAsync()
    {
        HttpInterceptorService.RegisterEvent();
        _userParameters.PageNumber = 1;
        await GetUsers();
    }

    private async Task DeleteAction(UserDto user)
    {
        Items.Remove(user);
        await UserService.DeleteUser(user.Id);
    }

    private async Task SelectPageAction(int page)
    {
        _userParameters.PageNumber = page;
        await GetUsers();
    }

    private async Task GetUsers()
    {
        var pagingResponse = await UserService.GetUsers(_userParameters);
        Items = pagingResponse.Items;
        MetaData = pagingResponse.MetaData;
    }
}