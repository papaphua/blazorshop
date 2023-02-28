using BlazorShop.Shared.Dtos;

namespace BlazorShop.Server.Services.CategoryService;

public interface ICategoryService
{
    Task<List<CategoryDto>> GetAllCategoriesAsync();
}