using BlazorShop.Server.Data.Entities;
using BlazorShop.Server.Data.Repositories.BaseRepository;

namespace BlazorShop.Server.Data.Repositories.CommentRepository;

public interface ICommentRepository : IBaseRepository<Comment>
{
    Task<Comment?> GetByIdAsync(Guid id);
    Task<List<Comment>> GetCommentsForProductByIdAsync(Guid productId);
    Task LinkProductCommentsAsync(Guid productId, Guid commentId);
}