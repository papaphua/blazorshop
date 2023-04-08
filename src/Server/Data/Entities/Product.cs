using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorShop.Server.Data.Entities;

public sealed class Product
{
    public Product()
    {
        Id = Guid.NewGuid();
    }

    [Required] public Guid Id { get; set; }

    [Required] public string Name { get; set; } = null!;

    [Required] public string Description { get; set; } = null!;

    [Required] public string Slug { get; set; } = null!;

    [Required] public string ImageUrl { get; set; } = null!;

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }

    [Required]
    public ICollection<Comment> Comments { get; set; } = null!;
    
    [Required]
    public Guid CategoryId { get; set; }

    [Required] public Category Category { get; set; } = null!;
}