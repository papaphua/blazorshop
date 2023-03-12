using BlazorShop.Server.Data.Entities;
using BlazorShop.Server.Data.Repositories.BaseRepository;
using BlazorShop.Server.Data.RepositoryExtensions;
using BlazorShop.Shared.Pagination.Parameters;
using Microsoft.EntityFrameworkCore;

namespace BlazorShop.Server.Data.Repositories.UserRepository;

public sealed class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) 
        : base(context)
    {
    }

    public async Task<List<User>> GetByParametersAsync(BaseParameters parameters)
    {
        return await Context.Set<User>()
            .SearchFor(parameters.Search)
            .OrderBy(user => user.Username)
            .ToListAsync();
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await Context.Set<User>()
            .FirstOrDefaultAsync(user => user.Id.Equals(id));
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        var formattedUsername = username.Trim().ToLower();

        return await Context.Set<User>()
            .FirstOrDefaultAsync(user => user.Username.ToLower().Equals(formattedUsername));
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        var formattedEmail = email.Trim().ToLower();

        return await Context.Set<User>()
            .FirstOrDefaultAsync(user => user.Email.ToLower().Equals(formattedEmail));
    }
}