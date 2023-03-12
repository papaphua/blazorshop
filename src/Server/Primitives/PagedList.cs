using BlazorShop.Shared.Pagination;

namespace BlazorShop.Server.Primitives;

public sealed class PagedList<T> : List<T>
{
    private PagedList(IEnumerable<T> items, int count, int pageNumber, int pageSize)
    {
        MetaData = new MetaData
        {
            TotalCount = count,
            PageSize = pageSize,
            CurrentPage = pageNumber,
            TotalPages = (int)Math.Ceiling(count / (decimal)pageSize)
        };

        AddRange(items);
    }

    public MetaData MetaData { get; }

    public static PagedList<T> ToPagedList(List<T> source, int pageNumber, int pageSize)
    {
        var count = source.Count;
        var items = source
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        return new PagedList<T>(items, count, pageNumber, pageSize);
    }
}