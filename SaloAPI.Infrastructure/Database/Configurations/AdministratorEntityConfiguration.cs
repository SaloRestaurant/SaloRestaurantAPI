using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaloAPI.Domain.Entities;

namespace SaloAPI.Infrastructure.Database.Configurations;

public class AdministratorEntityConfiguration : IEntityTypeConfiguration<AdministratorEntity>
{
    public void Configure(EntityTypeBuilder<AdministratorEntity> builder)
    {
        builder.ToTable(nameof(AdministratorEntity));

        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirstName).HasMaxLength(50).IsRequired();
        builder.Property(x => x.LastName).HasMaxLength(50).IsRequired();
        builder.Property(x => x.Email).HasMaxLength(50).IsRequired();
        builder.Property(x => x.PasswordHash).IsRequired();
        builder.Property(x => x.PasswordSalt).IsRequired();
    }
}