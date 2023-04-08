using AutoMapper;
using BlazorShop.Server.Services.CategoryService;
using BlazorShop.Shared.Dtos;

namespace BlazorShop.Server.Facades.CategoryFacade;

public sealed class CategoryFacade : ICategoryFacade
{
    private readonly IMapper _mapper;
    private readonly ICategoryService _categoryService;

    public CategoryFacade(IMapper mapper, ICategoryService categoryService)
    {
        _mapper = mapper;
        _categoryService = categoryService;
    }

    public async Task<List<CategoryDto>> GetAllCategoriesAsync()
    {
        var categories = await _categoryService.GetAllCategoriesAsync();
        
        return categories
            .Select(category => _mapper.Map<CategoryDto>(category))
            .ToList();
    }
}