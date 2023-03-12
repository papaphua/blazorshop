using BlazorShop.Server.Data.Entities;
using BlazorShop.Server.Data.Entities.JointEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorShop.Server.Data.EntityConfigurations;

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User));
        
        builder.HasKey(user => user.Id);
        
        builder.HasMany(user => user.Roles)
            .WithMany()
            .UsingEntity<UserRole>();
    }
}