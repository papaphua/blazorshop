using BlazorShop.Server.Primitives;
using BlazorShop.Shared.Dtos;
using BlazorShop.Shared.Pagination.Parameters;

namespace BlazorShop.Server.Facades.UserFacade;

public interface IUserFacade
{
    Task<PagedList<UserDto>> GetUsersByParametersAsync(BaseParameters parameters);
    Task<UserDto?> GetUserByIdAsync(Guid id);
    Task<UserDto?> GetUserByUsernameAsync(string username);
}