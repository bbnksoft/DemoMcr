using Microsoft.EntityFrameworkCore;
using Product.Core.Entities;

namespace Product.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Core.Entities.Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Core.Entities.Product>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
            entity.Property(e => e.SKU).HasMaxLength(50);
            entity.Property(e => e.Category).HasMaxLength(100);
            entity.Property(e => e.CreatedAt).IsRequired();
            entity.HasQueryFilter(e => !e.IsDeleted);

            // Seed data
            entity.HasData(
                new Core.Entities.Product
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Name = "Wireless Mouse",
                    Description = "Ergonomic wireless mouse with 6 buttons",
                    Price = 29.99m,
                    SKU = "WM-001",
                    Category = "Electronics",
                    StockQuantity = 150,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Core.Entities.Product
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    Name = "Mechanical Keyboard",
                    Description = "RGB mechanical keyboard with Cherry MX switches",
                    Price = 89.99m,
                    SKU = "KB-002",
                    Category = "Electronics",
                    StockQuantity = 75,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Core.Entities.Product
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    Name = "USB-C Hub",
                    Description = "7-in-1 USB-C hub with HDMI and card reader",
                    Price = 45.99m,
                    SKU = "HUB-003",
                    Category = "Accessories",
                    StockQuantity = 200,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Core.Entities.Product
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    Name = "Laptop Stand",
                    Description = "Adjustable aluminum laptop stand",
                    Price = 39.99m,
                    SKU = "LS-004",
                    Category = "Accessories",
                    StockQuantity = 120,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Core.Entities.Product
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                    Name = "Webcam HD",
                    Description = "1080p HD webcam with built-in microphone",
                    Price = 69.99m,
                    SKU = "WC-005",
                    Category = "Electronics",
                    StockQuantity = 90,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                }
            );
        });
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                    break;
                case EntityState.Deleted:
                    entry.State = EntityState.Modified;
                    entry.Entity.IsDeleted = true;
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
