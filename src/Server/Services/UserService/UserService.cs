using AutoMapper;
using BlazorShop.Server.Data.Repositories.UserRepository;
using BlazorShop.Server.Primitives;
using BlazorShop.Shared.Dtos;
using BlazorShop.Shared.Pagination.Parameters;

namespace BlazorShop.Server.Services.UserService;

public sealed class UserService : IUserService 
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UserService(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<PagedList<UserDto>> GetUsersByParametersAsync(BaseParameters parameters)
    {
        var users = await _userRepository.GetByParametersAsync(parameters);

        var dtos = users
            .Select(user => _mapper.Map<UserDto>(user))
            .ToList();
        
        return PagedList<UserDto>
            .ToPagedList(dtos, parameters.PageNumber, parameters.PageSize);
    }

    public async Task<UserDto?> GetUserByIdAsync(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);

        return _mapper.Map<UserDto>(user);
    }

    public async Task<UserDto?> GetUserByUsernameAsync(string username)
    {
        var user = await _userRepository.GetByUsernameAsync(username);

        return _mapper.Map<UserDto>(user);
    }
}