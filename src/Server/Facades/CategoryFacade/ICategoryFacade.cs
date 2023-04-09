using BlazorShop.Shared.Dtos;

namespace BlazorShop.Server.Facades.CategoryFacade;

public interface ICategoryFacade
{
    Task<List<CategoryDto>> GetAllCategoriesAsync();
}