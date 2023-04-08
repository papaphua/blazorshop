﻿using System.ComponentModel.DataAnnotations;
using BlazorShop.Server.Primitives;

namespace BlazorShop.Server.Data.Entities;

public sealed class Role
{
    [Required] public int Id { get; set; }
    [Required] public string Name { get; set; } = null!;
    [Required] public ICollection<Permission> Permissions { get; set; } = null!;
}