using BlazorShop.Client.Services.CartService;
using BlazorShop.Client.Services.CommentService;
using BlazorShop.Client.Services.HttpInterceptorService;
using BlazorShop.Client.Services.ProductService;
using BlazorShop.Client.Services.ProfileService;
using BlazorShop.Shared.Dtos;
using BlazorShop.Shared.Pagination;
using BlazorShop.Shared.Pagination.Parameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace BlazorShop.Client.Pages.Products;

[AllowAnonymous]
public sealed partial class Product : IDisposable
{
    [Inject] private IProductService ProductService { get; set; } = null!;
    [Inject] private ICartService CartService { get; set; } = null!;    
    [Inject] private ICommentService CommentService { get; set; } = null!;
    [Inject] private IProfileService ProfileService { get; set; } = null!;
    [Inject] private HttpInterceptorService HttpInterceptorService { get; set; } = null!;

    [Parameter] public string Uri { get; set; }

    private readonly CommentParameters _commentParameters = new();

    private ProductDto Item { get; set; } = new();
    private NewCommentDto NewComment { get; set; } = new();
    private UserDto? AuthUser { get; set; }
    private List<CommentDto> Comments { get; set; } = new();
    private MetaData MetaData { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        HttpInterceptorService.RegisterEvent();
        AuthUser = await ProfileService.GetAuthUser();
    }

    protected override async Task OnParametersSetAsync()
    {
        Item = await ProductService.GetProductByUri(Uri);
        NewComment.ProductId = Item.Id;
        _commentParameters.PageNumber = 1;
        _commentParameters.ProductId = Item.Id;
        await GetComments();
    }

    private async Task SelectPageAction(int page)
    {
        _commentParameters.PageNumber = page;
        await GetComments();
    }
    
    private async Task AddToCartAction(ProductDto product)
    {
        await CartService.AddToCart(product);
    }

    private async Task AddCommentAction()
    {
        await CommentService.AddComment(NewComment);
        await GetComments();
    }

    private async Task UpdateCommentAction(CommentDto dto)
    {
        await CommentService.UpdateComment(dto);
        await GetComments();
    }

    private async Task DeleteCommentAction(Guid id)
    {
        await CommentService.DeleteComment(id);
        await GetComments();
    }
    
    private async Task GetComments()
    {
        var pagingResponse = await CommentService.GetComments(_commentParameters);
        
        Comments = pagingResponse.Items;
        MetaData = pagingResponse.MetaData;
    }
    
    public void Dispose()
    {
        HttpInterceptorService.DisposeEvent();
    }
}