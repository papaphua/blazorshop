using BlazorShop.Server.Data.Entities;
using BlazorShop.Server.Data.Repositories.BaseRepository;

namespace BlazorShop.Server.Data.Repositories.CategoryRepository;

public interface ICategoryRepository : IBaseRepository<Category>
{
    Task<List<Category>> GetAllAsync();
}