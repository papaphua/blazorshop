using BlazorShop.Server.Auth.PermissionHandler;
using BlazorShop.Server.Common.Options.Setups;
using BlazorShop.Server.Common.Providers.LinkProvider;
using BlazorShop.Server.Common.Providers.PasswordProvider;
using BlazorShop.Server.Common.Providers.TokenProvider;
using BlazorShop.Server.Facades.AuthFacade;
using BlazorShop.Server.Facades.CategoryFacade;
using BlazorShop.Server.Facades.CommentFacade;
using BlazorShop.Server.Facades.ProductFacade;
using BlazorShop.Server.Facades.ProfileFacade;
using BlazorShop.Server.Facades.UserFacade;
using BlazorShop.Server.Middlewares;
using BlazorShop.Server.Services.CategoryService;
using BlazorShop.Server.Services.CommentService;
using BlazorShop.Server.Services.MailService;
using BlazorShop.Server.Services.PaymentService;
using BlazorShop.Server.Services.PermissionService;
using BlazorShop.Server.Services.ProductService;
using BlazorShop.Server.Services.SecurityService;
using BlazorShop.Server.Services.SessionService;
using BlazorShop.Server.Services.UserService;
using DotNetEnv;
using Microsoft.AspNetCore.Authorization;

namespace BlazorShop.Server.Common.Extensions;

public static class ServiceExtensions
{
    public static void AddBusinessServices(this IServiceCollection services)
    {
        services.AddScoped<ITokenProvider, TokenProvider>();
        services.AddScoped<IPasswordProvider, PasswordProvider>();
        services.AddScoped<ILinkProvider, LinkProvider>();

        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IPermissionService, PermissionService>();
        services.AddScoped<ISessionService, SessionService>();
        services.AddScoped<ISecurityService, SecurityService>();
        services.AddScoped<ICommentService, CommentService>();
        services.AddScoped<IMailService, MailService>();
        services.AddScoped<IPaymentService, PaymentService>();

        services.AddScoped<ICategoryFacade, CategoryFacade>();
        services.AddScoped<IProductFacade, ProductFacade>();
        services.AddScoped<IUserFacade, UserFacade>();
        services.AddScoped<ICommentFacade, CommentFacade>();
        services.AddScoped<IProfileFacade, ProfileFacade>();
        services.AddScoped<IAuthFacade, AuthFacade>();
    }

    public static void SetupOptions(this IServiceCollection services)
    {
        Env.Load();

        services.ConfigureOptions<JwtOptionsSetup>();
        services.ConfigureOptions<BearerOptionsSetup>();
        services.ConfigureOptions<PasswordOptionsSetup>();
        services.ConfigureOptions<SecurityOptionsSetup>();
        services.ConfigureOptions<MailOptionsSetup>();
        services.ConfigureOptions<PasswordOptionsSetup>();
        services.ConfigureOptions<UrlOptionsSetup>();
        services.ConfigureOptions<PaymentOptionsSetup>();
    }

    public static void AddPermissionAuthorization(this IServiceCollection services)
    {
        services.AddSingleton<IAuthorizationHandler, PermissionAuthHandler>();
        services.AddSingleton<IAuthorizationPolicyProvider, PermissionAuthPolicyProvider>();
    }
}