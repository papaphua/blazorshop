using AutoMapper;
using BlazorShop.Server.Primitives;
using BlazorShop.Server.Services.UserService;
using BlazorShop.Shared.Dtos;
using BlazorShop.Shared.Pagination.Parameters;

namespace BlazorShop.Server.Facades.UserFacade;

public sealed class UserFacade : IUserFacade
{
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public UserFacade(IMapper mapper, IUserService userService)
    {
        _mapper = mapper;
        _userService = userService;
    }

    public async Task<PagedList<UserDto>> GetUsersByParametersAsync(BaseParameters parameters)
    {
        var users = await _userService.GetUsersByParametersAsync(parameters);

        var dtos = users
            .Select(user => _mapper.Map<UserDto>(user))
            .ToList();

        return PagedList<UserDto>
            .ToPagedList(dtos, parameters.PageNumber, parameters.PageSize);
    }

    public async Task<UserDto?> GetUserByIdAsync(Guid id)
    {
        var user = await _userService.GetUserByIdAsync(id);

        return _mapper.Map<UserDto>(user);
    }

    public async Task<UserDto?> GetUserByUsernameAsync(string username)
    {
        var user = await _userService.GetUserByUsernameAsync(username);

        return _mapper.Map<UserDto>(user);
    }
}