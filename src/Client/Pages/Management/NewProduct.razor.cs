using BlazorShop.Client.Auth.PermissionHandler;
using BlazorShop.Client.Services.CategoryService;
using BlazorShop.Client.Services.HttpInterceptorService;
using BlazorShop.Client.Services.ProductService;
using BlazorShop.Shared.Dtos;
using Microsoft.AspNetCore.Components;

namespace BlazorShop.Client.Pages.Management;

[HasPermission(Permissions.AdminPermission)]
public sealed partial class NewProduct : IDisposable
{
    [Inject] private IProductService ProductService { get; set; } = null!;
    [Inject] private ICategoryService CategoryService { get; set; } = null!;
    [Inject] private HttpInterceptorService HttpInterceptorService { get; set; } = null!;

    private ProductDto Product { get; set; } = new();
    private List<CategoryDto> Categories { get; set; } = new();
    private Guid SelectedCategory { get; set; }
    
    protected override async Task OnInitializedAsync()
    {
        HttpInterceptorService.RegisterEvent();
        Categories = await CategoryService.GetCategories();
        Product.CategoryId = SelectedCategory;
    }

    private async Task CreateAction()
    {
        Product.CategoryId = SelectedCategory;
        await ProductService.CreateProduct(Product);
    }
    
    public void Dispose()
    {
        HttpInterceptorService.DisposeEvent();
    }
}