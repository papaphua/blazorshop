using BlazorShop.Server.Primitives;
using BlazorShop.Shared.Dtos;
using BlazorShop.Shared.Pagination.Parameters;

namespace BlazorShop.Server.Services.ProductService;

public interface IProductService
{
    Task<PagedList<ProductDto>> GetProductsByParametersAsync(ProductParameters parameters);
    Task<ProductDto?> GetProductByUriAsync(string uri);
    Task CreateProductAsync(ProductDto dto);
    Task UpdateProductAsync(ProductDto dto);
    Task DeleteProductAsync(Guid id);
}