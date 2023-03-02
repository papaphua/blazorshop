using AutoMapper;
using BlazorShop.Server.Data.Repositories.UserRepository;
using BlazorShop.Server.Exceptions;
using BlazorShop.Server.Primitives;
using BlazorShop.Server.Services.PaymentService;
using BlazorShop.Shared.Dtos;
using BlazorShop.Shared.Pagination.Parameters;

namespace BlazorShop.Server.Services.UserService;

public sealed class UserService : IUserService 
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IPaymentService _paymentService;

    public UserService(IMapper mapper, IUserRepository userRepository, IPaymentService paymentService)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _paymentService = paymentService;
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

    public async Task DeleteUserAsync(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);

        if (user is null) throw new NotFoundException(ExceptionMessages.NotRegistered);

        await _paymentService.DeletePaymentProfileAsync(user.Id);
        
        await _userRepository.DeleteAndSaveAsync(user);
    }
}