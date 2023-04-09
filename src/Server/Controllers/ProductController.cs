using BlazorShop.Server.Auth.PermissionHandler;
using BlazorShop.Server.Common;
using BlazorShop.Server.Facades.ProductFacade;
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
    private readonly IProductFacade _productFacade;

    public ProductController(IProductFacade productFacade)
    {
        _productFacade = productFacade;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<List<ProductDto>> GetProductsByParameters([FromQuery] ProductParameters parameters)
    {
        var pagedList = await _productFacade.GetProductsByParametersAsync(parameters);

        Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pagedList.MetaData));

        return pagedList;
    }

    [AllowAnonymous]
    [HttpGet("{slug}")]
    public async Task<ProductDto?> GetProductByUri(string slug)
    {
        return await _productFacade.GetProductBySlugAsync(slug);
    }

    [HasPermission(Permissions.AdminPermission)]
    [HttpPost]
    public async Task CreateProduct(ProductDto dto)
    {
        await _productFacade.CreateProductAsync(dto);
    }

    [HasPermission(Permissions.AdminPermission)]
    [HttpPut]
    public async Task UpdateProduct(ProductDto dto)
    {
        await _productFacade.UpdateProductAsync(dto);
    }

    [HasPermission(Permissions.AdminPermission)]
    [HttpDelete("{uri}")]
    public async Task DeleteProduct(string uri)
    {
        await _productFacade.DeleteProductAsync(uri);
    }
}