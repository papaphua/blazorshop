using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Client.Models.Pagination;

public sealed class PagingLink
{
    public PagingLink(int page, bool enabled, string text)
    {
        Page = page;
        Enabled = enabled;
        Text = text;
    }

    public string Text { get; }

    public int Page { get; }
    public bool Enabled { get; }

    public bool Active { get; init; }
}