using Blazored.LocalStorage;
using Blazorise;
using Blazorise.Icons.Material;
using Blazorise.Material;
using BlazorShop.Client;
using BlazorShop.Client.Auth.JwtProvider;
using BlazorShop.Client.Auth.PermissionHandler;
using BlazorShop.Client.Auth.StateProvider;
using BlazorShop.Client.Services.AuthService;
using BlazorShop.Client.Services.CartService;
using BlazorShop.Client.Services.CategoryService;
using BlazorShop.Client.Services.CommentService;
using BlazorShop.Client.Services.HttpInterceptorService;
using BlazorShop.Client.Services.PaymentService;
using BlazorShop.Client.Services.ProductService;
using BlazorShop.Client.Services.ProfileService;
using BlazorShop.Client.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Toolbelt.Blazor.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClientInterceptor();

builder.Services.AddHttpClient("BlazorShop.ServerAPI",
    (sp, client) =>
    {
        client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
        client.EnableIntercept(sp);
    });

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("BlazorShop.ServerAPI"));

builder.Services
    .AddBlazorise(options => { options.Immediate = true; })
    .AddMaterialProviders()
    .AddMaterialIcons();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProfileService, ProfileService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICartService, CartService>();

builder.Services.AddScoped<IJwtProvider, JwtProvider>();

builder.Services.AddScoped<HttpInterceptorService>();

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddSingleton<IAuthorizationHandler, PermissionAuthHandler>();
builder.Services.AddSingleton<IAuthorizationPolicyProvider, PermissionAuthPolicyProvider>();

builder.Services.AddAuthorizationCore();

await builder.Build().RunAsync();