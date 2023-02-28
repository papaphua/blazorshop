using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Server.Data.Entities.JointEntities;

public sealed class RolePermission
{
    public RolePermission(int roleId, int permissionId)
    {
        RoleId = roleId;
        PermissionId = permissionId;
    }
    
    [Required] public int RoleId { get; set; }
    
    [Required] public int PermissionId { get; set; }
}