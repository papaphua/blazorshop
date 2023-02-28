using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Server.Data.Entities;

public sealed class Comment
{
    public Comment(string text, Guid userId)
    {
        Id = Guid.NewGuid();
        Text = text;
        UserId = userId;
    }
    
    [Required] public Guid Id { get; set; }
    
    [Required] public string Text { get; set; }

    [Required] public Guid UserId { get; set; }

    [Required] public User User { get; set; } = null!;
}