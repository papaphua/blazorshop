using BlazorShop.Shared.Pagination;

namespace BlazorShop.Client.Models.Pagination;

public sealed class PagingResponse<T> where T : class
{
    public List<T> Items { get; init; } = null!;

    public MetaData MetaData { get; init; } = null!;
}