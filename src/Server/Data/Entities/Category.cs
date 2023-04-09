using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Server.Data.Entities;

public sealed class Category
{
    public Category()
    {
        Id = Guid.NewGuid();
    }

    [Required] public Guid Id { get; set; }

    [Required] public string Name { get; set; } = null!;

    [Required] public string Slug { get; set; } = null!;
}