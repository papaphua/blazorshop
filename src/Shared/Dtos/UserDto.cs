using System.ComponentModel;

namespace BlazorShop.Shared.Dtos;

public sealed class UserDto
{
    [ReadOnly(true)] public Guid Id { get; set; }

    [ReadOnly(true)] public string Username { get; set; } = null!;

    [ReadOnly(true)] public string Email { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Gender { get; set; }

    public DateTime? BirthDate { get; set; }
}