using BlazorShop.Server.Data;
using BlazorShop.Server.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorShop.Server.Services.CommentService;

public sealed class CommentService : ICommentService
{
    private readonly AppDbContext _db;

    public CommentService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<Comment>> GetProductCommentsAsync(Guid productId)
    {
        return await _db.Products
            .Where(product => product.Id.Equals(productId))
            .Include(product => product.Comments)
            .ThenInclude(comment => comment.User)
            .Select(product => product.Comments)
            .SelectMany(collection => collection)
            .Select(comment => comment)
            .ToListAsync();
    }

    public async Task<Comment?> GetCommentByIdAsync(Guid id)
    {
        return await _db.Comments
            .FirstOrDefaultAsync(comment => comment.Id.Equals(id));
    }
}