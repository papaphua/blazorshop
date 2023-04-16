using BlazorShop.Server.Common;
using BlazorShop.Server.Common.Exceptions;
using BlazorShop.Server.Common.Extensions;
using BlazorShop.Server.Data;
using BlazorShop.Server.Data.Entities;
using BlazorShop.Shared.Pagination.Parameters;
using Microsoft.EntityFrameworkCore;

namespace BlazorShop.Server.Services.UserService;

public sealed class UserService : IUserService
{
    private readonly AppDbContext _db;

    public UserService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<User>> GetUsersByParametersAsync(BaseParameters parameters)
    {
        return await _db.Users
            .SearchFor(parameters.Search)
            .OrderBy(user => user.Username)
            .ToListAsync();
    }

    public async Task<User?> GetUserByIdAsync(Guid id)
    {
        return await _db.Users
            .FirstOrDefaultAsync(user => user.Id.Equals(id));
    }

    public async Task<User?> GetUserByUsernameAsync(string username)
    {
        return await _db.Users
            .FirstOrDefaultAsync(user => user.Username.Equals(username));
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _db.Users
            .FirstOrDefaultAsync(user => user.Email.Equals(email));
    }

    public async Task DeleteUserAsync(Guid id)
    {
        
        var user = await GetUserByIdAsync(id);

        if (user is null) throw new NotFoundException(ExceptionMessages.NotRegistered);

        _db.Users.Remove(user);
        
        await _db.SaveChangesAsync();
    }

    public async Task UpdateUserAsync(User user)
    {
        _db.Users.Update(user);
        await _db.SaveChangesAsync();
    }
}