﻿using BlazorShop.Shared.Dtos;
using BlazorShop.Shared.Models;

namespace BlazorShop.Client.Services.AuthService;

public interface IAuthService
{
    Task Register(RegisterDto registerDto);
    Task FindLoginInfo(LoginDto loginDto);
    Task DefaultLogin(DefaultLoginDto defaultLoginDto);
    Task TwoAuthLogin(TwoAuthLoginDto twoAuthLoginDto);
    Task Logout();
    Task TryRefreshToken();
    Task GetConfirmationCode();
    Task GetNewEmailConfirmationCode(EmailDto emailDto);
    Task GetEmailConfirmationLink();
    Task GetPasswordResetLink(EmailDto emailDto);
    Task<ResponseDto> ConfirmEmail(ConfirmationParameters parameters);
    Task ResetPassword(PasswordResetDto passwordResetDto);
}