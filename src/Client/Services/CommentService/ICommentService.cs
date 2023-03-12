using BlazorShop.Client.Models.Pagination;
using BlazorShop.Shared.Dtos;
using BlazorShop.Shared.Pagination.Parameters;

namespace BlazorShop.Client.Services.CommentService;

public interface ICommentService
{
    Task<PagingResponse<CommentDto>> GetComments(CommentParameters parameters);
    Task AddComment(NewCommentDto newCommentDto);
    Task UpdateComment(CommentDto commentDto);
    Task DeleteComment(Guid commentId);
}