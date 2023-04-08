using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorShop.Server.Data.Entities;

public sealed class Security
{
    public Security()
    {
        Id = Guid.NewGuid();
    }
    
    [Required] public Guid Id { get; set; }

    public string? ConfirmationCode { get; set; }
    public DateTime? ConfirmationCodeExpiry { get; set; }
    public string? NewEmailConfirmationCode { get; set; }

    public string? ConfirmationToken { get; set; }
    public DateTime? ConfirmationTokenExpiry { get; set; }
    
    [Required] public Guid UserId { get; set; }
    
    [Required] public User User { get; set; } = null!;
}