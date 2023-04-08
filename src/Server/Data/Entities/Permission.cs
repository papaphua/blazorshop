using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Server.Data.Entities;

public sealed class Permission
{
    [Required] public int Id { get; set; }

    [Required] public string Name { get; set; } = null!;
}