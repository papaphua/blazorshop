using BlazorShop.Server.Auth.PermissionHandler;
using BlazorShop.Server.Common;
using BlazorShop.Server.Common.Providers.TokenProvider;
using BlazorShop.Server.Facades.CommentFacade;
using BlazorShop.Shared.Dtos;
using BlazorShop.Shared.Pagination.Parameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BlazorShop.Server.Controllers;

[Route("api/comments")]
[ApiController]
public sealed class CommentController : ControllerBase
{
    private readonly ICommentFacade _commentFacade;
    private readonly ITokenProvider _tokenProvider;

    public CommentController(ICommentFacade commentFacade, ITokenProvider tokenProvider)
    {
        _commentFacade = commentFacade;
        _tokenProvider = tokenProvider;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<List<CommentDto>> GetCommentsForProductByParameters([FromQuery] CommentParameters parameters)
    {
        var pagedList = await _commentFacade.GetCommentsForProductByParametersAsync(parameters);

        Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pagedList.MetaData));

        return pagedList;
    }

    [HasPermission(Permissions.CustomerPermission)]
    [HttpPost]
    public async Task AddComment(NewCommentDto newCommentDto)
    {
        var userId = _tokenProvider.GetUserIdFromContext(HttpContext);

        await _commentFacade.AddCommentAsync(userId, newCommentDto);
    }

    [HasPermission(Permissions.CustomerPermission)]
    [HttpPut]
    public async Task UpdateComment(CommentDto commentDto)
    {
        var userId = _tokenProvider.GetUserIdFromContext(HttpContext);

        await _commentFacade.UpdateCommentAsync(userId, commentDto);
    }

    [HasPermission(Permissions.CustomerPermission)]
    [HttpDelete("{commentId:guid}")]
    public async Task DeleteComment(Guid commentId)
    {
        var userId = _tokenProvider.GetUserIdFromContext(HttpContext);

        await _commentFacade.DeleteCommentAsync(userId, commentId);
    }
}