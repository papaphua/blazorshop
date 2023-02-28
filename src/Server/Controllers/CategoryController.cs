using BlazorShop.Server.Services.CategoryService;
using BlazorShop.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorShop.Server.Controllers;

[Route("api/categories")]
[ApiController]
public sealed class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [AllowAnonymous]
    [HttpGet]
    public Task<List<CategoryDto>> GetCategories()
    {
        return _categoryService.GetAllCategoriesAsync();
    }
}