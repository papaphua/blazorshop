using System.ComponentModel.DataAnnotations;
using BlazorShop.Server.Options;
using Microsoft.Extensions.Options;

namespace BlazorShop.Server.Data.Entities;

public class Session
{
    public Session()
    {
        Id = Guid.NewGuid();
    }
    
    [Required] public Guid Id { get; set; }
    
    [Required] public Guid UserId { get; set; }

    [Required] public User User { get; set; } = null!;

    [Required] public string AccessToken { get; set; } = null!;
    
    [Required] public string RefreshToken { get; set; } = null!;
    
    [Required] public DateTime RefreshTokenExpiryTime { get; set; }
}