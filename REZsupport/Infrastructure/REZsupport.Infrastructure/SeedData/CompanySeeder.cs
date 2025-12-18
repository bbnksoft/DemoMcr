using Microsoft.EntityFrameworkCore;
using REZsupport.Core.Entities;

namespace REZsupport.Infrastructure.SeedData;

public static class CompanySeeder
{
    public static readonly Guid Company1Id = Guid.Parse("c1111111-1111-1111-1111-111111111111");
    public static readonly Guid Company2Id = Guid.Parse("c2222222-2222-2222-2222-222222222222");
    public static readonly Guid Company3Id = Guid.Parse("c3333333-3333-3333-3333-333333333333");
    public static readonly Guid Company4Id = Guid.Parse("c4444444-4444-4444-4444-444444444444");
    public static readonly Guid Company5Id = Guid.Parse("c5555555-5555-5555-5555-555555555555");
    public static readonly Guid Company6Id = Guid.Parse("c6666666-6666-6666-6666-666666666666");
    public static readonly Guid Company7Id = Guid.Parse("c7777777-7777-7777-7777-777777777777");

    public static void Seed(ModelBuilder modelBuilder)
    {
        var companies = new[]
        {
            new Company
            {
                CompanyId = Company1Id,
                TenantId = TenantSeeder.Tenant1Id,
                CompanyCode = "CORP001",
                CompanyName = "Tech Innovations Corp",
                CompanyType = "Corporate",
                LegalName = "Tech Innovations Corporation",
                TaxId = "12-3456789",
                PrimaryEmail = "contact@techinnovations.com",
                PrimaryPhone = "+1-555-1001",
                Website = "www.techinnovations.com",
                AddressLine1 = "123 Innovation Drive",
                City = "San Francisco",
                StateProvince = "CA",
                PostalCode = "94105",
                Country = "USA",
                IndustryType = "Technology",
                CompanySize = "Large",
                AccountStatus = "Active",
                CustomerSince = DateTime.Parse("2024-01-20"),
                TotalRevenue = 125000.00m,
                TotalBookings = 15,
                CreatedDate = DateTime.Parse("2024-01-20")
            },
            new Company
            {
                CompanyId = Company2Id,
                TenantId = TenantSeeder.Tenant1Id,
                CompanyCode = "CORP002",
                CompanyName = "Global Finance Group",
                CompanyType = "Corporate",
                LegalName = "Global Finance Group LLC",
                TaxId = "98-7654321",
                PrimaryEmail = "events@globalfinance.com",
                PrimaryPhone = "+1-555-1002",
                Website = "www.globalfinance.com",
                AddressLine1 = "456 Wall Street",
                City = "New York",
                StateProvince = "NY",
                PostalCode = "10005",
                Country = "USA",
                IndustryType = "Finance",
                CompanySize = "Enterprise",
                AccountStatus = "Active",
                CustomerSince = DateTime.Parse("2024-02-01"),
                TotalRevenue = 250000.00m,
                TotalBookings = 25,
                CreatedDate = DateTime.Parse("2024-02-01")
            },
            new Company
            {
                CompanyId = Company3Id,
                TenantId = TenantSeeder.Tenant2Id,
                CompanyCode = "CORP003",
                CompanyName = "Healthcare Partners Inc",
                CompanyType = "Corporate",
                LegalName = "Healthcare Partners Incorporated",
                TaxId = "45-6789012",
                PrimaryEmail = "bookings@healthcarepartners.com",
                PrimaryPhone = "+1-555-1003",
                Website = "www.healthcarepartners.com",
                AddressLine1 = "789 Medical Plaza",
                City = "Chicago",
                StateProvince = "IL",
                PostalCode = "60601",
                Country = "USA",
                IndustryType = "Healthcare",
                CompanySize = "Medium",
                AccountStatus = "Active",
                CustomerSince = DateTime.Parse("2024-03-15"),
                TotalRevenue = 85000.00m,
                TotalBookings = 12,
                CreatedDate = DateTime.Parse("2024-03-15")
            },
            new Company
            {
                CompanyId = Company4Id,
                TenantId = TenantSeeder.Tenant3Id,
                CompanyCode = "VEND001",
                CompanyName = "Premium Catering Services",
                CompanyType = "Vendor",
                LegalName = "Premium Catering Services LLC",
                TaxId = "78-9012345",
                PrimaryEmail = "sales@premiumcatering.com",
                PrimaryPhone = "+1-555-1004",
                Website = "www.premiumcatering.com",
                AddressLine1 = "321 Culinary Way",
                City = "Los Angeles",
                StateProvince = "CA",
                PostalCode = "90001",
                Country = "USA",
                IndustryType = "Food Service",
                CompanySize = "Small",
                AccountStatus = "Active",
                CustomerSince = DateTime.Parse("2024-03-20"),
                TotalRevenue = 45000.00m,
                TotalBookings = 8,
                CreatedDate = DateTime.Parse("2024-03-20")
            },
            new Company
            {
                CompanyId = Company5Id,
                TenantId = TenantSeeder.Tenant3Id,
                CompanyCode = "VEND002",
                CompanyName = "Event AV Solutions",
                CompanyType = "Vendor",
                LegalName = "Event AV Solutions Inc",
                TaxId = "56-7890123",
                PrimaryEmail = "info@eventav.com",
                PrimaryPhone = "+1-555-1005",
                Website = "www.eventav.com",
                AddressLine1 = "654 Tech Boulevard",
                City = "Austin",
                StateProvince = "TX",
                PostalCode = "78701",
                Country = "USA",
                IndustryType = "Audio Visual",
                CompanySize = "Small",
                AccountStatus = "Active",
                CustomerSince = DateTime.Parse("2024-04-01"),
                TotalRevenue = 32000.00m,
                TotalBookings = 6,
                CreatedDate = DateTime.Parse("2024-04-01")
            },
            new Company
            {
                CompanyId = Company6Id,
                TenantId = TenantSeeder.Tenant4Id,
                CompanyCode = "AGENT001",
                CompanyName = "Star Talent Agency",
                CompanyType = "Agency",
                LegalName = "Star Talent Agency LLC",
                TaxId = "34-5678901",
                PrimaryEmail = "bookings@startalent.com",
                PrimaryPhone = "+1-555-1006",
                Website = "www.startalent.com",
                AddressLine1 = "987 Entertainment Ave",
                City = "Nashville",
                StateProvince = "TN",
                PostalCode = "37201",
                Country = "USA",
                IndustryType = "Entertainment",
                CompanySize = "Medium",
                AccountStatus = "Active",
                CustomerSince = DateTime.Parse("2024-04-10"),
                TotalRevenue = 150000.00m,
                TotalBookings = 20,
                CreatedDate = DateTime.Parse("2024-04-10")
            },
            new Company
            {
                CompanyId = Company7Id,
                TenantId = TenantSeeder.Tenant5Id,
                CompanyCode = "SUPP001",
                CompanyName = "Adventure Gear Suppliers",
                CompanyType = "Supplier",
                LegalName = "Adventure Gear Suppliers Co",
                TaxId = "23-4567890",
                PrimaryEmail = "orders@adventuregear.com",
                PrimaryPhone = "+1-555-1007",
                Website = "www.adventuregear.com",
                AddressLine1 = "147 Outdoor Lane",
                City = "Denver",
                StateProvince = "CO",
                PostalCode = "80201",
                Country = "USA",
                IndustryType = "Outdoor Equipment",
                CompanySize = "Small",
                AccountStatus = "Active",
                CustomerSince = DateTime.Parse("2024-05-25"),
                TotalRevenue = 28000.00m,
                TotalBookings = 5,
                CreatedDate = DateTime.Parse("2024-05-25")
            }
        };

        modelBuilder.Entity<Company>().HasData(companies);
    }
}
