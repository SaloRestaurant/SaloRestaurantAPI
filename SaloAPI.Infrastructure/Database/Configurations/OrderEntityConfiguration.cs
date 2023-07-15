using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaloAPI.Domain.Entities;

namespace SaloAPI.Infrastructure.Database.Configurations;

public class OrderEntityConfiguration : IEntityTypeConfiguration<OrderEntity>
{
    public void Configure(EntityTypeBuilder<OrderEntity> builder)
    {
        builder.ToTable(nameof(OrderEntity));

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Date).IsRequired();
        builder.Property(x => x.Status).IsRequired();
        builder.Property(x => x.Total).IsRequired();
        builder.Property(x => x.UserId).IsRequired();

        builder.HasOne(x => x.UserEntity)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.UserId);

        builder.HasOne(x => x.OrderDetailsEntity)
            .WithOne(x => x.OrderEntity)
            .HasForeignKey<OrderDetailsEntity>(x => x.OrderId);
    }
}