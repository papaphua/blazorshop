using System.Net.Http.Json;
using Blazored.LocalStorage;
using BlazorShop.Client.Auth;
using BlazorShop.Client.Auth.StateProvider;
using BlazorShop.Shared.Dtos;
using BlazorShop.Shared.Models;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorShop.Client.Services.ProfileService;

public sealed class ProfileService : IProfileService
{
    private readonly HttpClient _http;
    private readonly ILocalStorageService _localStorage;
    private readonly AuthenticationStateProvider _authStateProvider;

    public ProfileService(HttpClient http, ILocalStorageService localStorage, AuthenticationStateProvider authStateProvider)
    {
        _http = http;
        _localStorage = localStorage;
        _authStateProvider = authStateProvider;
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

        var tokenDto = await response.Content.ReadFromJsonAsync<TokenDto>();
        
        await _localStorage.SetItemAsync(AuthNamings.AccessToken, tokenDto.AccessToken);
        await _localStorage.SetItemAsync(AuthNamings.RefreshToken, tokenDto.RefreshToken);

        (_authStateProvider as CustomAuthStateProvider).NotifyUserAuth(tokenDto.AccessToken);
    }

    public async Task ChangePassword(PasswordChangeDto passwordChangeDto)
    {
        await _http.PatchAsJsonAsync("api/profile/email/change", passwordChangeDto);
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