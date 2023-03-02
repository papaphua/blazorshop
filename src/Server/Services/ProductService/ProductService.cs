using AutoMapper;
using BlazorShop.Server.Data.Repositories.ProductRepository;
using BlazorShop.Server.Exceptions;
using BlazorShop.Server.Primitives;
using BlazorShop.Shared.Dtos;
using BlazorShop.Shared.Pagination.Parameters;

namespace BlazorShop.Server.Services.ProductService;

public sealed class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public ProductService(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<PagedList<ProductDto>> GetProductsByParametersAsync(ProductParameters parameters)
    {
        var products = await _productRepository.GetByParametersAsync(parameters);
        
        var dtos = products
            .Select(product => _mapper.Map<ProductDto>(product))
            .ToList();
        
        return PagedList<ProductDto>
            .ToPagedList(dtos, parameters.PageNumber, parameters.PageSize);
    }

    public async Task<ProductDto?> GetProductByUriAsync(string uri)
    {
        var product = await _productRepository.GetByUriAsync(uri);
        
        return _mapper.Map<ProductDto>(product);
    }

    public async Task CreateProductAsync(ProductDto dto)
    {
        throw new BusinessException("s");
    }

    public async Task UpdateProductAsync(ProductDto dto)
    {
        throw new BusinessException("s");
    }

    public async Task DeleteProductAsync(Guid id)
    {
        throw new BusinessException("s");
    }
}