using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Shared.Dtos;

public sealed class CommentDto
{
    [Required] public Guid Id { get; set; }

    [Required] public Guid UserId { get; set; }

    [Required] public string Username { get; set; } = null!;

    [Required] public string Text { get; set; } = null!;
}