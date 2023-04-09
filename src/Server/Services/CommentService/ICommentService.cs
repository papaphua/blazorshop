using BlazorShop.Server.Data.Entities;

namespace BlazorShop.Server.Services.CommentService;

public interface ICommentService
{
    Task<List<Comment>> GetProductCommentsAsync(Guid productId);
    Task<Comment?> GetCommentByIdAsync(Guid id);
}