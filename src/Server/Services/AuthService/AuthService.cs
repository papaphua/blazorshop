using AutoMapper;
using BlazorShop.Server.Auth.PasswordProvider;
using BlazorShop.Server.Data.Entities;
using BlazorShop.Server.Data.Repositories.UserRepository;
using BlazorShop.Server.Exceptions;
using BlazorShop.Server.Services.PaymentService;
using BlazorShop.Server.Services.RoleService;
using BlazorShop.Server.Services.TokenService;
using BlazorShop.Shared.Dtos;

namespace BlazorShop.Server.Services.AuthService;

public sealed class AuthService : IAuthService
{
    private readonly IPasswordProvider _passwordProvider;
    private readonly IUserRepository _userRepository;
    private readonly IRoleService _roleService;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;
    private readonly IPaymentService _paymentService;

    public AuthService(
        IUserRepository userRepository, 
        IRoleService roleService, 
        IPasswordProvider passwordProvider,
        IMapper mapper,
        ITokenService tokenService, 
        IPaymentService paymentService)
    {
        _userRepository = userRepository;
        _roleService = roleService;
        _passwordProvider = passwordProvider;
        _mapper = mapper;
        _tokenService = tokenService;
        _paymentService = paymentService;
    }

    public async Task RegisterAsync(RegisterDto registerDto)
    {
        var userByUsername = await _userRepository.GetByUsernameAsync(registerDto.Username);
        var userByEmail = await _userRepository.GetByEmailAsync(registerDto.Email);

        if (userByUsername is not null && userByEmail is not null)
            throw new AlreadyExistException(
                ExceptionMessages.UsernameAndEmailAlreadyExist(registerDto.Username, registerDto.Email));
        
        if(userByUsername is not null)
            throw new AlreadyExistException(
                ExceptionMessages.UsernameAlreadyExist(registerDto.Username));
        
        if(userByEmail is not null)
            throw new AlreadyExistException(
                ExceptionMessages.EmailAlreadyExist(registerDto.Email));

        if (!registerDto.Password.Equals(registerDto.ConfirmPassword))
            throw new BusinessException(ExceptionMessages.PasswordsNotMatch);

        var user = _mapper.Map<User>(registerDto);
        
        user.PasswordHash = _passwordProvider.GetPasswordHash(registerDto.Password);
        
        await _userRepository.CreateAndSaveAsync(user);
        
        if (await _userRepository.IsEmptyAsync())
            await _roleService.AddUserToRoleAsync(user, Role.Admin);
        else
            await _roleService.AddUserToRoleAsync(user, Role.Customer);

        await _paymentService.AddPaymentProfileAsync(user);

        await _userRepository.UpdateAndSaveAsync(user);
    }

    public Task<TokenDto> LoginAsync(LoginDto loginDto)
    {
        throw new BusinessException("next");
    }
}