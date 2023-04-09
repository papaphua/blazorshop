using System.Net.Http.Json;
using System.Text.Json;
using BlazorShop.Client.Models.Pagination;
using BlazorShop.Shared.Dtos;
using BlazorShop.Shared.Pagination;
using BlazorShop.Shared.Pagination.Parameters;
using Microsoft.AspNetCore.WebUtilities;

namespace BlazorShop.Client.Services.ProductService;

public sealed class ProductService : IProductService
{
    private const string PaginationHeader = "X-Pagination";

    private readonly HttpClient _http;
    private readonly JsonSerializerOptions _options;

    public ProductService(HttpClient http)
    {
        _http = http;
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public async Task<PagingResponse<ProductDto>> GetProducts(ProductParameters parameters)
    {
        var query = new Dictionary<string, string>
        {
            [nameof(parameters.PageSize)] = parameters.PageSize.ToString(),
            [nameof(parameters.PageNumber)] = parameters.PageNumber.ToString(),
            [nameof(parameters.Category)] = parameters.Category ?? string.Empty,
            [nameof(parameters.Search)] = parameters.Search ?? string.Empty
        };

        var response = await _http.GetAsync(QueryHelpers.AddQueryString("api/products", query));

        var content = await response.Content.ReadFromJsonAsync<List<ProductDto>>();

        var header = response.Headers.GetValues(PaginationHeader).First();

        var pagingResponse = new PagingResponse<ProductDto>
        {
            Items = content,
            MetaData = JsonSerializer.Deserialize<MetaData>(header, _options)!
        };

        return pagingResponse;
    }

    public async Task<ProductDto> GetProductByUri(string uri)
    {
        return await _http.GetFromJsonAsync<ProductDto>($"api/products/{uri}");
    }

    public async Task UpdateProduct(ProductDto dto)
    {
        await _http.PutAsJsonAsync("api/products", dto);
    }

    public async Task CreateProduct(ProductDto dto)
    {
        await _http.PostAsJsonAsync("api/products", dto);
    }

    public async Task DeleteProduct(string uri)
    {
        await _http.DeleteAsync($"api/products/{uri}");
    }
}