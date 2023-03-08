using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Server.Data.Entities;

public sealed class User
{
    public User()
    {
        Id = Guid.NewGuid();
        RegisterDate = DateTime.UtcNow;
    }
    
    [Required] public Guid Id { get; set; }

    [Required] public string Username { get; set; } = null!;
    
    [Required] public string Email { get; set; } = null!;
    
    [Required] public bool IsEmailConfirmed { get; set; }
    
    [Required] public string PasswordHash { get; set; } = null!;
    
    [Required] public DateTime RegisterDate { get; set; }

    [Required] public ICollection<Role> Roles { get; set; } = null!;
    
    [Required] public bool IsTwoAuth { get; set; }
    
    public string? PaymentProfileId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Gender { get; set; }

    public DateTime? BirthDate { get; set; }
 }