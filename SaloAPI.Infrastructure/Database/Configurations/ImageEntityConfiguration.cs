using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaloAPI.Domain.Entities;

namespace SaloAPI.Infrastructure.Database.Configurations;

public class ImageEntityConfiguration : IEntityTypeConfiguration<ImageEntity>
{
    public void Configure(EntityTypeBuilder<ImageEntity> builder)
    {
        builder.ToTable(nameof(ImageEntity));

        builder.HasKey(x => x.Id);

        builder.Property(x => x.FileName).HasMaxLength(50).IsRequired();
        builder.Property(x => x.ProductId).IsRequired();

        builder.HasOne(x => x.ProductEntity)
            .WithOne(x => x.ImageEntity)
            .HasForeignKey<ImageEntity>(x => x.ProductId);
    }
}