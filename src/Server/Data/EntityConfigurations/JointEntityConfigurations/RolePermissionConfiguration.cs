using BlazorShop.Server.Common;
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
            new RolePermission((int)Roles.Customer, (int)Permissions.CustomerPermission),
            new RolePermission((int)Roles.Admin, (int)Permissions.CustomerPermission),
            new RolePermission((int)Roles.Admin, (int)Permissions.AdminPermission));
    }
}