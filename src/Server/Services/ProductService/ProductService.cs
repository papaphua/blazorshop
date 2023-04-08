using AutoMapper;
using BlazorShop.Server.Common;
using BlazorShop.Server.Common.Exceptions;
using BlazorShop.Server.Data.Entities;
using BlazorShop.Server.Data.Repositories.ProductRepository;
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
        var product = _mapper.Map<Product>(dto);

        await _productRepository.CreateAndSaveAsync(product);
    }

    public async Task UpdateProductAsync(ProductDto dto)
    {
        var product = await _productRepository.GetByUriAsync(dto.Uri);

        if (product is null) throw new NotFoundException(ExceptionMessages.ProductNotFound);

        _mapper.Map(dto, product);

        await _productRepository.SaveAsync();
    }

    public async Task DeleteProductAsync(string uri)
    {
        var product = await _productRepository.GetByUriAsync(uri);

        if (product is null) throw new NotFoundException(ExceptionMessages.ProductNotFound);

        await _productRepository.DeleteAndSaveAsync(product);
    }
}