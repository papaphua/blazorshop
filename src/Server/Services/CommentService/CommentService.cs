using AutoMapper;
using BlazorShop.Server.Data.Entities;
using BlazorShop.Server.Data.Repositories.CommentRepository;
using BlazorShop.Server.Exceptions;
using BlazorShop.Server.Primitives;
using BlazorShop.Shared.Dtos;
using BlazorShop.Shared.Pagination.Parameters;

namespace BlazorShop.Server.Services.CommentService;

public sealed class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;

    public CommentService(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }

    public async Task<PagedList<CommentDto>> GetCommentsForProductByParametersAsync(CommentParameters parameters)
    {
        var comments = await _commentRepository.GetCommentsForProductByIdAsync(parameters.ProductId);

        var dtos = comments
            .Select(comment => _mapper.Map<CommentDto>(comment))
            .ToList();

        return PagedList<CommentDto>
            .ToPagedList(dtos, parameters.PageNumber, parameters.PageSize);
    }

    public async Task AddCommentAsync(Guid userId, NewCommentDto newCommentDto)
    {
        var comment = new Comment(newCommentDto.Text, userId);

        await _commentRepository.CreateAndSaveAsync(comment);

        await _commentRepository.LinkProductCommentsAsync(newCommentDto.ProductId, comment.Id);
    }


    public async Task UpdateCommentAsync(Guid userId, CommentDto commentDto)
    {
        var comment = await _commentRepository.GetByIdAsync(commentDto.Id);
        
        if (comment is null) throw new NotFoundException(ExceptionMessages.CommentNotFound);

        if (comment.UserId != userId) throw new BusinessException(ExceptionMessages.Unauthorized);
        
        comment.Text = commentDto.Text;
        
        await _commentRepository.SaveAsync();
    }

    public async Task DeleteCommentAsync(Guid userId, Guid commentId)
    {
        var comment = await _commentRepository.GetByIdAsync(commentId);
        
        if (comment is null) throw new NotFoundException(ExceptionMessages.CommentNotFound);

        if (comment.UserId != userId) throw new BusinessException(ExceptionMessages.Unauthorized);

        await _commentRepository.DeleteAndSaveAsync(comment);
    }
}