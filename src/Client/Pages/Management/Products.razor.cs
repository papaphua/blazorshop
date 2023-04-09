﻿using Blazorise;
using BlazorShop.Client.Auth.PermissionHandler;
using BlazorShop.Client.Services.CategoryService;
using BlazorShop.Client.Services.HttpInterceptorService;
using BlazorShop.Client.Services.ProductService;
using BlazorShop.Shared.Dtos;
using BlazorShop.Shared.Pagination;
using BlazorShop.Shared.Pagination.Parameters;
using Microsoft.AspNetCore.Components;

namespace BlazorShop.Client.Pages.Management;

[HasPermission(Permissions.AdminPermission)]
public sealed partial class Products : IDisposable
{
    private readonly ProductParameters _productParameters = new() { PageSize = 6 };
    private Validations _validations = new();
    [Inject] private IProductService ProductService { get; set; } = null!;
    [Inject] private ICategoryService CategoryService { get; set; } = null!;
    [Inject] private HttpInterceptorService HttpInterceptorService { get; set; } = null!;
    private List<ProductDto> Items { get; set; } = new();
    private MetaData MetaData { get; set; } = new();
    private List<CategoryDto> Categories { get; set; } = new();

    public void Dispose()
    {
        HttpInterceptorService.DisposeEvent();
    }

    protected override void OnInitialized()
    {
        HttpInterceptorService.RegisterEvent();
    }

    protected override async Task OnInitializedAsync()
    {
        HttpInterceptorService.RegisterEvent();
        Categories = await CategoryService.GetCategories();
        _productParameters.PageNumber = 1;
        await GetProducts();
    }

    private async Task UpdateAction(ProductDto product)
    {
        if (await _validations.ValidateAll()) await ProductService.UpdateProduct(product);
    }

    private async Task DeleteAction(ProductDto product)
    {
        Items.Remove(product);
        await ProductService.DeleteProduct(product.Slug);
    }

    private async Task GetProducts()
    {
        var pagingResponse = await ProductService.GetProducts(_productParameters);

        Items = pagingResponse.Items;
        MetaData = pagingResponse.MetaData;
    }

    private async Task SelectPageAction(int page)
    {
        _productParameters.PageNumber = page;
        await GetProducts();
    }
}