using System.Net.Http.Json;
using System.Text.Json;
using BlazorShop.Client.Models.Pagination;
using BlazorShop.Shared.Dtos;
using BlazorShop.Shared.Pagination;
using BlazorShop.Shared.Pagination.Parameters;
using Microsoft.AspNetCore.WebUtilities;

namespace BlazorShop.Client.Services.CommentService;

public sealed class CommentService : ICommentService
{
    private const string PaginationHeader = "X-Pagination";

    private readonly HttpClient _http;
    private readonly JsonSerializerOptions _options;

    public CommentService(HttpClient http)
    {
        _http = http;
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public async Task<PagingResponse<CommentDto>> GetComments(CommentParameters parameters)
    {
        var query = new Dictionary<string, string>
        {
            [nameof(parameters.PageSize)] = parameters.PageSize.ToString(),
            [nameof(parameters.PageNumber)] = parameters.PageNumber.ToString(),
            [nameof(parameters.ProductId)] = parameters.ProductId.ToString()
        };

        var response = await _http.GetAsync(QueryHelpers.AddQueryString("api/comments", query));

        var content = await response.Content.ReadFromJsonAsync<List<CommentDto>>();

        var header = response.Headers.GetValues(PaginationHeader).First();

        var pagingResponse = new PagingResponse<CommentDto>
        {
            Items = content,
            MetaData = JsonSerializer.Deserialize<MetaData>(header, _options)!
        };

        return pagingResponse;
    }

    public async Task AddComment(NewCommentDto newCommentDto)
    {
        await _http.PostAsJsonAsync("api/comments", newCommentDto);
    }

    public async Task UpdateComment(CommentDto commentDto)
    {
        await _http.PutAsJsonAsync("api/comments", commentDto);
    }

    public async Task DeleteComment(Guid commentId)
    {
        await _http.DeleteAsync($"api/comments/{commentId}");
    }
}