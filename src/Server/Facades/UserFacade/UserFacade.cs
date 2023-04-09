using AutoMapper;
using BlazorShop.Server.Common;
using BlazorShop.Server.Common.Exceptions;
using BlazorShop.Server.Data;
using BlazorShop.Server.Primitives;
using BlazorShop.Server.Services.PaymentService;
using BlazorShop.Server.Services.UserService;
using BlazorShop.Shared.Dtos;
using BlazorShop.Shared.Pagination.Parameters;

namespace BlazorShop.Server.Facades.UserFacade;

public sealed class UserFacade : IUserFacade
{
    private readonly AppDbContext _db;
    private readonly IMapper _mapper;
    private readonly IPaymentService _paymentService;
    private readonly IUserService _userService;

    public UserFacade(IMapper mapper, IUserService userService, IPaymentService paymentService, AppDbContext db)
    {
        _mapper = mapper;
        _userService = userService;
        _paymentService = paymentService;
        _db = db;
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

    public async Task DeleteUserAsync(Guid id)
    {
        var user = await _userService.GetUserByIdAsync(id);

        if (user is null) throw new NotFoundException(ExceptionMessages.NotRegistered);

        await _paymentService.DeletePaymentProfileAsync(user.Id);

        await _db.SaveChangesAsync();
    }
}