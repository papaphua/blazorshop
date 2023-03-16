using Microsoft.EntityFrameworkCore;

namespace BlazorShop.Server.Data.Repositories.BaseRepository;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected BaseRepository(AppDbContext context)
    {
        Context = context;
    }
    
    protected AppDbContext Context { get; set; }
    
    public async Task SaveAsync()
    {
        await Context.SaveChangesAsync();
    }

    public async Task CreateAndSaveAsync(T entity)
    {
        await Context.Set<T>().AddAsync(entity);
        await Context.SaveChangesAsync();
    }

    public async Task UpdateAndSaveAsync(T entity)
    {
        Context.Set<T>().Update(entity);
        await Context.SaveChangesAsync();
    }

    public async Task DeleteAndSaveAsync(T entity)
    {
        Context.Set<T>().Remove(entity);
        await Context.SaveChangesAsync();
    }

    public async Task<bool> IsEmptyAsync()
    {
        return !await Context.Set<T>().AnyAsync();
    }
}