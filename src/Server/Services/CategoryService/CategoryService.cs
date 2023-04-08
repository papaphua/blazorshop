using BlazorShop.Server.Data;
using BlazorShop.Server.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorShop.Server.Services.CategoryService;

public sealed class CategoryService : ICategoryService
{
    private readonly AppDbContext _db;

    public CategoryService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<Category>> GetAllCategoriesAsync()
    {
        return await _db.Categories.ToListAsync();
    }
}