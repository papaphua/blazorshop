namespace BlazorShop.Server.Data.Repositories.BaseRepository;

public interface IBaseRepository<T> where T : class
{
    Task CreateAsync(T entity);
    Task UpdateAndSaveAsync(T entity);
    Task DeleteAndSaveAsync(T entity);
    Task<bool> IsEmptyAsync();
}