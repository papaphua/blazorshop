using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorShop.Shared.Dtos;

public sealed class ProductDto
{
    [Required] public Guid Id { get; set; }
    
    [Required] public string Name { get; set; } = null!;

    [Required] public string Description { get; set; } = null!;

    [Required] public string Uri { get; set; } = null!;

    [Required] public string ImageUrl { get; set; } = null!;
    
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    
    [Required] public Guid CategoryId { get; set; }
}