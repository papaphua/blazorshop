using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Server.Data.Entities;

public sealed class Comment
{
    public Comment()
    {
        Id = Guid.NewGuid();
    }

    [Required] public Guid Id { get; set; }

    [Required] public string Text { get; set; } = null!;

    [Required] public Guid UserId { get; set; }

    [Required] public User User { get; set; } = null!;
}