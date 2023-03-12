using BlazorShop.Server.Data.Entities;
using BlazorShop.Server.Data.Entities.JointEntities;
using BlazorShop.Server.Data.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace BlazorShop.Server.Data.Repositories.CommentRepository;

public sealed class CommentRepository : BaseRepository<Comment>, ICommentRepository
{
    public CommentRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Comment?> GetByIdAsync(Guid id)
    {
        return await Context.Set<Comment>()
            .FirstOrDefaultAsync(comment => comment.Id == id);
    }

    public async Task<List<Comment>> GetCommentsForProductByIdAsync(Guid productId)
    {
        var comments = await Context.Set<Product>()
            .Where(product => product.Id == productId)
            .Include(product => product.Comments)
            .ThenInclude(comment => comment.User)
            .Select(product => product.Comments)
            .ToListAsync();

        return comments
            .SelectMany(commentList => commentList)
            .Select(comment => comment)
            .ToList();
    }

    public async Task LinkProductCommentsAsync(Guid productId, Guid commentId)
    {
        var linkedEntity = new ProductComment(productId, commentId); 
        
        await Context.Set<ProductComment>().AddAsync(linkedEntity);
        
        await Context.SaveChangesAsync();
    }
}