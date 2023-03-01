using AutoMapper;
using BlazorShop.Server.Data.Entities;
using BlazorShop.Server.Data.Repositories.SessionRepository;
using BlazorShop.Server.Data.Repositories.UserRepository;
using BlazorShop.Server.Exceptions;
using BlazorShop.Server.Services.PaymentService;
using BlazorShop.Server.Services.TokenService;
using BlazorShop.Shared.Dtos;

namespace BlazorShop.Server.Services.ProfileService;

public sealed class ProfileService : IProfileService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IPaymentService _paymentService;
    private readonly ITokenService _tokenService;
    private readonly ISessionRepository _sessionRepository;

    public ProfileService(IMapper mapper, IUserRepository userRepository, IPaymentService paymentService,
        ITokenService tokenService, ISessionRepository sessionRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _paymentService = paymentService;
        _tokenService = tokenService;
        _sessionRepository = sessionRepository;
    }

    public async Task<ProfileDto> GetUserProfileAsync(Guid userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);

        return _mapper.Map<ProfileDto>(user);
    }

    public async Task<TokenDto> UpdateUserProfileAsync(User user, ProfileDto newProfileDto)
    {
        var userByUsername = await _userRepository.GetByUsernameAsync(newProfileDto.Username);

        if (userByUsername is not null && userByUsername.Id != user.Id)
            throw new AlreadyExistException(ExceptionMessages.UsernameAlreadyExist(newProfileDto.Username));

        var updatedUser = _mapper.Map(newProfileDto, user);

        await _userRepository.UpdateAndSaveAsync(updatedUser);

        await _paymentService.UpdatePaymentProfileAsync(updatedUser.Id);

        var accessToken = await _tokenService.GenerateAccessTokenAsync(updatedUser);
        var refreshToken = _tokenService.GenerateRefreshToken();
        
        await _sessionRepository.UpdateSessionAsync(user.Id, accessToken, refreshToken);

        return new TokenDto(accessToken, refreshToken);
    }

    public async Task<TokenDto> ChangeEmailAsync(User user, EmailChangeDto emailChangeDto)
    {
        throw new BusinessException("s");
    }

    public async Task ChangePasswordAsync(User user, PasswordChangeDto passwordChangeDto)
    {
        throw new BusinessException("s");
    }
}