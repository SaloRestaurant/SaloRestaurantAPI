using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaloAPI.Domain.Entities;

namespace SaloAPI.Infrastructure.Database.Configurations;

public class CategoryEntityConfiguration : IEntityTypeConfiguration<CategoryEntity>
{
    public void Configure(EntityTypeBuilder<CategoryEntity> builder)
    {
        builder.ToTable(nameof(CategoryEntity));

        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.Name).IsUnique();

        builder.HasMany(x => x.Products)
            .WithOne(x => x.CategoryEntity)
            .HasForeignKey(x => x.CategoryId);
    }
}