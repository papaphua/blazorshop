using BlazorShop.Client.Models.Pagination;
using BlazorShop.Shared.Pagination;
using Microsoft.AspNetCore.Components;

namespace BlazorShop.Client.Shared.Components;

public partial class Pagination
{
    public const string Previous = nameof(Previous);
    public const string Next = nameof(Next);

    private List<PagingLink> Links { get; set; } = new();

    [Parameter] [EditorRequired] public MetaData MetaData { get; set; } = null!;

    [Parameter] [EditorRequired] public int Spread { get; set; }

    [Parameter] [EditorRequired] public EventCallback<int> SelectedPage { get; set; }

    protected override void OnParametersSet()
    {
        CreatePaginationLinks();
    }

    private void CreatePaginationLinks()
    {
        Links = new List<PagingLink>
        {
            new(MetaData.CurrentPage - 1, MetaData.HasPrevious, Previous)
        };

        for (var i = 1; i <= MetaData.TotalPages; i++)
            if (i >= MetaData.CurrentPage - Spread && i <= MetaData.CurrentPage + Spread)
                Links.Add(new PagingLink(i, true, i.ToString())
                {
                    Active = MetaData.CurrentPage == i
                });

        Links.Add(new PagingLink(MetaData.CurrentPage + 1, MetaData.HasNext, Next));
    }

    private async Task OnSelectedPage(PagingLink link)
    {
        if (link.Page == MetaData.CurrentPage || !link.Enabled) return;

        MetaData.CurrentPage = link.Page;
        await SelectedPage.InvokeAsync(link.Page);
    }
}