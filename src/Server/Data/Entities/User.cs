using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Server.Data.Entities;

public sealed class User
{
    public User(string username, string email, string passwordHash)
    {
        Id = Guid.NewGuid();
        RegisterDate = DateTime.Now;
        Username = username;
        Email = email;
        PasswordHash = passwordHash;
        IsEmailConfirmed = false;
    }
    
    [Required] public Guid Id { get; set; }
    
    [Required] public string Username { get; set; }
    
    [Required] public string Email { get; set; }
    
    [Required] public bool IsEmailConfirmed { get; set; }
    
    [Required] public string PasswordHash { get; set; }
    
    [Required] public DateTime RegisterDate { get; set; }

    [Required] public ICollection<Role> Roles { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Gender { get; set; }

    public DateTime? BirthDate { get; set; }
 }