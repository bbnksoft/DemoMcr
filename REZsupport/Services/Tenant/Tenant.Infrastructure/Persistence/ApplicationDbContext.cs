using Microsoft.EntityFrameworkCore;

namespace Tenant.Infrastructure.Persistence;

/// <summary>
/// Application database context
/// </summary>
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// DbSet for Tenants
    /// </summary>
    public DbSet<Tenant> Tenants { get; set; }

    /// <summary>
    /// DbSet for Users
    /// </summary>
    public DbSet<User> Users { get; set; }

    /// <summary>
    /// DbSet for Roles
    /// </summary>
    public DbSet<Role> Roles { get; set; }

    /// <summary>
    /// DbSet for UserRoles
    /// </summary>
    public DbSet<UserRole> UserRoles { get; set; }

    /// <summary>
    /// DbSet for Venues
    /// </summary>
    public DbSet<Venue> Venues { get; set; }

    /// <summary>
    /// DbSet for Sections
    /// </summary>
    public DbSet<Section> Sections { get; set; }

    /// <summary>
    /// DbSet for ProductTypes
    /// </summary>
    public DbSet<ProductType> ProductTypes { get; set; }

    /// <summary>
    /// DbSet for ProductCategories
    /// </summary>
    public DbSet<ProductCategory> ProductCategories { get; set; }

    /// <summary>
    /// DbSet for Products
    /// </summary>
    public DbSet<Product> Products { get; set; }

    /// <summary>
    /// DbSet for Events
    /// </summary>
    public DbSet<Event> Events { get; set; }

    /// <summary>
    /// DbSet for EventInventories
    /// </summary>
    public DbSet<EventInventory> EventInventories { get; set; }

    /// <summary>
    /// Configure the entity models and relationships
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Apply configurations
        ConfigureTenant(modelBuilder);
        ConfigureUser(modelBuilder);
        ConfigureRole(modelBuilder);
        ConfigureVenue(modelBuilder);
        ConfigureSection(modelBuilder);
        ConfigureProductType(modelBuilder);
        ConfigureProductCategory(modelBuilder);
        ConfigureProduct(modelBuilder);
        ConfigureEvent(modelBuilder);
        ConfigureEventInventory(modelBuilder);

        // Seed data
        SeedData(modelBuilder);
    }

    /// <summary>
    /// Configure the Tenant entity
    /// </summary>
    /// <param name="modelBuilder"></param>
    private void ConfigureTenant(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tenant>(entity =>
        {
            entity.HasKey(e => e.TenantId);
            entity.HasIndex(e => e.TenantCode).IsUnique();
            entity.HasIndex(e => e.IsActive);

            entity.Property(e => e.TenantCode)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.CompanyName)
                .IsRequired()
                .HasMaxLength(255);

            entity.Property(e => e.ExtendedAttributes)
                .HasColumnType("nvarchar(max)");
        });
    }

    /// <summary>
    /// Configure the User entity
    /// </summary>
    /// <param name="modelBuilder"></param>
    private void ConfigureUser(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId);
            entity.HasIndex(e => new { e.TenantId, e.Email }).IsUnique();
            entity.HasIndex(e => e.TenantId);

            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(256);

            entity.HasOne(e => e.Tenant)
                .WithMany(t => t.Users)
                .HasForeignKey(e => e.TenantId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }

    /// <summary>
    /// Configure the Role entity 
    /// </summary>
    /// <param name="modelBuilder"></param>
    private void ConfigureRole(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId);
            entity.HasIndex(e => new { e.TenantId, e.RoleName }).IsUnique();

            entity.HasOne(e => e.Tenant)
                .WithMany(t => t.Roles)
                .HasForeignKey(e => e.TenantId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.UserRoleId);
            entity.HasIndex(e => new { e.UserId, e.RoleId }).IsUnique();

            entity.HasOne(e => e.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(e => e.RoleId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }

    /// <summary>
    /// Configure the Venue entity
    /// </summary>
    /// <param name="modelBuilder"></param>
    private void ConfigureVenue(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Venue>(entity =>
        {
            entity.HasKey(e => e.VenueId);
            entity.HasIndex(e => new { e.TenantId, e.VenueCode }).IsUnique();
            entity.HasIndex(e => e.TenantId);
            entity.HasIndex(e => e.Status);

            entity.Property(e => e.VenueName)
                .IsRequired()
                .HasMaxLength(255);

            entity.Property(e => e.VenueCode)
                .HasMaxLength(50);

            entity.Property(e => e.GrossTonnage)
                .HasColumnType("decimal(18,2)");

            entity.Property(e => e.Length)
                .HasColumnType("decimal(18,2)");

            entity.Property(e => e.Width)
                .HasColumnType("decimal(18,2)");

            entity.Property(e => e.Draft)
                .HasColumnType("decimal(18,2)");

            entity.Property(e => e.Description)
                .HasColumnType("nvarchar(max)");

            entity.Property(e => e.Notes)
                .HasColumnType("nvarchar(max)");

            entity.Property(e => e.ExtendedAttributes)
                .HasColumnType("nvarchar(max)");

            entity.HasOne(e => e.Tenant)
                .WithMany(t => t.Venues)
                .HasForeignKey(e => e.TenantId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }

    /// <summary>
    /// Configure the Section entity
    /// </summary>
    /// <param name="modelBuilder"></param>
    private void ConfigureSection(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Section>(entity =>
        {
            entity.HasKey(e => e.SectionId);
            entity.HasIndex(e => new { e.VenueId, e.SectionCode }).IsUnique();
            entity.HasIndex(e => e.TenantId);

            entity.Property(e => e.SectionName)
                .IsRequired()
                .HasMaxLength(255);

            entity.Property(e => e.Description)
                .HasColumnType("nvarchar(max)");

            entity.Property(e => e.ExtendedAttributes)
                .HasColumnType("nvarchar(max)");

            entity.HasOne(e => e.Venue)
                .WithMany(v => v.Sections)
                .HasForeignKey(e => e.VenueId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Tenant)
                .WithMany()
                .HasForeignKey(e => e.TenantId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }

    /// <summary>
    /// Configure the ProductType entity
    /// </summary>
    /// <param name="modelBuilder"></param>
    private void ConfigureProductType(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.HasKey(e => e.ProductTypeId);
            entity.HasIndex(e => e.TenantId);

            entity.Property(e => e.ProductTypeName)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Description)
                .HasColumnType("nvarchar(max)");

            entity.HasOne(e => e.Tenant)
                .WithMany()
                .HasForeignKey(e => e.TenantId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }

    /// <summary>
    /// Configure the ProductCategory entity
    /// </summary>
    /// <param name="modelBuilder"></param>
    private void ConfigureProductCategory(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId);
            entity.HasIndex(e => e.TenantId);
            entity.HasIndex(e => e.ProductTypeId);

            entity.Property(e => e.CategoryName)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Description)
                .HasColumnType("nvarchar(max)");

            entity.Property(e => e.ExtendedAttributes)
                .HasColumnType("nvarchar(max)");

            entity.HasOne(e => e.ProductType)
                .WithMany(pt => pt.ProductCategories)
                .HasForeignKey(e => e.ProductTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Tenant)
                .WithMany()
                .HasForeignKey(e => e.TenantId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }

    /// <summary>
    /// Configure the Product entity
    /// </summary>
    /// <param name="modelBuilder"></param>
    private void ConfigureProduct(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId);
            entity.HasIndex(e => new { e.VenueId, e.ProductCode }).IsUnique();
            entity.HasIndex(e => e.TenantId);
            entity.HasIndex(e => e.Status);

            entity.Property(e => e.ProductName)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.ProductCode)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.BasePrice)
                .HasColumnType("decimal(18,2)");

            entity.Property(e => e.DoubleOccupancyPrice)
                .HasColumnType("decimal(18,2)");

            entity.Property(e => e.SingleSupplementPrice)
                .HasColumnType("decimal(18,2)");

            entity.Property(e => e.SquareFeet)
                .HasColumnType("decimal(18,2)");

            entity.Property(e => e.Amenities)
                .HasColumnType("nvarchar(max)");

            entity.Property(e => e.Description)
                .HasColumnType("nvarchar(max)");

            entity.Property(e => e.Notes)
                .HasColumnType("nvarchar(max)");

            entity.Property(e => e.ExtendedAttributes)
                .HasColumnType("nvarchar(max)");

            entity.HasOne(e => e.Venue)
                .WithMany(v => v.Products)
                .HasForeignKey(e => e.VenueId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Section)
                .WithMany(s => s.Products)
                .HasForeignKey(e => e.SectionId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Tenant)
                .WithMany()
                .HasForeignKey(e => e.TenantId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }

    /// <summary>
    /// Configure the Event entity
    /// </summary>
    /// <param name="modelBuilder"></param>
    private void ConfigureEvent(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId);
            entity.HasIndex(e => new { e.TenantId, e.EventCode }).IsUnique();
            entity.HasIndex(e => e.VenueId);
            entity.HasIndex(e => e.StartDate);

            entity.Property(e => e.EventName)
                .IsRequired()
                .HasMaxLength(255);

            entity.Property(e => e.EventCode)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.BasePrice)
                .HasColumnType("decimal(18,2)");

            entity.Property(e => e.Description)
                .HasColumnType("nvarchar(max)");

            entity.Property(e => e.ExtendedAttributes)
                .HasColumnType("nvarchar(max)");

            entity.HasOne(e => e.Tenant)
                .WithMany(t => t.Events)
                .HasForeignKey(e => e.TenantId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Venue)
                .WithMany(v => v.Events)
                .HasForeignKey(e => e.VenueId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }

    /// <summary>
    /// Configure the EventInventory entity
    /// </summary>
    /// <param name="modelBuilder"></param>
    private void ConfigureEventInventory(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EventInventory>(entity =>
        {
            entity.HasKey(e => e.EventInventoryId);
            entity.HasIndex(e => new { e.EventId, e.ProductId }).IsUnique();
            entity.HasIndex(e => e.TenantId);
            entity.HasIndex(e => e.ReservationStatus);

            entity.Property(e => e.DoubleOccupancyPrice)
                .HasColumnType("decimal(18,2)");

            entity.Property(e => e.SingleSupplementPrice)
                .HasColumnType("decimal(18,2)");

            entity.Property(e => e.ExtendedAttributes)
                .HasColumnType("nvarchar(max)");

            entity.HasOne(e => e.Event)
                .WithMany(ev => ev.EventInventories)
                .HasForeignKey(e => e.EventId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Product)
                .WithMany(p => p.EventInventories)
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Tenant)
                .WithMany()
                .HasForeignKey(e => e.TenantId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        // Seed Venues
        modelBuilder.Entity<Venue>().HasData(
                    new Venue
                    {
                        VenueId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                        TenantId = Guid.Parse("11111111-1111-1111-1111-111111111111"), // Example TenantId, replace as needed
                        VenueName = "Madison Square Garden",
                        VenueCode = "MSG001",
                        VenueType = "Arena",
                        Status = "Active",
                        PassengerCapacity = 20000,
                        CrewCapacity = 500,
                        TotalDecks = 5,
                        TotalCabins = 0,
                        GrossTonnage = null,
                        Length = null,
                        Width = null,
                        Draft = null,
                        RegistryPort = null,
                        IMONumber = null,
                        FlagCountry = null,
                        BuildYear = 1968,
                        RefurbishmentYear = 2013,
                        HomePort = null,
                        CurrentLocation = "New York, NY",
                        LogoUrl = null,
                        ImageUrl = null,
                        OperationalStatus = "InService",
                        AvailableForBooking = true,
                        Description = "World-famous arena in New York City",
                        Notes = null,
                        ExtendedAttributes = null
                    },
                    new Venue
                    {
                        VenueId = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                        TenantId = Guid.Parse("22222222-2222-2222-2222-222222222222"), // Example TenantId, replace as needed
                        VenueName = "Staples Center",
                        VenueCode = "STC001",
                        VenueType = "Arena",
                        Status = "Active",
                        PassengerCapacity = 19000,
                        CrewCapacity = 400,
                        TotalDecks = 4,
                        TotalCabins = 0,
                        GrossTonnage = null,
                        Length = null,
                        Width = null,
                        Draft = null,
                        RegistryPort = null,
                        IMONumber = null,
                        FlagCountry = null,
                        BuildYear = 1999,
                        RefurbishmentYear = 2021,
                        HomePort = null,
                        CurrentLocation = "Los Angeles, CA",
                        LogoUrl = null,
                        ImageUrl = null,
                        OperationalStatus = "InService",
                        AvailableForBooking = true,
                        Description = "Premier sports and entertainment venue in Los Angeles",
                        Notes = null,
                        ExtendedAttributes = null
                    });

        // Seed Sections
        modelBuilder.Entity<Section>().HasData(
                    new Section
                    {
                        SectionId = Guid.Parse("11111111-aaaa-bbbb-cccc-111111111111"),
                        VenueId = Guid.Parse("a1e1c1d1-1111-2222-3333-444455556666"), // Oceanic Cruise Ship
                        TenantId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                        SectionName = "Main Deck",
                        SectionCode = "MD001",
                        SectionNumber = 1,
                        SectionType = "Deck",
                        Status = "Active",
                        Capacity = 500,
                        TotalProducts = 0,
                        Description = "Main deck area for guests",
                        ExtendedAttributes = null
                    },
                    new Section
                    {
                        SectionId = Guid.Parse("22222222-bbbb-cccc-dddd-222222222222"),
                        VenueId = Guid.Parse("a1e1c1d1-1111-2222-3333-444455556666"),
                        TenantId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                        SectionName = "Dining Hall",
                        SectionCode = "DH001",
                        SectionNumber = 2,
                        SectionType = "Dining",
                        Status = "Active",
                        Capacity = 200,
                        TotalProducts = 0,
                        Description = "Dining hall for guests",
                        ExtendedAttributes = null
                    },
                    new Section
                    {
                        SectionId = Guid.Parse("33333333-cccc-dddd-eeee-333333333333"),
                        VenueId = Guid.Parse("a1e1c1d1-1111-2222-3333-444455556666"),
                        TenantId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                        SectionName = "Cabin Area",
                        SectionCode = "CA001",
                        SectionNumber = 3,
                        SectionType = "Cabin",
                        Status = "Active",
                        Capacity = 100,
                        TotalProducts = 0,
                        Description = "Cabin area for accommodation",
                        ExtendedAttributes = null
                    },
                    new Section
                    {
                        SectionId = Guid.Parse("44444444-dddd-eeee-ffff-444444444444"),
                        VenueId = Guid.Parse("b2e2c2d2-7777-8888-9999-000011112222"), // Harborview Hotel
                        TenantId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                        SectionName = "Lobby",
                        SectionCode = "LB001",
                        SectionNumber = 1,
                        SectionType = "Lobby",
                        Status = "Active",
                        Capacity = 150,
                        TotalProducts = 0,
                        Description = "Hotel lobby area",
                        ExtendedAttributes = null
                    },
                    new Section
                    {
                        SectionId = Guid.Parse("55555555-eeee-ffff-aaaa-555555555555"),
                        VenueId = Guid.Parse("b2e2c2d2-7777-8888-9999-000011112222"),
                        TenantId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                        SectionName = "Conference Room",
                        SectionCode = "CR001",
                        SectionNumber = 2,
                        SectionType = "Conference",
                        Status = "Active",
                        Capacity = 80,
                        TotalProducts = 0,
                        Description = "Conference room for meetings",
                        ExtendedAttributes = null
                    }
        );

        // Seed Products
        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                // Add product seed data here
            },
            new Product
            {
                // Add product seed data here
            },
            new Product
            {
                // Add product seed data here
            },
            new Product
            {
                // Add product seed data here
            },
            new Product
            {
                // Add product seed data here
            }
        );

        // Seed ProductTypes
        modelBuilder.Entity<ProductType>().HasData(
            new ProductType
            {
                ProductTypeId = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                TenantId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                ProductTypeName = "Room",
                ProductTypeCode = "ROOM",
                Description = "Room type",
                IsActive = true
            },
            new ProductType
            {
                ProductTypeId = Guid.Parse("10000000-0000-0000-0000-000000000002"),
                TenantId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                ProductTypeName = "Suite",
                ProductTypeCode = "SUITE",
                Description = "Suite type",
                IsActive = true
            },
            new ProductType
            {
                ProductTypeId = Guid.Parse("10000000-0000-0000-0000-000000000003"),
                TenantId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                ProductTypeName = "Cabin",
                ProductTypeCode = "CABIN",
                Description = "Cabin type",
                IsActive = true
            },
            new ProductType
            {
                ProductTypeId = Guid.Parse("10000000-0000-0000-0000-000000000004"),
                TenantId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                ProductTypeName = "Conference",
                ProductTypeCode = "CONF",
                Description = "Conference room",
                IsActive = true
            },
            new ProductType
            {
                ProductTypeId = Guid.Parse("10000000-0000-0000-0000-000000000005"),
                TenantId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                ProductTypeName = "Dining",
                ProductTypeCode = "DINING",
                Description = "Dining hall",
                IsActive = true
            },
            new ProductType
            {
                ProductTypeId = Guid.Parse("10000000-0000-0000-0000-000000000006"),
                TenantId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                ProductTypeName = "Lobby",
                ProductTypeCode = "LOBBY",
                Description = "Lobby area",
                IsActive = true
            },
            new ProductType
            {
                ProductTypeId = Guid.Parse("10000000-0000-0000-0000-000000000007"),
                TenantId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                ProductTypeName = "Spa",
                ProductTypeCode = "SPA",
                Description = "Spa area",
                IsActive = true
            },
            new ProductType
            {
                ProductTypeId = Guid.Parse("10000000-0000-0000-0000-000000000008"),
                TenantId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                ProductTypeName = "Gym",
                ProductTypeCode = "GYM",
                Description = "Gym area",
                IsActive = true
            },
            new ProductType
            {
                ProductTypeId = Guid.Parse("10000000-0000-0000-0000-000000000009"),
                TenantId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                ProductTypeName = "Bar",
                ProductTypeCode = "BAR",
                Description = "Bar area",
                IsActive = true
            },
            new ProductType
            {
                ProductTypeId = Guid.Parse("10000000-0000-0000-0000-000000000010"),
                TenantId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                ProductTypeName = "Pool",
                ProductTypeCode = "POOL",
                Description = "Pool area",
                IsActive = true
            }
        );

        // Seed ProductCategories
        modelBuilder.Entity<ProductCategory>().HasData(
            new ProductCategory
            {
                CategoryId = Guid.Parse("20000000-0000-0000-0000-000000000001"),
                ProductTypeId = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                TenantId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                CategoryName = "Standard Room",
                CategoryCode = "STDROOM",
                Description = "Standard room category",
                Capacity = 2,
                DisplayOrder = 1,
                IsActive = true
            },
            new ProductCategory
            {
                CategoryId = Guid.Parse("20000000-0000-0000-0000-000000000002"),
                ProductTypeId = Guid.Parse("10000000-0000-0000-0000-000000000002"),
                TenantId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                CategoryName = "Executive Suite",
                CategoryCode = "EXESUITE",
                Description = "Executive suite category",
                Capacity = 4,
                DisplayOrder = 2,
                IsActive = true
            },
            new ProductCategory
            {
                CategoryId = Guid.Parse("20000000-0000-0000-0000-000000000003"),
                ProductTypeId = Guid.Parse("10000000-0000-0000-0000-000000000003"),
                TenantId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                CategoryName = "Ocean Cabin",
                CategoryCode = "OCEANCABIN",
                Description = "Ocean cabin category",
                Capacity = 2,
                DisplayOrder = 3,
                IsActive = true
            },
            new ProductCategory
            {
                CategoryId = Guid.Parse("20000000-0000-0000-0000-000000000004"),
                ProductTypeId = Guid.Parse("10000000-0000-0000-0000-000000000004"),
                TenantId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                CategoryName = "Large Conference",
                CategoryCode = "LARGECONF",
                Description = "Large conference room",
                Capacity = 50,
                DisplayOrder = 4,
                IsActive = true
            },
            new ProductCategory
            {
                CategoryId = Guid.Parse("20000000-0000-0000-0000-000000000005"),
                ProductTypeId = Guid.Parse("10000000-0000-0000-0000-000000000005"),
                TenantId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                CategoryName = "Main Dining",
                CategoryCode = "MAINDINING",
                Description = "Main dining hall",
                Capacity = 100,
                DisplayOrder = 5,
                IsActive = true
            },
            new ProductCategory
            {
                CategoryId = Guid.Parse("20000000-0000-0000-0000-000000000006"),
                ProductTypeId = Guid.Parse("10000000-0000-0000-0000-000000000006"),
                TenantId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CategoryName = "Hotel Lobby",
                CategoryCode = "HOTELLOBBY",
                Description = "Hotel lobby",
                Capacity = 200,
                DisplayOrder = 6,
                IsActive = true
            },
            new ProductCategory
            {
                CategoryId = Guid.Parse("20000000-0000-0000-0000-000000000007"),
                ProductTypeId = Guid.Parse("10000000-0000-0000-0000-000000000007"),
                TenantId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CategoryName = "Luxury Spa",
                CategoryCode = "LUXSPA",
                Description = "Luxury spa",
                Capacity = 20,
                DisplayOrder = 7,
                IsActive = true
            },
            new ProductCategory
            {
                CategoryId = Guid.Parse("20000000-0000-0000-0000-000000000008"),
                ProductTypeId = Guid.Parse("10000000-0000-0000-0000-000000000008"),
                TenantId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CategoryName = "Fitness Gym",
                CategoryCode = "FITGYM",
                Description = "Fitness gym",
                Capacity = 30,
                DisplayOrder = 8,
                IsActive = true
            },
            new ProductCategory
            {
                CategoryId = Guid.Parse("20000000-0000-0000-0000-000000000009"),
                ProductTypeId = Guid.Parse("10000000-0000-0000-0000-000000000009"),
                TenantId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CategoryName = "Cocktail Bar",
                CategoryCode = "COCKBAR",
                Description = "Cocktail bar",
                Capacity = 40,
                DisplayOrder = 9,
                IsActive = true
            },
            new ProductCategory
            {
                CategoryId = Guid.Parse("20000000-0000-0000-0000-000000000010"),
                ProductTypeId = Guid.Parse("10000000-0000-0000-0000-000000000010"),
                TenantId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CategoryName = "Outdoor Pool",
                CategoryCode = "OUTPOOL",
                Description = "Outdoor pool",
                Capacity = 60,
                DisplayOrder = 10,
                IsActive = true
            }
        );

        // Seed Products
        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                ProductId = Guid.Parse("30000000-0000-0000-0000-000000000001"),
                VenueId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                SectionId = Guid.Parse("11111111-aaaa-bbbb-cccc-111111111111"),
                CategoryId = Guid.Parse("20000000-0000-0000-0000-000000000001"),
                TenantId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                ProductName = "Standard Room 101",
                ProductCode = "STD101",
                Status = "Available",
                Capacity = 2,
                BasePrice = 120.00m,
                DoubleOccupancyPrice = 150.00m,
                SingleSupplementPrice = 80.00m,
                SquareFeet = 25.0m,
                BedType = "Queen",
                BathroomCount = 1,
                HasBalcony = false,
                HasWindow = true,
                IsAccessible = true,
                Amenities = "WiFi,TV,AC",
                ImageUrl = null,
                Description = "Standard room with queen bed",
                Notes = null,
                ExtendedAttributes = null
            },
            new Product
            {
                ProductId = Guid.Parse("30000000-0000-0000-0000-000000000002"),
                VenueId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                SectionId = Guid.Parse("11111111-aaaa-bbbb-cccc-111111111111"),
                CategoryId = Guid.Parse("20000000-0000-0000-0000-000000000001"),
                TenantId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                ProductName = "Standard Room 102",
                ProductCode = "STD102",
                Status = "Available",
                Capacity = 2,
                BasePrice = 125.00m,
                DoubleOccupancyPrice = 155.00m,
                SingleSupplementPrice = 85.00m,
                SquareFeet = 26.0m,
                BedType = "Queen",
                BathroomCount = 1,
                HasBalcony = false,
                HasWindow = true,
                IsAccessible = false,
                Amenities = "WiFi,TV,AC",
                ImageUrl = null,
                Description = "Standard room with queen bed",
                Notes = null,
                ExtendedAttributes = null
            },
            new Product
            {
                ProductId = Guid.Parse("30000000-0000-0000-0000-000000000003"),
                VenueId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                SectionId = Guid.Parse("22222222-bbbb-cccc-dddd-222222222222"),
                CategoryId = Guid.Parse("20000000-0000-0000-0000-000000000002"),
                TenantId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                ProductName = "Executive Suite 201",
                ProductCode = "EXE201",
                Status = "Available",
                Capacity = 4,
                BasePrice = 300.00m,
                DoubleOccupancyPrice = 350.00m,
                SingleSupplementPrice = 200.00m,
                SquareFeet = 50.0m,
                BedType = "King",
                BathroomCount = 2,
                HasBalcony = true,
                HasWindow = true,
                IsAccessible = true,
                Amenities = "WiFi,TV,AC,MiniBar",
                ImageUrl = null,
                Description = "Executive suite with king bed",
                Notes = null,
                ExtendedAttributes = null
            },
            new Product
            {
                ProductId = Guid.Parse("30000000-0000-0000-0000-000000000004"),
                VenueId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                SectionId = Guid.Parse("33333333-cccc-dddd-eeee-333333333333"),
                CategoryId = Guid.Parse("20000000-0000-0000-0000-000000000003"),
                TenantId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                ProductName = "Ocean Cabin 301",
                ProductCode = "CAB301",
                Status = "Available",
                Capacity = 2,
                BasePrice = 180.00m,
                DoubleOccupancyPrice = 210.00m,
                SingleSupplementPrice = 120.00m,
                SquareFeet = 20.0m,
                BedType = "Twin",
                BathroomCount = 1,
                HasBalcony = true,
                HasWindow = true,
                IsAccessible = false,
                Amenities = "WiFi,TV",
                ImageUrl = null,
                Description = "Ocean cabin with twin beds",
                Notes = null,
                ExtendedAttributes = null
            },
            new Product
            {
                ProductId = Guid.Parse("30000000-0000-0000-0000-000000000005"),
                VenueId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                SectionId = Guid.Parse("44444444-dddd-eeee-ffff-444444444444"),
                CategoryId = Guid.Parse("20000000-0000-0000-0000-000000000004"),
                TenantId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                ProductName = "Large Conference Room",
                ProductCode = "CONF001",
                Status = "Available",
                Capacity = 50,
                BasePrice = 500.00m,
                DoubleOccupancyPrice = null,
                SingleSupplementPrice = null,
                SquareFeet = 100.0m,
                BedType = null,
                BathroomCount = null,
                HasBalcony = false,
                HasWindow = true,
                IsAccessible = true,
                Amenities = "Projector,WiFi,Whiteboard",
                ImageUrl = null,
                Description = "Large conference room",
                Notes = null,
                ExtendedAttributes = null
            },
            new Product
            {
                ProductId = Guid.Parse("30000000-0000-0000-0000-000000000006"),
                VenueId = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                SectionId = Guid.Parse("44444444-dddd-eeee-ffff-444444444444"),
                CategoryId = Guid.Parse("20000000-0000-0000-0000-000000000006"),
                TenantId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                ProductName = "Hotel Lobby Sofa",
                ProductCode = "LOBBYSOFA",
                Status = "Available",
                Capacity = 5,
                BasePrice = 50.00m,
                DoubleOccupancyPrice = null,
                SingleSupplementPrice = null,
                SquareFeet = 10.0m,
                BedType = null,
                BathroomCount = null,
                HasBalcony = false,
                HasWindow = false,
                IsAccessible = true,
                Amenities = "Sofa,Table",
                ImageUrl = null,
                Description = "Lobby sofa area",
                Notes = null,
                ExtendedAttributes = null
            },
            new Product
            {
                ProductId = Guid.Parse("30000000-0000-0000-0000-000000000007"),
                VenueId = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                SectionId = Guid.Parse("55555555-eeee-ffff-aaaa-555555555555"),
                CategoryId = Guid.Parse("20000000-0000-0000-0000-000000000007"),
                TenantId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                ProductName = "Luxury Spa Room",
                ProductCode = "SPA001",
                Status = "Available",
                Capacity = 2,
                BasePrice = 200.00m,
                DoubleOccupancyPrice = 250.00m,
                SingleSupplementPrice = 120.00m,
                SquareFeet = 30.0m,
                BedType = null,
                BathroomCount = 1,
                HasBalcony = false,
                HasWindow = true,
                IsAccessible = true,
                Amenities = "Jacuzzi,Sauna,WiFi",
                ImageUrl = null,
                Description = "Luxury spa room",
                Notes = null,
                ExtendedAttributes = null
            },
            new Product
            {
                ProductId = Guid.Parse("30000000-0000-0000-0000-000000000008"),
                VenueId = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                SectionId = Guid.Parse("55555555-eeee-ffff-aaaa-555555555555"),
                CategoryId = Guid.Parse("20000000-0000-0000-0000-000000000008"),
                TenantId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                ProductName = "Fitness Gym Pass",
                ProductCode = "GYMPASS",
                Status = "Available",
                Capacity = 1,
                BasePrice = 30.00m,
                DoubleOccupancyPrice = null,
                SingleSupplementPrice = null,
                SquareFeet = 5.0m,
                BedType = null,
                BathroomCount = null,
                HasBalcony = false,
                HasWindow = false,
                IsAccessible = true,
                Amenities = "Gym,WiFi",
                ImageUrl = null,
                Description = "Access to fitness gym",
                Notes = null,
                ExtendedAttributes = null
            },
            new Product
            {
                ProductId = Guid.Parse("30000000-0000-0000-0000-000000000009"),
                VenueId = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                SectionId = Guid.Parse("55555555-eeee-ffff-aaaa-555555555555"),
                CategoryId = Guid.Parse("20000000-0000-0000-0000-000000000009"),
                TenantId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                ProductName = "Cocktail Bar Seat",
                ProductCode = "BARSEAT",
                Status = "Available",
                Capacity = 1,
                BasePrice = 15.00m,
                DoubleOccupancyPrice = null,
                SingleSupplementPrice = null,
                SquareFeet = 2.0m,
                BedType = null,
                BathroomCount = null,
                HasBalcony = false,
                HasWindow = false,
                IsAccessible = true,
                Amenities = "Bar,WiFi",
                ImageUrl = null,
                Description = "Seat at cocktail bar",
                Notes = null,
                ExtendedAttributes = null
            },
            new Product
            {
                ProductId = Guid.Parse("30000000-0000-0000-0000-000000000010"),
                VenueId = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                SectionId = Guid.Parse("55555555-eeee-ffff-aaaa-555555555555"),
                CategoryId = Guid.Parse("20000000-0000-0000-0000-000000000010"),
                TenantId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                ProductName = "Outdoor Pool Pass",
                ProductCode = "POOLPASS",
                Status = "Available",
                Capacity = 1,
                BasePrice = 25.00m,
                DoubleOccupancyPrice = null,
                SingleSupplementPrice = null,
                SquareFeet = 5.0m,
                BedType = null,
                BathroomCount = null,
                HasBalcony = false,
                HasWindow = false,
                IsAccessible = true,
                Amenities = "Pool,WiFi",
                ImageUrl = null,
                Description = "Access to outdoor pool",
                Notes = null,
                ExtendedAttributes = null
            }
        );

    }
}
