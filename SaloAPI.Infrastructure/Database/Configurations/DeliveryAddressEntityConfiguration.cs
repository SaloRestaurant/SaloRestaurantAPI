using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaloAPI.Domain.Entities;

namespace SaloAPI.Infrastructure.Database.Configurations;

public class DeliveryAddressEntityConfiguration : IEntityTypeConfiguration<DeliveryAddressEntity>
{
    public void Configure(EntityTypeBuilder<DeliveryAddressEntity> builder)
    {
        builder.ToTable(nameof(DeliveryAddressEntity));

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Address).HasMaxLength(50).IsRequired();
        builder.Property(x => x.District).HasMaxLength(30).IsRequired();
        builder.Property(x => x.City).HasMaxLength(30).IsRequired();
        builder.Property(x => x.ZipCode).HasMaxLength(5).IsRequired();
        builder.Property(x => x.AdditionalInfo).HasMaxLength(100).IsRequired();
        builder.Property(x => x.UserId).IsRequired();

        builder.HasOne(x => x.UserEntity)
            .WithMany(x => x.DeliveryAddresses)
            .HasForeignKey(x => x.UserId);
    }
}