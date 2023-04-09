using BlazorShop.Server.Primitives;
using BlazorShop.Shared.Dtos;
using BlazorShop.Shared.Pagination.Parameters;

namespace BlazorShop.Server.Facades.CommentFacade;

public interface ICommentFacade
{
    Task<PagedList<CommentDto>> GetCommentsForProductByParametersAsync(CommentParameters parameters);
    Task AddCommentAsync(Guid userId, NewCommentDto newCommentDto);
    Task UpdateCommentAsync(Guid userId, CommentDto commentDto);
    Task DeleteCommentAsync(Guid userId, Guid commentId);
}