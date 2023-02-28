using BlazorShop.Server.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorShop.Server.Data.EntityConfigurations;

public sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public static readonly Guid BookCategoryId = Guid.NewGuid();
    public static readonly Guid MovieCategoryId = Guid.NewGuid();
    public static readonly Guid VideoGameCategoryId = Guid.NewGuid();

    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable(nameof(Category));

        builder.HasKey(category => category.Id);

        builder.HasData(
            new Category("Books", "books") { Id = BookCategoryId },
            new Category("Movies", "movies") { Id = MovieCategoryId },
            new Category("Video Games", "video-games") { Id = VideoGameCategoryId });
    }
}