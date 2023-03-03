using System.Net.Http.Json;
using BlazorShop.Shared.Dtos;

namespace BlazorShop.Client.Services.CategoryService;

public sealed class CategoryService : ICategoryService
{
    private readonly HttpClient _http;

    public CategoryService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<CategoryDto>> GetCategories()
    {
        return await _http.GetFromJsonAsync<List<CategoryDto>>("api/categories");
    }
}