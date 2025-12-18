using Microsoft.EntityFrameworkCore;
using REZsupport.Core.Entities;

namespace REZsupport.Infrastructure.SeedData;

public static class VenueSeeder
{
    public static readonly Guid Venue1Id = Guid.Parse("v1111111-1111-1111-1111-111111111111");
    public static readonly Guid Venue2Id = Guid.Parse("v2222222-2222-2222-2222-222222222222");
    public static readonly Guid Venue3Id = Guid.Parse("v3333333-3333-3333-3333-333333333333");
    public static readonly Guid Venue4Id = Guid.Parse("v4444444-4444-4444-4444-444444444444");
    public static readonly Guid Venue5Id = Guid.Parse("v5555555-5555-5555-5555-555555555555");

    public static readonly Guid Section1Id = Guid.Parse("s1111111-1111-1111-1111-111111111111");
    public static readonly Guid Section2Id = Guid.Parse("s2222222-2222-2222-2222-222222222222");
    public static readonly Guid Section3Id = Guid.Parse("s3333333-3333-3333-3333-333333333333");
    public static readonly Guid Section4Id = Guid.Parse("s4444444-4444-4444-4444-444444444444");
    public static readonly Guid Section5Id = Guid.Parse("s5555555-5555-5555-5555-555555555555");

    public static void Seed(ModelBuilder modelBuilder)
    {
        var venues = new[]
        {
            new Venue
            {
                VenueId = Venue1Id,
                TenantId = TenantSeeder.Tenant1Id,
                VenueCode = "SHIP001",
                VenueName = "Oceanic Dream",
                VenueType = "CruiseShip",
                OperatorName = "Oceanic Cruises Inc.",
                MaxCapacity = 3000,
                TotalUnits = 1500,
                YearBuilt = 2018,
                Size = 170000,
                SizeUnit = "tons",
                ContactPhone = "+1-555-3001",
                ContactEmail = "oceanicdream@oceaniccruises.com",
                IsActive = true,
                Status = "Active",
                CreatedDate = DateTime.Parse("2024-01-15")
            },
            new Venue
            {
                VenueId = Venue2Id,
                TenantId = TenantSeeder.Tenant2Id,
                VenueCode = "HOTEL001",
                VenueName = "Grand Royale Hotel",
                VenueType = "Hotel",
                OperatorCompanyId = CompanySeeder.Company3Id,
                AddressLine1 = "500 Grand Avenue",
                City = "Chicago",
                StateProvince = "IL",
                PostalCode = "60601",
                Country = "USA",
                Latitude = 41.8781m,
                Longitude = -87.6298m,
                MaxCapacity = 800,
                TotalUnits = 400,
                YearBuilt = 2015,
                Size = 250000,
                SizeUnit = "sqft",
                ContactPhone = "+1-555-3002",
                ContactEmail = "info@grandroyale.com",
                IsActive = true,
                Status = "Active",
                CreatedDate = DateTime.Parse("2024-02-01")
            },
            new Venue
            {
                VenueId = Venue3Id,
                TenantId = TenantSeeder.Tenant3Id,
                VenueCode = "CONF001",
                VenueName = "Global Conference Center",
                VenueType = "ConferenceCenter",
                AddressLine1 = "1000 Convention Plaza",
                City = "Las Vegas",
                StateProvince = "NV",
                PostalCode = "89101",
                Country = "USA",
                Latitude = 36.1699m,
                Longitude = -115.1398m,
                MaxCapacity = 5000,
                TotalUnits = 50,
                YearBuilt = 2020,
                Size = 500000,
                SizeUnit = "sqft",
                ContactPhone = "+1-555-3003",
                ContactEmail = "bookings@globalconf.com",
                IsActive = true,
                Status = "Active",
                CreatedDate = DateTime.Parse("2024-03-10")
            },
            new Venue
            {
                VenueId = Venue4Id,
                TenantId = TenantSeeder.Tenant4Id,
                VenueCode = "ARENA001",
                VenueName = "Sunset Arena",
                VenueType = "Stadium",
                AddressLine1 = "2500 Arena Drive",
                City = "Nashville",
                StateProvince = "TN",
                PostalCode = "37201",
                Country = "USA",
                Latitude = 36.1627m,
                Longitude = -86.7816m,
                MaxCapacity = 20000,
                TotalUnits = 18500,
                YearBuilt = 2017,
                Size = 350000,
                SizeUnit = "sqft",
                ContactPhone = "+1-555-3004",
                ContactEmail = "events@sunsetarena.com",
                IsActive = true,
                Status = "Active",
                CreatedDate = DateTime.Parse("2024-04-05")
            },
            new Venue
            {
                VenueId = Venue5Id,
                TenantId = TenantSeeder.Tenant5Id,
                VenueCode = "PARK001",
                VenueName = "Rocky Mountain Adventure Park",
                VenueType = "Resort",
                AddressLine1 = "3000 Mountain Road",
                City = "Aspen",
                StateProvince = "CO",
                PostalCode = "81611",
                Country = "USA",
                Latitude = 39.1911m,
                Longitude = -106.8175m,
                MaxCapacity = 500,
                TotalUnits = 75,
                YearBuilt = 2019,
                Size = 1000,
                SizeUnit = "acres",
                ContactPhone = "+1-555-3005",
                ContactEmail = "info@rockyadventure.com",
                IsActive = true,
                Status = "Active",
                CreatedDate = DateTime.Parse("2024-05-20")
            }
        };

        modelBuilder.Entity<Venue>().HasData(venues);

        // Seed Sections
        var sections = new[]
        {
            new Section
            {
                SectionId = Section1Id,
                VenueId = Venue1Id,
                TenantId = TenantSeeder.Tenant1Id,
                SectionCode = "DECK-7",
                SectionName = "Deck 7 - Verandah",
                SectionType = "Deck",
                SectionNumber = 7,
                DisplayOrder = 7,
                TotalUnits = 250,
                MaxCapacity = 500,
                CreatedDate = DateTime.Parse("2024-01-15")
            },
            new Section
            {
                SectionId = Section2Id,
                VenueId = Venue2Id,
                TenantId = TenantSeeder.Tenant2Id,
                SectionCode = "FLOOR-10",
                SectionName = "10th Floor - Premium",
                SectionType = "Floor",
                SectionNumber = 10,
                DisplayOrder = 10,
                TotalUnits = 50,
                MaxCapacity = 100,
                CreatedDate = DateTime.Parse("2024-02-01")
            },
            new Section
            {
                SectionId = Section3Id,
                VenueId = Venue3Id,
                TenantId = TenantSeeder.Tenant3Id,
                SectionCode = "HALL-A",
                SectionName = "Hall A - Main Convention",
                SectionType = "Hall",
                DisplayOrder = 1,
                TotalUnits = 10,
                MaxCapacity = 2000,
                CreatedDate = DateTime.Parse("2024-03-10")
            },
            new Section
            {
                SectionId = Section4Id,
                VenueId = Venue4Id,
                TenantId = TenantSeeder.Tenant4Id,
                SectionCode = "LOWER",
                SectionName = "Lower Level Seating",
                SectionType = "Level",
                DisplayOrder = 1,
                TotalUnits = 8000,
                MaxCapacity = 8000,
                CreatedDate = DateTime.Parse("2024-04-05")
            },
            new Section
            {
                SectionId = Section5Id,
                VenueId = Venue5Id,
                TenantId = TenantSeeder.Tenant5Id,
                SectionCode = "LODGE",
                SectionName = "Main Lodge Area",
                SectionType = "Area",
                DisplayOrder = 1,
                TotalUnits = 25,
                MaxCapacity = 75,
                CreatedDate = DateTime.Parse("2024-05-20")
            }
        };

        modelBuilder.Entity<Section>().HasData(sections);
    }
}
