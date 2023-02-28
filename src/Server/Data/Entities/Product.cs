using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorShop.Server.Data.Entities;

public sealed class Product
{
    public Product(string name, string description, string uri, decimal price, Guid categoryId)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Uri = uri;
        Price = price;
        CategoryId = categoryId;
    }
    
    [Required] public Guid Id { get; set; }

    [Required] public string Name { get; set; }

    [Required] public string Description { get; set; }

    [Required] public string Uri { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    
    [Required] public Guid CategoryId { get; set; }

    [Required] public Category Category { get; set; } = null!;

    public ICollection<Comment> Comments { get; set; } = null!;
}