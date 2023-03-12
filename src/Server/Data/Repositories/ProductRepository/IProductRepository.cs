using BlazorShop.Server.Data.Entities;
using BlazorShop.Server.Data.Repositories.BaseRepository;
using BlazorShop.Shared.Pagination.Parameters;

namespace BlazorShop.Server.Data.Repositories.ProductRepository;

public interface IProductRepository : IBaseRepository<Product>
{
    Task<List<Product>> GetByParametersAsync(ProductParameters parameters);
    Task<Product?> GetByUriAsync(string uri);
}