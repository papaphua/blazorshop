using AutoMapper;
using BlazorShop.Server.Data.Repositories.CategoryRepository;
using BlazorShop.Shared.Dtos;

namespace BlazorShop.Server.Services.CategoryService;

public sealed class CategoryService : ICategoryService
{
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(IMapper mapper, ICategoryRepository categoryRepository)
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }

    public async Task<List<CategoryDto>> GetAllCategoriesAsync()
    {
        var categories = await _categoryRepository.GetAllAsync();
        
        return categories
            .Select(category => _mapper.Map<CategoryDto>(category))
            .ToList();
    }
}