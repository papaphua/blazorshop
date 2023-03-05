using BlazorShop.Server.Auth.PermissionHandler;
using BlazorShop.Server.Services.ProductService;
using BlazorShop.Shared.Dtos;
using BlazorShop.Shared.Pagination.Parameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BlazorShop.Server.Controllers;

[Route("api/products")]
[ApiController]
public sealed class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    
    [AllowAnonymous]
    [HttpGet]
    public async Task<List<ProductDto>> GetProductsByParameters([FromQuery] ProductParameters parameters)
    {
        var pagedList = await _productService.GetProductsByParametersAsync(parameters);

        Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pagedList.MetaData));

        return pagedList;
    }
    
    [AllowAnonymous]
    [HttpGet("{uri}")]
    public async Task<ProductDto?> GetProductByUri(string uri)
    {
        return await _productService.GetProductByUriAsync(uri);
    }
    
    [HasPermission(Permissions.AdminPermission)]
    [HttpPost]
    public async Task CreateProduct(ProductDto dto)
    {
        await _productService.CreateProductAsync(dto);
    }
    
    [HasPermission(Permissions.AdminPermission)]
    [HttpPut]
    public async Task UpdateProduct(ProductDto dto)
    {
        await _productService.UpdateProductAsync(dto);
    }
    
    [HasPermission(Permissions.AdminPermission)]
    [HttpDelete("{uri}")]
    public async Task DeleteProduct(string uri)
    {
        await _productService.DeleteProductAsync(uri);
    }
}