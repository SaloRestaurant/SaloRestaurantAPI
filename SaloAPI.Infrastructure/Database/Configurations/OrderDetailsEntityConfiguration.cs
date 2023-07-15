using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaloAPI.Domain.Entities;

namespace SaloAPI.Infrastructure.Database.Configurations;

public class OrderDetailsEntityConfiguration : IEntityTypeConfiguration<OrderDetailsEntity>
{
    public void Configure(EntityTypeBuilder<OrderDetailsEntity> builder)
    {
        builder.ToTable(nameof(OrderDetailsEntity));

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Quantity).IsRequired();
        builder.Property(x => x.OrderId).IsRequired();
        builder.Property(x => x.ProductId).IsRequired();

        builder.HasOne(x => x.OrderEntity)
            .WithOne(x => x.OrderDetailsEntity)
            .HasForeignKey<OrderDetailsEntity>(x => x.OrderId);

        builder.HasOne(x => x.ProductEntity)
            .WithOne(x => x.OrderDetailsEntity)
            .HasForeignKey<OrderDetailsEntity>(x => x.ProductId);
    }
}