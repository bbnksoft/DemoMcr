using Microsoft.EntityFrameworkCore;
using Inventory.Core.Entities;

namespace Inventory.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Venue> Venues => Set<Venue>();
    public DbSet<Section> Sections => Set<Section>();
    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Venue entity configuration
        modelBuilder.Entity<Venue>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.State).HasMaxLength(50);
            entity.Property(e => e.ZipCode).HasMaxLength(20);
            entity.Property(e => e.Country).HasMaxLength(100);
            
            entity.HasMany(e => e.Sections)
                .WithOne(e => e.Venue)
                .HasForeignKey(e => e.VenueId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Section entity configuration
        modelBuilder.Entity<Section>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.SectionType).HasMaxLength(50);
            
            entity.HasOne(e => e.Venue)
                .WithMany(e => e.Sections)
                .HasForeignKey(e => e.VenueId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(e => e.Products)
                .WithOne(e => e.Section)
                .HasForeignKey(e => e.SectionId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Product entity configuration
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.SKU).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
            entity.Property(e => e.ProductType).HasMaxLength(50);
            
            entity.HasOne(e => e.Section)
                .WithMany(e => e.Products)
                .HasForeignKey(e => e.SectionId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Seed data
        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        // Seed Venues
        modelBuilder.Entity<Venue>().HasData(
            new Venue
            {
                Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                Name = "Madison Square Garden",
                Description = "World-famous arena in New York City",
                Address = "4 Pennsylvania Plaza",
                City = "New York",
                State = "NY",
                ZipCode = "10001",
                Country = "USA",
                Capacity = 20000,
                IsActive = true
            },
            new Venue
            {
                Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                Name = "Staples Center",
                Description = "Premier sports and entertainment venue in Los Angeles",
                Address = "1111 S Figueroa St",
                City = "Los Angeles",
                State = "CA",
                ZipCode = "90015",
                Country = "USA",
                Capacity = 19000,
                IsActive = true
            }
        );

        // Seed Sections
        modelBuilder.Entity<Section>().HasData(
            new Section
            {
                Id = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                VenueId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                Name = "Floor Section",
                Description = "Premium floor seating area",
                Capacity = 2000,
                SectionType = "Premium",
                IsActive = true
            },
            new Section
            {
                Id = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd"),
                VenueId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                Name = "Lower Bowl",
                Description = "Lower level seating",
                Capacity = 8000,
                SectionType = "Standard",
                IsActive = true
            },
            new Section
            {
                Id = Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"),
                VenueId = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                Name = "Court Side",
                Description = "Court side premium seating",
                Capacity = 500,
                SectionType = "VIP",
                IsActive = true
            },
            new Section
            {
                Id = Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff"),
                VenueId = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                Name = "Upper Deck",
                Description = "Upper level seating",
                Capacity = 5000,
                SectionType = "Standard",
                IsActive = true
            }
        );

        // Seed Products
        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                SectionId = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                Name = "Premium Floor Ticket",
                Description = "Front row floor seating ticket",
                SKU = "MSG-FL-001",
                Price = 500.00m,
                ProductType = "Ticket",
                AvailableQuantity = 100,
                IsActive = true
            },
            new Product
            {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                SectionId = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                Name = "Floor VIP Package",
                Description = "VIP package with meet and greet",
                SKU = "MSG-FL-VIP",
                Price = 1200.00m,
                ProductType = "Package",
                AvailableQuantity = 20,
                IsActive = true
            },
            new Product
            {
                Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                SectionId = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd"),
                Name = "Lower Bowl Ticket",
                Description = "Standard lower bowl seating",
                SKU = "MSG-LB-001",
                Price = 150.00m,
                ProductType = "Ticket",
                AvailableQuantity = 500,
                IsActive = true
            },
            new Product
            {
                Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                SectionId = Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"),
                Name = "Court Side Ticket",
                Description = "Premium court side seating",
                SKU = "STA-CS-001",
                Price = 800.00m,
                ProductType = "Ticket",
                AvailableQuantity = 50,
                IsActive = true
            },
            new Product
            {
                Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                SectionId = Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff"),
                Name = "Upper Deck Ticket",
                Description = "Upper deck seating",
                SKU = "STA-UD-001",
                Price = 75.00m,
                ProductType = "Ticket",
                AvailableQuantity = 1000,
                IsActive = true
            }
        );
    }
}
