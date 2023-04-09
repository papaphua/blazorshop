using AutoMapper;
using BlazorShop.Server.Common;
using BlazorShop.Server.Common.Exceptions;
using BlazorShop.Server.Data;
using BlazorShop.Server.Data.Entities;
using BlazorShop.Server.Primitives;
using BlazorShop.Server.Services.CommentService;
using BlazorShop.Server.Services.ProductService;
using BlazorShop.Shared.Dtos;
using BlazorShop.Shared.Pagination.Parameters;

namespace BlazorShop.Server.Facades.CommentFacade;

public sealed class CommentFacade : ICommentFacade
{
    private readonly ICommentService _commentService;
    private readonly AppDbContext _db;
    private readonly IMapper _mapper;
    private readonly IProductService _productService;

    public CommentFacade(ICommentService commentService, IMapper mapper, AppDbContext db,
        IProductService productService)
    {
        _commentService = commentService;
        _mapper = mapper;
        _db = db;
        _productService = productService;
    }

    public async Task<PagedList<CommentDto>> GetCommentsForProductByParametersAsync(CommentParameters parameters)
    {
        var comments = await _commentService.GetProductCommentsAsync(parameters.ProductId);

        var dtos = comments
            .Select(comment => _mapper.Map<CommentDto>(comment))
            .ToList();

        return PagedList<CommentDto>
            .ToPagedList(dtos, parameters.PageNumber, parameters.PageSize);
    }

    public async Task AddCommentAsync(Guid userId, NewCommentDto newCommentDto)
    {
        var comment = new Comment { Text = newCommentDto.Text, UserId = userId };
        var product = await _productService.GetProductByIdAsync(newCommentDto.ProductId);

        if (product is null) throw new NotFoundException(ExceptionMessages.ProductNotFound);

        product.Comments.Add(comment);

        await _db.SaveChangesAsync();
    }


    public async Task UpdateCommentAsync(Guid userId, CommentDto commentDto)
    {
        var comment = await _commentService.GetCommentByIdAsync(commentDto.Id);

        if (comment is null) throw new NotFoundException(ExceptionMessages.CommentNotFound);

        if (comment.UserId != userId) throw new BusinessException(ExceptionMessages.Unauthorized);

        comment.Text = commentDto.Text;

        await _db.SaveChangesAsync();
    }

    public async Task DeleteCommentAsync(Guid userId, Guid commentId)
    {
        var comment = await _commentService.GetCommentByIdAsync(commentId);

        if (comment is null) throw new NotFoundException(ExceptionMessages.CommentNotFound);

        if (comment.UserId != userId) throw new BusinessException(ExceptionMessages.Unauthorized);

        _db.Comments.Remove(comment);
        await _db.SaveChangesAsync();
    }
}