using BlazorShop.Server.Data.Entities;
using BlazorShop.Shared.Pagination.Parameters;

namespace BlazorShop.Server.Services.ProductService;

public interface IProductService
{
    Task<List<Product>> GetProductsByParametersAsync(ProductParameters parameters);
    Task<Product?> GetProductByIdAsync(Guid id);
    Task<Product?> GetProductBySlugAsync(string slug);
}