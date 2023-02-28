using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Server.Data.Entities;

public sealed class Permission
{
    public Permission(int id, string name)
    {
        Id = id;
        Name = name;
    }
    
    [Required] public int Id { get; set; }
    
    [Required] public string Name { get; set; }
}