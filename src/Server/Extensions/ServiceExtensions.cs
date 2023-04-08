using BlazorShop.Server.Auth.AuthTokenProvider;
using BlazorShop.Server.Auth.ConfirmationLinkProvider;
using BlazorShop.Server.Auth.PasswordProvider;
using BlazorShop.Server.Auth.PermissionHandler;
using BlazorShop.Server.Common.Options.Setups;
using BlazorShop.Server.Services.PaymentService;
using BlazorShop.Server.Services.UserService;
using BlazorShop.Server.Data.Repositories.CategoryRepository;
using BlazorShop.Server.Data.Repositories.CommentRepository;
using BlazorShop.Server.Data.Repositories.PermissionRepository;
using BlazorShop.Server.Data.Repositories.ProductRepository;
using BlazorShop.Server.Data.Repositories.SecurityRepository;
using BlazorShop.Server.Data.Repositories.SessionRepository;
using BlazorShop.Server.Data.Repositories.UserRepository;
using BlazorShop.Server.Middlewares;
using BlazorShop.Server.Services.AuthService;
using BlazorShop.Server.Services.CategoryService;
using BlazorShop.Server.Services.CommentService;
using BlazorShop.Server.Services.MailService;
using BlazorShop.Server.Services.ProductService;
using BlazorShop.Server.Services.ProfileService;
using BlazorShop.Server.Services.RoleService;
using Microsoft.AspNetCore.Authorization;

namespace BlazorShop.Server.Extensions;

public static class ServiceExtensions
{
    public static void AddBusinessServices(this IServiceCollection services)
    {
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPermissionRepository, PermissionRepository>();
        services.AddScoped<ISessionRepository, SessionRepository>();
        services.AddScoped<ISecurityRepository, SecurityRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();

        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IMailService, MailService>();
        services.AddScoped<IPaymentService, PaymentService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IProfileService, ProfileService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ICommentService, CommentService>();

        services.AddScoped<IPasswordProvider, PasswordProvider>();
        services.AddScoped<IConfirmationLinkProvider, ConfirmationLinkProvider>();
        services.AddScoped<IAuthTokenProvider, AuthTokenProvider>();
    }

    public static IServiceCollection SetupOptions(this IServiceCollection services)
    {
        if (services == null)
            throw new ArgumentNullException(nameof(services));

        DotNetEnv.Env.Load();

        services.ConfigureOptions<JwtOptionsSetup>();
        services.ConfigureOptions<BearerOptionsSetup>();
        services.ConfigureOptions<PasswordOptionsSetup>();
        services.ConfigureOptions<SecurityOptionsSetup>();
        services.ConfigureOptions<MailOptionsSetup>();
        services.ConfigureOptions<PasswordOptionsSetup>();
        services.ConfigureOptions<UrlOptionsSetup>();
        
        return services;
    }


    public static IServiceCollection AddGlobalExceptionHandler(this IServiceCollection services)
    {
        if (services == null)
            throw new ArgumentNullException(nameof(services));

        services.AddTransient<GlobalExceptionHandler>();

        return services;
    }

    public static IServiceCollection AddPermissionAuthorization(this IServiceCollection services)
    {
        if (services == null)
            throw new ArgumentNullException(nameof(services));

        services.AddSingleton<IAuthorizationHandler, PermissionAuthHandler>();
        services.AddSingleton<IAuthorizationPolicyProvider, PermissionAuthPolicyProvider>();

        return services;
    }
}