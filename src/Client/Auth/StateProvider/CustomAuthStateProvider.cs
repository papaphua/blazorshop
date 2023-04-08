using System.Net.Http.Headers;
using System.Security.Claims;
using Blazored.LocalStorage;
using BlazorShop.Client.Auth.JwtProvider;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorShop.Client.Auth.StateProvider;

public sealed class CustomAuthStateProvider : AuthenticationStateProvider
{
    private readonly AuthenticationState _anonymous;
    private readonly HttpClient _http;
    private readonly IJwtProvider _jwtProvider;
    private readonly ILocalStorageService _localStorage;

    public CustomAuthStateProvider(ILocalStorageService localStorage,
        HttpClient http, IJwtProvider jwtProvider)
    {
        _localStorage = localStorage;
        _anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        _http = http;
        _jwtProvider = jwtProvider;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var token = await _localStorage.GetItemAsync<string>(AuthNamings.AccessToken);

        if (string.IsNullOrEmpty(token)) return _anonymous;

        return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(
            _jwtProvider.Parse(token), AuthNamings.Jwt)));
    }

    public void NotifyUserAuth(string token)
    {
        var user = new ClaimsPrincipal(new ClaimsIdentity(_jwtProvider.Parse(token), AuthNamings.Jwt));

        var state = Task.FromResult(new AuthenticationState(user));

        _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(AuthNamings.Bearer, token);

        NotifyAuthenticationStateChanged(state);
    }

    public void NotifyUserLogout()
    {
        var state = Task.FromResult(_anonymous);

        _http.DefaultRequestHeaders.Authorization = null;

        NotifyAuthenticationStateChanged(state);
    }

    public async Task RefreshAuthHeader()
    {
        var token = await _localStorage.GetItemAsync<string>(AuthNamings.AccessToken);

        if (token is null)
        {
            _http.DefaultRequestHeaders.Authorization = null;
            return;
        }

        _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(AuthNamings.Bearer, token);
    }
}