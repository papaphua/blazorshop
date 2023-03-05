using BlazorShop.Server.Auth.AuthTokenProvider;
using BlazorShop.Server.Auth.ConfirmationLinkProvider;
using BlazorShop.Server.Auth.PasswordProvider;
using BlazorShop.Server.Auth.PermissionHandler;
using BlazorShop.Server.Data;
using BlazorShop.Server.Data.Repositories.CategoryRepository;
using BlazorShop.Server.Data.Repositories.CommentRepository;
using BlazorShop.Server.Data.Repositories.PermissionRepository;
using BlazorShop.Server.Data.Repositories.ProductRepository;
using BlazorShop.Server.Data.Repositories.SecurityRepository;
using BlazorShop.Server.Data.Repositories.SessionRepository;
using BlazorShop.Server.Data.Repositories.UserRepository;
using BlazorShop.Server.Middlewares;
using BlazorShop.Server.Options.OptionSetups;
using BlazorShop.Server.Services.AuthService;
using BlazorShop.Server.Services.CategoryService;
using BlazorShop.Server.Services.CommentService;
using BlazorShop.Server.Services.MailService;
using BlazorShop.Server.Services.PaymentService;
using BlazorShop.Server.Services.ProductService;
using BlazorShop.Server.Services.ProfileService;
using BlazorShop.Server.Services.RoleService;
using BlazorShop.Server.Services.UserService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPermissionRepository, PermissionRepository>();
builder.Services.AddScoped<ISessionRepository, SessionRepository>();
builder.Services.AddScoped<ISecurityRepository, SecurityRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IMailService, MailService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IProfileService, ProfileService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICommentService, CommentService>();

builder.Services.ConfigureOptions<HashingOptionsSetup>();
builder.Services.ConfigureOptions<JwtOptionsSetup>();
builder.Services.ConfigureOptions<BearerOptionsSetup>();
builder.Services.ConfigureOptions<MailingOptionsSetup>();
builder.Services.ConfigureOptions<SecretOptionsSetup>();
builder.Services.ConfigureOptions<SecurityOptionsSetup>();
builder.Services.ConfigureOptions<UrlOptionsSetup>();

builder.Services.AddScoped<IPasswordProvider, PasswordProvider>();
builder.Services.AddScoped<IConfirmationLinkProvider, ConfirmationLinkProvider>();
builder.Services.AddScoped<IAuthTokenProvider, AuthTokenProvider>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy => { policy.WithExposedHeaders("X-Pagination"); });
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BlazorShop API", Version = "v1" });
});

builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

    options.UseSqlServer(connectionString);
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();

builder.Services.AddAuthorization();

builder.Services.AddSingleton<IAuthorizationHandler, PermissionAuthHandler>();
builder.Services.AddSingleton<IAuthorizationPolicyProvider, PermissionAuthPolicyProvider>();

builder.Services.AddTransient<GlobalExceptionHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseSwagger();
app.UseSwaggerUI(options => { options.SwaggerEndpoint("/swagger/v1/swagger.json", "BlazorShop API V1"); });

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<GlobalExceptionHandler>();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();