using BlazorShop.Shared.Dtos;

namespace BlazorShop.Client.Services.CategoryService;

public interface ICategoryService
{
    Task<List<CategoryDto>> GetCategories();
}