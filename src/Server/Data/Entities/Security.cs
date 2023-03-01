using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Server.Data.Entities;

public sealed class Security
{
    public Security()
    {
        Id = Guid.NewGuid();
    }
    
    [Required] public Guid Id { get; set; }
    
    [Required] public Guid UserId { get; set; }
    
    [Required] public User User { get; set; } = null!;
    
    public string? EmailConfirmationCode { get; set; }
    public DateTime? EmailConfirmationCodeExpiry { get; set; }
}