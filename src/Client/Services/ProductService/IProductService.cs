using BlazorShop.Client.Models.Pagination;
using BlazorShop.Shared.Dtos;
using BlazorShop.Shared.Pagination.Parameters;

namespace BlazorShop.Client.Services.ProductService;

public interface IProductService
{
    Task<PagingResponse<ProductDto>> GetProducts(ProductParameters parameters);
    Task<ProductDto> GetProductByUri(string uri);
    Task UpdateProduct(ProductDto dto);
    Task CreateProduct(ProductDto dto);
    Task DeleteProduct(string uri);
}