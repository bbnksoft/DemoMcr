using Microsoft.EntityFrameworkCore;
using REZsupport.Core.Entities;

namespace REZsupport.Infrastructure.SeedData;

public static class ProductSeeder
{
    public static readonly Guid ProductType1Id = Guid.Parse("pt111111-1111-1111-1111-111111111111");
    public static readonly Guid ProductType2Id = Guid.Parse("pt222222-2222-2222-2222-222222222222");
    public static readonly Guid ProductType3Id = Guid.Parse("pt333333-3333-3333-3333-333333333333");

    public static readonly Guid Category1Id = Guid.Parse("pc111111-1111-1111-1111-111111111111");
    public static readonly Guid Category2Id = Guid.Parse("pc222222-2222-2222-2222-222222222222");
    public static readonly Guid Category3Id = Guid.Parse("pc333333-3333-3333-3333-333333333333");
    public static readonly Guid Category4Id = Guid.Parse("pc444444-4444-4444-4444-444444444444");
    public static readonly Guid Category5Id = Guid.Parse("pc555555-5555-5555-5555-555555555555");

    public static readonly Guid Product1Id = Guid.Parse("p1111111-1111-1111-1111-111111111111");
    public static readonly Guid Product2Id = Guid.Parse("p2222222-2222-2222-2222-222222222222");
    public static readonly Guid Product3Id = Guid.Parse("p3333333-3333-3333-3333-333333333333");
    public static readonly Guid Product4Id = Guid.Parse("p4444444-4444-4444-4444-444444444444");
    public static readonly Guid Product5Id = Guid.Parse("p5555555-5555-5555-5555-555555555555");
    public static readonly Guid Product6Id = Guid.Parse("p6666666-6666-6666-6666-666666666666");
    public static readonly Guid Product7Id = Guid.Parse("p7777777-7777-7777-7777-777777777777");

    public static void Seed(ModelBuilder modelBuilder)
    {
        // Seed ProductTypes
        var productTypes = new[]
        {
            new ProductType
            {
                ProductTypeId = ProductType1Id,
                TenantId = TenantSeeder.Tenant1Id,
                ProductTypeCode = "CABIN",
                ProductTypeName = "Cabin",
                Description = "Cruise ship cabin",
                ApplicableVerticals = "[\"CRUISE\"]",
                IsActive = true,
                CreatedDate = DateTime.Parse("2024-01-15")
            },
            new ProductType
            {
                ProductTypeId = ProductType2Id,
                TenantId = TenantSeeder.Tenant2Id,
                ProductTypeCode = "ROOM",
                ProductTypeName = "Hotel Room",
                Description = "Hotel guest room",
                ApplicableVerticals = "[\"HOTEL\"]",
                IsActive = true,
                CreatedDate = DateTime.Parse("2024-02-01")
            },
            new ProductType
            {
                ProductTypeId = ProductType3Id,
                TenantId = TenantSeeder.Tenant4Id,
                ProductTypeCode = "SEAT",
                ProductTypeName = "Seat",
                Description = "Arena seat",
                ApplicableVerticals = "[\"CONCERT\", \"CONFERENCE\"]",
                IsActive = true,
                CreatedDate = DateTime.Parse("2024-04-05")
            }
        };

        modelBuilder.Entity<ProductType>().HasData(productTypes);

        // Seed ProductCategories
        var categories = new[]
        {
            new ProductCategory
            {
                CategoryId = Category1Id,
                TenantId = TenantSeeder.Tenant1Id,
                VenueId = VenueSeeder.Venue1Id,
                ProductTypeId = ProductType1Id,
                CategoryCode = "BAL-SUITE",
                CategoryName = "Balcony Suite",
                Description = "Premium balcony cabin",
                StandardOccupancy = 2,
                MaxOccupancy = 4,
                Size = 250,
                SizeUnit = "sqft",
                IsActive = true,
                CreatedDate = DateTime.Parse("2024-01-15")
            },
            new ProductCategory
            {
                CategoryId = Category2Id,
                TenantId = TenantSeeder.Tenant2Id,
                VenueId = VenueSeeder.Venue2Id,
                ProductTypeId = ProductType2Id,
                CategoryCode = "DELUXE",
                CategoryName = "Deluxe Room",
                Description = "Deluxe hotel room",
                StandardOccupancy = 2,
                MaxOccupancy = 3,
                Size = 400,
                SizeUnit = "sqft",
                IsActive = true,
                CreatedDate = DateTime.Parse("2024-02-01")
            },
            new ProductCategory
            {
                CategoryId = Category3Id,
                TenantId = TenantSeeder.Tenant2Id,
                VenueId = VenueSeeder.Venue2Id,
                ProductTypeId = ProductType2Id,
                CategoryCode = "SUITE",
                CategoryName = "Executive Suite",
                Description = "Luxury executive suite",
                StandardOccupancy = 2,
                MaxOccupancy = 4,
                Size = 800,
                SizeUnit = "sqft",
                IsActive = true,
                CreatedDate = DateTime.Parse("2024-02-01")
            },
            new ProductCategory
            {
                CategoryId = Category4Id,
                TenantId = TenantSeeder.Tenant4Id,
                VenueId = VenueSeeder.Venue4Id,
                ProductTypeId = ProductType3Id,
                CategoryCode = "VIP",
                CategoryName = "VIP Seating",
                Description = "Premium VIP seats",
                StandardOccupancy = 1,
                MaxOccupancy = 1,
                IsActive = true,
                CreatedDate = DateTime.Parse("2024-04-05")
            },
            new ProductCategory
            {
                CategoryId = Category5Id,
                TenantId = TenantSeeder.Tenant4Id,
                VenueId = VenueSeeder.Venue4Id,
                ProductTypeId = ProductType3Id,
                CategoryCode = "GENERAL",
                CategoryName = "General Admission",
                Description = "Standard seating",
                StandardOccupancy = 1,
                MaxOccupancy = 1,
                IsActive = true,
                CreatedDate = DateTime.Parse("2024-04-05")
            }
        };

        modelBuilder.Entity<ProductCategory>().HasData(categories);

        // Seed Products
        var products = new[]
        {
            new Product
            {
                ProductId = Product1Id,
                VenueId = VenueSeeder.Venue1Id,
                SectionId = VenueSeeder.Section1Id,
                CategoryId = Category1Id,
                TenantId = TenantSeeder.Tenant1Id,
                ProductCode = "7056",
                ProductName = "Balcony Suite 7056",
                ProductType = "Cabin",
                LocationDescription = "Port side, midship",
                IsAccessible = false,
                Status = "Available",
                CreatedDate = DateTime.Parse("2024-01-15")
            },
            new Product
            {
                ProductId = Product2Id,
                VenueId = VenueSeeder.Venue1Id,
                SectionId = VenueSeeder.Section1Id,
                CategoryId = Category1Id,
                TenantId = TenantSeeder.Tenant1Id,
                ProductCode = "7058",
                ProductName = "Balcony Suite 7058",
                ProductType = "Cabin",
                LocationDescription = "Port side, midship",
                IsAccessible = false,
                Status = "Available",
                CreatedDate = DateTime.Parse("2024-01-15")
            },
            new Product
            {
                ProductId = Product3Id,
                VenueId = VenueSeeder.Venue2Id,
                SectionId = VenueSeeder.Section2Id,
                CategoryId = Category2Id,
                TenantId = TenantSeeder.Tenant2Id,
                ProductCode = "1001",
                ProductName = "Room 1001",
                ProductType = "Room",
                LocationDescription = "Corner room, city view",
                IsAccessible = false,
                Status = "Available",
                CreatedDate = DateTime.Parse("2024-02-01")
            },
            new Product
            {
                ProductId = Product4Id,
                VenueId = VenueSeeder.Venue2Id,
                SectionId = VenueSeeder.Section2Id,
                CategoryId = Category3Id,
                TenantId = TenantSeeder.Tenant2Id,
                ProductCode = "1050",
                ProductName = "Suite 1050",
                ProductType = "Room",
                LocationDescription = "Penthouse level",
                IsAccessible = false,
                Status = "Available",
                CreatedDate = DateTime.Parse("2024-02-01")
            },
            new Product
            {
                ProductId = Product5Id,
                VenueId = VenueSeeder.Venue4Id,
                SectionId = VenueSeeder.Section4Id,
                CategoryId = Category4Id,
                TenantId = TenantSeeder.Tenant4Id,
                ProductCode = "VIP-101",
                ProductName = "VIP Seat 101",
                ProductType = "Seat",
                LocationDescription = "Front row center",
                IsAccessible = true,
                Status = "Available",
                CreatedDate = DateTime.Parse("2024-04-05")
            },
            new Product
            {
                ProductId = Product6Id,
                VenueId = VenueSeeder.Venue4Id,
                SectionId = VenueSeeder.Section4Id,
                CategoryId = Category4Id,
                TenantId = TenantSeeder.Tenant4Id,
                ProductCode = "VIP-102",
                ProductName = "VIP Seat 102",
                ProductType = "Seat",
                LocationDescription = "Front row center",
                IsAccessible = false,
                Status = "Available",
                CreatedDate = DateTime.Parse("2024-04-05")
            },
            new Product
            {
                ProductId = Product7Id,
                VenueId = VenueSeeder.Venue4Id,
                SectionId = VenueSeeder.Section4Id,
                CategoryId = Category5Id,
                TenantId = TenantSeeder.Tenant4Id,
                ProductCode = "GA-1001",
                ProductName = "General Admission 1001",
                ProductType = "Seat",
                LocationDescription = "Section A",
                IsAccessible = false,
                Status = "Available",
                CreatedDate = DateTime.Parse("2024-04-05")
            }
        };

        modelBuilder.Entity<Product>().HasData(products);
    }
}
