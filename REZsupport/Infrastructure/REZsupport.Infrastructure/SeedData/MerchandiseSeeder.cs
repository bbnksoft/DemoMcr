using Microsoft.EntityFrameworkCore;
using REZsupport.Core.Entities;

namespace REZsupport.Infrastructure.SeedData;

public static class MerchandiseSeeder
{
    public static readonly Guid MerchCategory1Id = Guid.Parse("mc111111-1111-1111-1111-111111111111");
    public static readonly Guid MerchCategory2Id = Guid.Parse("mc222222-2222-2222-2222-222222222222");

    public static readonly Guid Merch1Id = Guid.Parse("m1111111-1111-1111-1111-111111111111");
    public static readonly Guid Merch2Id = Guid.Parse("m2222222-2222-2222-2222-222222222222");
    public static readonly Guid Merch3Id = Guid.Parse("m3333333-3333-3333-3333-333333333333");
    public static readonly Guid Merch4Id = Guid.Parse("m4444444-4444-4444-4444-444444444444");
    public static readonly Guid Merch5Id = Guid.Parse("m5555555-5555-5555-5555-555555555555");

    public static void Seed(ModelBuilder modelBuilder)
    {
        // Seed MerchandiseCategories
        var categories = new[]
        {
            new MerchandiseCategory
            {
                CategoryId = MerchCategory1Id,
                TenantId = TenantSeeder.Tenant1Id,
                CategoryCode = "BEVERAGE",
                CategoryName = "Beverage Packages",
                Description = "Drink packages and add-ons",
                DisplayOrder = 1,
                IsActive = true,
                CreatedDate = DateTime.Parse("2024-01-15")
            },
            new MerchandiseCategory
            {
                CategoryId = MerchCategory2Id,
                TenantId = TenantSeeder.Tenant1Id,
                CategoryCode = "EXCURSION",
                CategoryName = "Shore Excursions",
                Description = "Port excursions and activities",
                DisplayOrder = 2,
                IsActive = true,
                CreatedDate = DateTime.Parse("2024-01-15")
            }
        };

        modelBuilder.Entity<MerchandiseCategory>().HasData(categories);

        // Seed Merchandise
        var merchandise = new[]
        {
            new Merchandise
            {
                MerchandiseId = Merch1Id,
                TenantId = TenantSeeder.Tenant1Id,
                CategoryId = MerchCategory1Id,
                SKU = "BEV-PREM-001",
                ProductName = "Premium Beverage Package",
                ShortDescription = "Unlimited premium drinks throughout your cruise",
                ProductType = "Service",
                StockQuantity = 1000,
                TrackInventory = true,
                BasePrice = 599.00m,
                CompareAtPrice = 699.00m,
                TaxCategory = "Service",
                IsActive = true,
                IsWebVisible = true,
                CreatedDate = DateTime.Parse("2024-01-15")
            },
            new Merchandise
            {
                MerchandiseId = Merch2Id,
                TenantId = TenantSeeder.Tenant1Id,
                CategoryId = MerchCategory1Id,
                SKU = "BEV-CLASS-001",
                ProductName = "Classic Beverage Package",
                ShortDescription = "Unlimited soft drinks and select beverages",
                ProductType = "Service",
                StockQuantity = 1000,
                TrackInventory = true,
                BasePrice = 299.00m,
                TaxCategory = "Service",
                IsActive = true,
                IsWebVisible = true,
                CreatedDate = DateTime.Parse("2024-01-15")
            },
            new Merchandise
            {
                MerchandiseId = Merch3Id,
                TenantId = TenantSeeder.Tenant1Id,
                CategoryId = MerchCategory2Id,
                SKU = "EXC-BEACH-001",
                ProductName = "Beach Day Adventure",
                ShortDescription = "Full day beach excursion with lunch",
                ProductType = "Service",
                StockQuantity = 100,
                TrackInventory = true,
                BasePrice = 129.00m,
                TaxCategory = "Service",
                IsActive = true,
                IsWebVisible = true,
                CreatedDate = DateTime.Parse("2024-01-15")
            },
            new Merchandise
            {
                MerchandiseId = Merch4Id,
                TenantId = TenantSeeder.Tenant1Id,
                CategoryId = MerchCategory2Id,
                SKU = "EXC-SNORKEL-001",
                ProductName = "Snorkeling Adventure",
                ShortDescription = "3-hour snorkeling tour with equipment",
                ProductType = "Service",
                StockQuantity = 80,
                TrackInventory = true,
                BasePrice = 89.00m,
                TaxCategory = "Service",
                IsActive = true,
                IsWebVisible = true,
                CreatedDate = DateTime.Parse("2024-01-15")
            },
            new Merchandise
            {
                MerchandiseId = Merch5Id,
                TenantId = TenantSeeder.Tenant2Id,
                SKU = "SPA-MASSAGE-001",
                ProductName = "Spa Massage - 60 Minutes",
                ShortDescription = "Relaxing full body massage",
                ProductType = "Service",
                StockQuantity = 50,
                TrackInventory = true,
                BasePrice = 150.00m,
                CompareAtPrice = 180.00m,
                TaxCategory = "Service",
                IsActive = true,
                IsWebVisible = true,
                CreatedDate = DateTime.Parse("2024-02-01")
            }
        };

        modelBuilder.Entity<Merchandise>().HasData(merchandise);
    }
}
