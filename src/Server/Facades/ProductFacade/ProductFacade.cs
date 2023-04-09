using AutoMapper;
using BlazorShop.Server.Common;
using BlazorShop.Server.Common.Exceptions;
using BlazorShop.Server.Data;
using BlazorShop.Server.Data.Entities;
using BlazorShop.Server.Primitives;
using BlazorShop.Server.Services.ProductService;
using BlazorShop.Shared.Dtos;
using BlazorShop.Shared.Pagination.Parameters;

namespace BlazorShop.Server.Facades.ProductFacade;

public sealed class ProductFacade : IProductFacade
{
    private readonly AppDbContext _db;
    private readonly IMapper _mapper;
    private readonly IProductService _productService;

    public ProductFacade(IMapper mapper, IProductService productService, AppDbContext db)
    {
        _mapper = mapper;
        _productService = productService;
        _db = db;
    }

    public async Task<PagedList<ProductDto>> GetProductsByParametersAsync(ProductParameters parameters)
    {
        var products = await _productService.GetProductsByParametersAsync(parameters);

        var dtos = products
            .Select(product => _mapper.Map<ProductDto>(product))
            .ToList();

        return PagedList<ProductDto>
            .ToPagedList(dtos, parameters.PageNumber, parameters.PageSize);
    }

    public async Task<ProductDto?> GetProductBySlugAsync(string uri)
    {
        var product = await _productService.GetProductBySlugAsync(uri);

        return _mapper.Map<ProductDto>(product);
    }

    public async Task CreateProductAsync(ProductDto dto)
    {
        var product = _mapper.Map<Product>(dto);

        await _db.Products.AddAsync(product);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateProductAsync(ProductDto dto)
    {
        var product = await _productService.GetProductBySlugAsync(dto.Slug);

        if (product is null) throw new NotFoundException(ExceptionMessages.ProductNotFound);

        _mapper.Map(dto, product);

        await _db.SaveChangesAsync();
    }

    public async Task DeleteProductAsync(string slug)
    {
        var product = await _productService.GetProductBySlugAsync(slug);

        if (product is null) throw new NotFoundException(ExceptionMessages.ProductNotFound);

        _db.Products.Remove(product);
        await _db.SaveChangesAsync();
    }
}