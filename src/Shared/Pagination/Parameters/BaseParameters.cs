namespace BlazorShop.Shared.Pagination.Parameters;

public class BaseParameters
{
    private const int MaxPageSize = 50;

    private int _pageSize = 5;

    public int PageNumber { get; set; } = 1;
    
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
    }
    
    public string? Search { get; set; }
}