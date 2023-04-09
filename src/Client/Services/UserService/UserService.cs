using System.Net.Http.Json;
using System.Text.Json;
using BlazorShop.Client.Models.Pagination;
using BlazorShop.Shared.Dtos;
using BlazorShop.Shared.Pagination;
using BlazorShop.Shared.Pagination.Parameters;
using Microsoft.AspNetCore.WebUtilities;

namespace BlazorShop.Client.Services.UserService;

public sealed class UserService : IUserService
{
    private const string PaginationHeader = "X-Pagination";

    private readonly HttpClient _http;
    private readonly JsonSerializerOptions _options;

    public UserService(HttpClient http)
    {
        _http = http;
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public async Task<PagingResponse<UserDto>> GetUsers(BaseParameters parameters)
    {
        var query = new Dictionary<string, string>
        {
            [nameof(parameters.PageNumber)] = parameters.PageNumber.ToString(),
            [nameof(parameters.Search)] = parameters.Search ?? string.Empty
        };

        var response = await _http.GetAsync(QueryHelpers.AddQueryString("api/users", query));

        var content = await response.Content.ReadFromJsonAsync<List<UserDto>>();

        var header = response.Headers.GetValues(PaginationHeader).First();

        var pagingResponse = new PagingResponse<UserDto>
        {
            Items = content,
            MetaData = JsonSerializer.Deserialize<MetaData>(header, _options)!
        };

        return pagingResponse;
    }

    public async Task<UserDto> GetUserById(Guid userId)
    {
        return await _http.GetFromJsonAsync<UserDto>($"api/users/id/{userId}");
    }

    public async Task<UserDto> GetUserByUsername(string username)
    {
        return await _http.GetFromJsonAsync<UserDto>($"api/users/username/{username}");
    }

    public async Task DeleteUser(Guid userId)
    {
        await _http.DeleteAsync($"api/users/{userId}");
    }
}