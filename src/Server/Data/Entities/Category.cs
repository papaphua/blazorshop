using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Server.Data.Entities;

public sealed class Category
{
    public Category(string name, string uri)
    {
        Id = Guid.NewGuid();
        Name = name;
        Uri = uri;
    }
    
    [Required] public Guid Id { get; set; }
    
    [Required] public string Name { get; set; }
    
    [Required] public string Uri { get; set; }
}