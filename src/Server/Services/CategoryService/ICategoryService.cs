using BlazorShop.Server.Data.Entities;

namespace BlazorShop.Server.Services.CategoryService;

public interface ICategoryService
{
    Task<List<Category>> GetAllCategoriesAsync();
}