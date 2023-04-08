using BlazorShop.Server.Common;
using BlazorShop.Server.Data.Entities;
using BlazorShop.Server.Data.Entities.JointEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorShop.Server.Data.EntityConfigurations;

public sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable(nameof(Role));
        
        builder.HasKey(role => role.Id);

        builder.HasMany(role => role.Permissions)
            .WithMany()
            .UsingEntity<RolePermission>();

        var roles = Enum.GetValues<Roles>()
            .Select(role => new Role
            {
                Id = (int)role,
                Name = role.ToString()
            });
        
        builder.HasData(roles);
    }
}