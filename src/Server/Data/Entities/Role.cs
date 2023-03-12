using System.ComponentModel.DataAnnotations;
using BlazorShop.Server.Primitives;

namespace BlazorShop.Server.Data.Entities;

public sealed class Role : Enumeration<Role>
{
    public static readonly Role Customer = new(1, nameof(Customer));
    public static readonly Role Admin = new(2, nameof(Admin));

    public Role(int id, string name) 
        : base(id, name)
    {
    }

    [Required] public ICollection<Permission> Permissions { get; set; } = null!;
}