using BlazorShop.Server.Auth.PermissionHandler;
using BlazorShop.Server.Data.Entities;
using BlazorShop.Server.Data.Entities.JointEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorShop.Server.Data.EntityConfigurations.JointEntityConfigurations;

public sealed class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
{
    public void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        builder.ToTable(nameof(RolePermission));

        builder.HasKey(linked => new { linked.RoleId, linked.PermissionId });

        builder.HasData(
            new RolePermission(Role.Customer.Id, (int)Permissions.CustomerPermission),
            new RolePermission(Role.Admin.Id, (int)Permissions.AdminPermission),
            new RolePermission(Role.Customer.Id, (int)Permissions.AdminPermission));
    }
}