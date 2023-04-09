using BlazorShop.Server.Primitives;
using BlazorShop.Shared.Dtos;
using BlazorShop.Shared.Pagination.Parameters;

namespace BlazorShop.Server.Facades.ProductFacade;

public interface IProductFacade
{
    Task<PagedList<ProductDto>> GetProductsByParametersAsync(ProductParameters parameters);
    Task<ProductDto?> GetProductBySlugAsync(string slug);
    Task CreateProductAsync(ProductDto dto);
    Task UpdateProductAsync(ProductDto dto);
    Task DeleteProductAsync(string slug);
}