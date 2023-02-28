using BlazorShop.Server.Auth.PermissionHandler;
using BlazorShop.Server.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorShop.Server.Data.EntityConfigurations;

public sealed class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable(nameof(Permission));

        builder.HasKey(permission => permission.Id);

        var permissions = Enum.GetValues<Permissions>()
            .Select(permission => new Permission((int)permission, permission.ToString()));
        
        builder.HasData(permissions);
    }
}