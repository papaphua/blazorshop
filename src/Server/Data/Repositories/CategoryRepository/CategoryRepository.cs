using BlazorShop.Server.Data.Entities;
using BlazorShop.Server.Data.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace BlazorShop.Server.Data.Repositories.CategoryRepository;

public sealed class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) 
        : base(context)
    {
    }

    public async Task<List<Category>> GetAllAsync()
    {
        return await Context.Set<Category>().ToListAsync();
    }
}