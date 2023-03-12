using BlazorShop.Client.Models.Pagination;
using BlazorShop.Shared.Dtos;
using BlazorShop.Shared.Pagination.Parameters;

namespace BlazorShop.Client.Services.UserService;

public interface IUserService
{
    Task<PagingResponse<UserDto>> GetUsers(BaseParameters parameters);
    Task<UserDto> GetUserById(Guid userId);
    Task<UserDto> GetUserByUsername(string username);
    Task DeleteUser(Guid userId);
}