using AutoMapper;
using BlazorShop.Server.Data.Repositories.CategoryRepository;
using BlazorShop.Shared.Dtos;

namespace BlazorShop.Server.Services.CategoryService;

public sealed class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<List<CategoryDto>> GetAllCategoriesAsync()
    {
        var categories = await _categoryRepository.GetAllAsync();
        
        return categories
            .Select(category => _mapper.Map<CategoryDto>(category))
            .ToList();
    }
}