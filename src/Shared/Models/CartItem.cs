using System.ComponentModel.DataAnnotations;
using BlazorShop.Shared.Dtos;

namespace BlazorShop.Shared.Models;

public class CartItem
{
    public CartItem(ProductDto product)
    {
        Product = product;
        TotalPrice = product.Price;
    }
    
    [Required] public ProductDto Product { get; }

    [Required] public int Quantity { get; set; } = 1;
    
    [Required] public decimal TotalPrice { get; set; }
}