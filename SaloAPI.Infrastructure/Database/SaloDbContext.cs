using Microsoft.EntityFrameworkCore;
using SaloAPI.Domain.Entities;
using System.Reflection;

namespace SaloAPI.Infrastructure.Database;

public class SaloDbContext : DbContext
{
    public SaloDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<AdministratorEntity> Administrators { get; set; }

    public DbSet<DeliveryAddressEntity> DeliveryAddresses { get; set; }

    public DbSet<UserEntity> Users { get; set; }

    public DbSet<OrderEntity> Orders { get; set; }

    public DbSet<OrderDetailsEntity> OrderDetails { get; set; }

    public DbSet<CategoryEntity> Categories { get; set; }

    public DbSet<ProductEntity> Products { get; set; }

    public DbSet<ImageEntity> Images { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}