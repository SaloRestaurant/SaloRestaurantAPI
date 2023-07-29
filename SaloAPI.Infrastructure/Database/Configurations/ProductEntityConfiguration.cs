using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaloAPI.Domain.Entities;

namespace SaloAPI.Infrastructure.Database.Configurations;

public class ProductEntityConfiguration : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        builder.ToTable(nameof(ProductEntity));

        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.Name).IsUnique();

        builder.Property(x => x.Description).HasMaxLength(150).IsRequired();
        builder.Property(x => x.Price).IsRequired();
        builder.Property(x => x.Quantity).IsRequired();
        builder.Property(x => x.CategoryId).IsRequired();

        builder.HasOne(x => x.OrderDetailsEntity)
            .WithOne(x => x.ProductEntity)
            .HasForeignKey<OrderDetailsEntity>(x => x.ProductId);

        builder.HasOne(x => x.CategoryEntity)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.CategoryId);

        builder.HasMany(x => x.Images)
            .WithOne(x => x.ProductEntity)
            .HasForeignKey(x => x.ProductId);
    }
}