using BlazorShop.Server.Data.Entities;
using BlazorShop.Server.Data.Repositories.BaseRepository;
using BlazorShop.Server.Data.RepositoryExtensions;
using BlazorShop.Shared.Pagination.Parameters;
using Microsoft.EntityFrameworkCore;

namespace BlazorShop.Server.Data.Repositories.ProductRepository;

public sealed class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) 
        : base(context)
    {
    }
    
    public async Task<List<Product>> GetByParametersAsync(ProductParameters parameters)
    {
        return await Context.Set<Product>()
            .Include(product => product.Category)
            .WithCategory(parameters.Category)
            .SearchFor(parameters.Search)
            .OrderBy(product => product.Name)
            .ToListAsync();
    }

    public async Task<Product?> GetByUriAsync(string uri)
    {
        var formattedUri = uri.Trim().ToLower();

        return await Context.Set<Product>()
            .Include(product => product.Category)
            .FirstOrDefaultAsync(product => product.Uri.ToLower().Equals(formattedUri));
    }
}