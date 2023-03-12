using BlazorShop.Server.Data.Entities;

namespace BlazorShop.Server.Data.RepositoryExtensions;

public static class ProductRepositoryExtensions
{
    public static IQueryable<Product> SearchFor(this IQueryable<Product> products, string? search)
    {
        if (string.IsNullOrWhiteSpace(search)) return products;

        var formattedSearch = search.Trim().ToLower();

        return products
            .Where(product => product.Name.ToLower().Contains(formattedSearch));
    }

    public static IQueryable<Product> WithCategory(this IQueryable<Product> products, string? categoryUri)
    {
        if (string.IsNullOrWhiteSpace(categoryUri)) return products;

        var formattedCategoryUri = categoryUri.Trim().ToLower();

        return products
            .Where(product =>  product.Category.Uri.ToLower().Contains(formattedCategoryUri));
    }
}