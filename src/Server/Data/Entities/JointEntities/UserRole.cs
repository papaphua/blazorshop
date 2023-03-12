using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Server.Data.Entities.JointEntities;

public sealed class UserRole
{
    public UserRole(Guid userId, int roleId)
    {
        UserId = userId;
        RoleId = roleId;
    }
    
    [Required] public Guid UserId { get; set; }
    
    [Required] public int RoleId { get; set; }
}