using BlazorShop.Client.Services.CategoryService;
using BlazorShop.Shared.Dtos;
using Microsoft.AspNetCore.Components;

namespace BlazorShop.Client.Shared.SiderPanels;

public partial class CategoryPanel
{
    [Inject] private ICategoryService CategoryService { get; set; } = null!;

    private List<CategoryDto> Categories { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        Categories = await CategoryService.GetCategories();
    }
}