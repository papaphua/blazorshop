using System.Net.Http.Json;
using System.Security.Claims;
using Blazored.LocalStorage;
using BlazorShop.Client.Auth;
using BlazorShop.Client.Auth.StateProvider;
using BlazorShop.Client.Services.UserService;
using BlazorShop.Shared.Dtos;
using BlazorShop.Shared.Models;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorShop.Client.Services.ProfileService;

public sealed class ProfileService : IProfileService
{
    private readonly HttpClient _http;
    private readonly ILocalStorageService _localStorage;
    private readonly AuthenticationStateProvider _authStateProvider;
    private readonly IUserService _userService;

    public ProfileService(HttpClient http, ILocalStorageService localStorage,
        AuthenticationStateProvider authStateProvider, IUserService userService)
    {
        _http = http;
        _localStorage = localStorage;
        _authStateProvider = authStateProvider;
        _userService = userService;
    }

    public async Task<UserDto?> GetAuthUser()
    {
        var state = await _authStateProvider.GetAuthenticationStateAsync();

        var idClaim = state.User.Claims.SingleOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier);

        if (idClaim is null) return null;

        var user = await _userService.GetUserById(Guid.Parse(idClaim.Value));

        return user;
    }

    public async Task<ProfileDto> GetUserProfile()
    {
        return await _http.GetFromJsonAsync<ProfileDto>("api/profile");
    }

    public async Task UpdateUserProfile(ProfileDto newProfileDto)
    {
        var response = await _http.PutAsJsonAsync("api/profile", newProfileDto);

        var tokenDto = await response.Content.ReadFromJsonAsync<TokenDto>();

        await _localStorage.SetItemAsync(AuthNamings.AccessToken, tokenDto.AccessToken);
        await _localStorage.SetItemAsync(AuthNamings.RefreshToken, tokenDto.RefreshToken);

        (_authStateProvider as CustomAuthStateProvider).NotifyUserAuth(tokenDto.AccessToken);
    }

    public async Task ChangeEmail(EmailChangeDto emailChangeDto)
    {
        var response = await _http.PatchAsJsonAsync("api/profile/email/change", emailChangeDto);

        if(!response.IsSuccessStatusCode) return;

        var tokenDto = await response.Content.ReadFromJsonAsync<TokenDto>();

        await _localStorage.SetItemAsync(AuthNamings.AccessToken, tokenDto.AccessToken);
        await _localStorage.SetItemAsync(AuthNamings.RefreshToken, tokenDto.RefreshToken);

        (_authStateProvider as CustomAuthStateProvider).NotifyUserAuth(tokenDto.AccessToken);
    }

    public async Task ChangePassword(PasswordChangeDto passwordChangeDto)
    {
        await _http.PatchAsJsonAsync("api/profile/password/change", passwordChangeDto);
    }

    public async Task CreateDeleteProfileLink()
    {
        await _http.GetAsync("api/profile/delete/request");
    }

    public async Task DeleteProfile(ConfirmationParameters parameters)
    {
        await _http.PostAsJsonAsync("api/profile/delete/confirmation", parameters);
    }
}