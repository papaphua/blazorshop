using System.Net.Http.Json;
using Blazored.LocalStorage;
using BlazorShop.Client.Auth;
using BlazorShop.Client.Auth.StateProvider;
using BlazorShop.Shared.Dtos;
using BlazorShop.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorShop.Client.Services.AuthService;

public sealed class AuthService : IAuthService
{
    private readonly AuthenticationStateProvider _authStateProvider;
    private readonly HttpClient _http;
    private readonly ILocalStorageService _localStorage;
    private readonly NavigationManager _navigation;

    public AuthService(HttpClient http, NavigationManager navigation, ILocalStorageService localStorage,
        AuthenticationStateProvider authStateProvider)
    {
        _http = http;
        _navigation = navigation;
        _localStorage = localStorage;
        _authStateProvider = authStateProvider;
    }

    public async Task Register(RegisterDto registerDto)
    {
        await _http.PostAsJsonAsync("api/authentication/registration", registerDto);
    }

    public async Task FindLoginInfo(LoginDto loginDto)
    {
        var response = await _http.PostAsJsonAsync("api/authentication/login", loginDto);

        var link = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode) _navigation.NavigateTo(link);
    }

    public async Task DefaultLogin(DefaultLoginDto defaultLoginDto)
    {
        var response = await _http.PostAsJsonAsync("api/authentication/login/default", defaultLoginDto);

        if (!response.IsSuccessStatusCode) return;

        var content = await response.Content.ReadFromJsonAsync<AuthDto>();

        if (!content.IsSucceeded)
        {
            _navigation.NavigateTo(content.Url);
            return;
        }

        await _localStorage.SetItemAsync(AuthNamings.AccessToken, content.Tokens.AccessToken);
        await _localStorage.SetItemAsync(AuthNamings.RefreshToken, content.Tokens.RefreshToken);

        (_authStateProvider as CustomAuthStateProvider).NotifyUserAuth(content.Tokens.AccessToken);

        _navigation.NavigateTo("/");
    }

    public async Task TwoAuthLogin(TwoAuthLoginDto twoAuthLoginDto)
    {
        var response = await _http.PostAsJsonAsync("api/authentication/login/2fa", twoAuthLoginDto);

        if (!response.IsSuccessStatusCode) return;

        var content = await response.Content.ReadFromJsonAsync<AuthDto>();

        if (!content.IsSucceeded)
        {
            _navigation.NavigateTo(content.Url);
            return;
        }

        await _localStorage.SetItemAsync(AuthNamings.AccessToken, content.Tokens.AccessToken);
        await _localStorage.SetItemAsync(AuthNamings.RefreshToken, content.Tokens.RefreshToken);

        (_authStateProvider as CustomAuthStateProvider).NotifyUserAuth(content.Tokens.AccessToken);

        _navigation.NavigateTo("/");
    }

    public async Task Logout()
    {
        await _localStorage.RemoveItemAsync(AuthNamings.AccessToken);
        await _localStorage.RemoveItemAsync(AuthNamings.RefreshToken);

        (_authStateProvider as CustomAuthStateProvider).NotifyUserLogout();

        _navigation.NavigateTo("/");
    }

    public async Task TryRefreshToken()
    {
        var state = await _authStateProvider.GetAuthenticationStateAsync();
        var expClaim = state.User.FindFirst(c => c.Type.Equals("exp"));

        if (expClaim is null) return;

        var exp = expClaim.Value;

        var expTime = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(exp));
        var diff = expTime - DateTime.UtcNow;

        if (diff.TotalMinutes is > 0 and <= 3)
            await RefreshToken();
        else if (diff.TotalMinutes <= 0)
            await Logout();
    }

    public async Task GetConfirmationCode()
    {
        await _http.GetAsync("api/authentication/confirmation-code");
    }

    public async Task GetNewEmailConfirmationCode(EmailDto emailDto)
    {
        await _http.PostAsJsonAsync("api/authentication/new-email/confirmation-code", emailDto);
    }

    public async Task GetEmailConfirmationLink()
    {
        await _http.GetAsync("api/authentication/email/confirmation/request");
    }

    public async Task GetPasswordResetLink(EmailDto emailDto)
    {
        await _http.PostAsJsonAsync("api/authentication/password/reset/request", emailDto);
    }

    public async Task<ResponseDto> ConfirmEmail(ConfirmationParameters parameters)
    {
        var response = await _http.PostAsJsonAsync("api/authentication/email/confirmation", parameters);

        if (response is null) return new ResponseDto("Email not confirmed");

        return await response.Content.ReadFromJsonAsync<ResponseDto>();
    }

    public async Task ResetPassword(PasswordResetDto passwordResetDto)
    {
        await _http.PostAsJsonAsync("api/authentication/password/reset", passwordResetDto);
        _navigation.NavigateTo("accounts/login");
    }

    private async Task RefreshToken()
    {
        var accessToken = await _localStorage.GetItemAsync<string>(AuthNamings.AccessToken);
        var refreshToken = await _localStorage.GetItemAsync<string>(AuthNamings.RefreshToken);

        if (accessToken is null || refreshToken is null) await Logout();

        var tokenDto = new TokenDto(accessToken, refreshToken);

        var response = await _http.PostAsJsonAsync("api/authentication/refresh", tokenDto);

        var content = await response.Content.ReadFromJsonAsync<AuthDto>();

        if (content is null || !content.IsSucceeded)
        {
            await Logout();
            return;
        }

        await _localStorage.SetItemAsync(AuthNamings.AccessToken, content.Tokens.AccessToken);
        await _localStorage.SetItemAsync(AuthNamings.RefreshToken, content.Tokens.RefreshToken);

        (_authStateProvider as CustomAuthStateProvider).NotifyUserAuth(content.Tokens.AccessToken);
    }
}