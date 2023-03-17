using BlazorShop.Client.Services.CategoryService;
using BlazorShop.Client.Services.ProfileService;
using BlazorShop.Shared.Dtos;
using Microsoft.AspNetCore.Components;

namespace BlazorShop.Client.Shared;

public sealed partial class SideMenu
{
    [Inject] private ICategoryService CategoryService { get; set; } = null!;
    [Inject] private IProfileService ProfileService { get; set; } = null!;

    private List<CategoryDto> Categories { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        Categories = await CategoryService.GetCategories();
    }
}