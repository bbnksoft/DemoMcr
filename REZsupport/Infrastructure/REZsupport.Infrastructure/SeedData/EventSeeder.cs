using Microsoft.EntityFrameworkCore;
using REZsupport.Core.Entities;

namespace REZsupport.Infrastructure.SeedData;

public static class EventSeeder
{
    public static readonly Guid Event1Id = Guid.Parse("e1111111-1111-1111-1111-111111111111");
    public static readonly Guid Event2Id = Guid.Parse("e2222222-2222-2222-2222-222222222222");
    public static readonly Guid Event3Id = Guid.Parse("e3333333-3333-3333-3333-333333333333");
    public static readonly Guid Event4Id = Guid.Parse("e4444444-4444-4444-4444-444444444444");
    public static readonly Guid Event5Id = Guid.Parse("e5555555-5555-5555-5555-555555555555");
    public static readonly Guid Event6Id = Guid.Parse("e6666666-6666-6666-6666-666666666666");

    public static void Seed(ModelBuilder modelBuilder)
    {
        var events = new[]
        {
            new Event
            {
                EventId = Event1Id,
                TenantId = TenantSeeder.Tenant1Id,
                VenueId = VenueSeeder.Venue1Id,
                EventCode = "CARIB-2025-JAN",
                EventName = "Caribbean Escape - January 2025",
                EventType = "Cruise",
                StartDate = DateTime.Parse("2025-01-15"),
                EndDate = DateTime.Parse("2025-01-22"),
                TimeZone = "America/New_York",
                MaxParticipants = 3000,
                CurrentBookingCount = 245,
                Status = "BookingOpen",
                IsWebEnabled = true,
                IsBookingOpen = true,
                BookingOpenDate = DateTime.Parse("2024-07-01"),
                BookingCloseDate = DateTime.Parse("2025-01-10"),
                ContactEmail = "bookings@oceaniccruises.com",
                ContactPhone = "+1-555-0101",
                CreatedDate = DateTime.Parse("2024-06-15")
            },
            new Event
            {
                EventId = Event2Id,
                TenantId = TenantSeeder.Tenant1Id,
                VenueId = VenueSeeder.Venue1Id,
                EventCode = "CARIB-2025-FEB",
                EventName = "Caribbean Escape - February 2025",
                EventType = "Cruise",
                StartDate = DateTime.Parse("2025-02-15"),
                EndDate = DateTime.Parse("2025-02-22"),
                TimeZone = "America/New_York",
                MaxParticipants = 3000,
                CurrentBookingCount = 189,
                Status = "BookingOpen",
                IsWebEnabled = true,
                IsBookingOpen = true,
                BookingOpenDate = DateTime.Parse("2024-08-01"),
                BookingCloseDate = DateTime.Parse("2025-02-10"),
                ContactEmail = "bookings@oceaniccruises.com",
                ContactPhone = "+1-555-0101",
                CreatedDate = DateTime.Parse("2024-07-15")
            },
            new Event
            {
                EventId = Event3Id,
                TenantId = TenantSeeder.Tenant2Id,
                VenueId = VenueSeeder.Venue2Id,
                EventCode = "NYE-2024",
                EventName = "New Year's Eve Gala 2024",
                EventType = "Special Event",
                StartDate = DateTime.Parse("2024-12-31T18:00:00"),
                EndDate = DateTime.Parse("2025-01-01T02:00:00"),
                TimeZone = "America/Chicago",
                MaxParticipants = 500,
                CurrentBookingCount = 387,
                Status = "BookingOpen",
                IsWebEnabled = true,
                IsBookingOpen = true,
                BookingOpenDate = DateTime.Parse("2024-09-01"),
                BookingCloseDate = DateTime.Parse("2024-12-25"),
                ContactEmail = "events@grandroyale.com",
                ContactPhone = "+1-555-3002",
                CreatedDate = DateTime.Parse("2024-08-15")
            },
            new Event
            {
                EventId = Event4Id,
                TenantId = TenantSeeder.Tenant3Id,
                VenueId = VenueSeeder.Venue3Id,
                EventCode = "TECH-CONF-2025",
                EventName = "TechInnovate Conference 2025",
                EventType = "Conference",
                StartDate = DateTime.Parse("2025-03-20T08:00:00"),
                EndDate = DateTime.Parse("2025-03-22T18:00:00"),
                TimeZone = "America/Los_Angeles",
                MaxParticipants = 2500,
                CurrentBookingCount = 1567,
                Status = "BookingOpen",
                IsWebEnabled = true,
                IsBookingOpen = true,
                BookingOpenDate = DateTime.Parse("2024-10-01"),
                BookingCloseDate = DateTime.Parse("2025-03-15"),
                ContactEmail = "register@techinnovate.com",
                ContactPhone = "+1-555-3003",
                CreatedDate = DateTime.Parse("2024-09-10")
            },
            new Event
            {
                EventId = Event5Id,
                TenantId = TenantSeeder.Tenant4Id,
                VenueId = VenueSeeder.Venue4Id,
                EventCode = "CONCERT-2025-JUN",
                EventName = "Summer Music Festival 2025",
                EventType = "Concert",
                StartDate = DateTime.Parse("2025-06-15T19:00:00"),
                EndDate = DateTime.Parse("2025-06-15T23:00:00"),
                TimeZone = "America/Chicago",
                MaxParticipants = 18000,
                CurrentBookingCount = 12543,
                Status = "BookingOpen",
                IsWebEnabled = true,
                IsBookingOpen = true,
                BookingOpenDate = DateTime.Parse("2024-11-01"),
                BookingCloseDate = DateTime.Parse("2025-06-14"),
                ContactEmail = "tickets@sunsetarena.com",
                ContactPhone = "+1-555-3004",
                CreatedDate = DateTime.Parse("2024-10-15")
            },
            new Event
            {
                EventId = Event6Id,
                TenantId = TenantSeeder.Tenant5Id,
                VenueId = VenueSeeder.Venue5Id,
                EventCode = "ADV-TOUR-2025-JUL",
                EventName = "Rocky Mountain Adventure Tour - July 2025",
                EventType = "Tour",
                StartDate = DateTime.Parse("2025-07-10"),
                EndDate = DateTime.Parse("2025-07-17"),
                TimeZone = "America/Denver",
                MaxParticipants = 100,
                CurrentBookingCount = 67,
                Status = "BookingOpen",
                IsWebEnabled = true,
                IsBookingOpen = true,
                BookingOpenDate = DateTime.Parse("2024-12-01"),
                BookingCloseDate = DateTime.Parse("2025-07-05"),
                ContactEmail = "tours@rockyadventure.com",
                ContactPhone = "+1-555-3005",
                CreatedDate = DateTime.Parse("2024-11-20")
            }
        };

        modelBuilder.Entity<Event>().HasData(events);

        // Seed EventInventory
        var eventInventory = new[]
        {
            new EventInventory
            {
                EventInventoryId = Guid.NewGuid(),
                EventId = Event1Id,
                ProductId = ProductSeeder.Product1Id,
                CategoryId = ProductSeeder.Category1Id,
                TenantId = TenantSeeder.Tenant1Id,
                IsAvailable = true,
                ReservationStatus = "Available",
                SingleOccupancyPrice = 2499.00m,
                DoubleOccupancyPrice = 1899.00m,
                TripleOccupancyPrice = 1599.00m,
                QuadOccupancyPrice = 1399.00m,
                ChildPrice = 899.00m,
                DepositAmount = 500.00m,
                TaxesAndFeesAmount = 150.00m,
                MinimumStay = 7,
                CreatedDate = DateTime.Parse("2024-06-15")
            },
            new EventInventory
            {
                EventInventoryId = Guid.NewGuid(),
                EventId = Event1Id,
                ProductId = ProductSeeder.Product2Id,
                CategoryId = ProductSeeder.Category1Id,
                TenantId = TenantSeeder.Tenant1Id,
                IsAvailable = true,
                ReservationStatus = "Available",
                SingleOccupancyPrice = 2499.00m,
                DoubleOccupancyPrice = 1899.00m,
                TripleOccupancyPrice = 1599.00m,
                QuadOccupancyPrice = 1399.00m,
                ChildPrice = 899.00m,
                DepositAmount = 500.00m,
                TaxesAndFeesAmount = 150.00m,
                MinimumStay = 7,
                CreatedDate = DateTime.Parse("2024-06-15")
            },
            new EventInventory
            {
                EventInventoryId = Guid.NewGuid(),
                EventId = Event3Id,
                ProductId = ProductSeeder.Product3Id,
                CategoryId = ProductSeeder.Category2Id,
                TenantId = TenantSeeder.Tenant2Id,
                IsAvailable = true,
                ReservationStatus = "Available",
                DoubleOccupancyPrice = 599.00m,
                TaxesAndFeesAmount = 75.00m,
                CreatedDate = DateTime.Parse("2024-08-15")
            },
            new EventInventory
            {
                EventInventoryId = Guid.NewGuid(),
                EventId = Event3Id,
                ProductId = ProductSeeder.Product4Id,
                CategoryId = ProductSeeder.Category3Id,
                TenantId = TenantSeeder.Tenant2Id,
                IsAvailable = true,
                ReservationStatus = "Available",
                DoubleOccupancyPrice = 999.00m,
                TaxesAndFeesAmount = 125.00m,
                CreatedDate = DateTime.Parse("2024-08-15")
            },
            new EventInventory
            {
                EventInventoryId = Guid.NewGuid(),
                EventId = Event5Id,
                ProductId = ProductSeeder.Product5Id,
                CategoryId = ProductSeeder.Category4Id,
                TenantId = TenantSeeder.Tenant4Id,
                IsAvailable = true,
                ReservationStatus = "Available",
                SingleOccupancyPrice = 250.00m,
                TaxesAndFeesAmount = 25.00m,
                CreatedDate = DateTime.Parse("2024-10-15")
            },
            new EventInventory
            {
                EventInventoryId = Guid.NewGuid(),
                EventId = Event5Id,
                ProductId = ProductSeeder.Product7Id,
                CategoryId = ProductSeeder.Category5Id,
                TenantId = TenantSeeder.Tenant4Id,
                IsAvailable = true,
                ReservationStatus = "Available",
                SingleOccupancyPrice = 75.00m,
                TaxesAndFeesAmount = 10.00m,
                CreatedDate = DateTime.Parse("2024-10-15")
            }
        };

        modelBuilder.Entity<EventInventory>().HasData(eventInventory);

        // Seed EventMerchandise
        var eventMerchandise = new[]
        {
            new EventMerchandise
            {
                EventMerchandiseId = Guid.NewGuid(),
                EventId = Event1Id,
                MerchandiseId = MerchandiseSeeder.Merch1Id,
                TenantId = TenantSeeder.Tenant1Id,
                EventPrice = 549.00m,
                IsVisible = true,
                CreatedDate = DateTime.Parse("2024-06-15")
            },
            new EventMerchandise
            {
                EventMerchandiseId = Guid.NewGuid(),
                EventId = Event1Id,
                MerchandiseId = MerchandiseSeeder.Merch2Id,
                TenantId = TenantSeeder.Tenant1Id,
                EventPrice = 269.00m,
                IsVisible = true,
                CreatedDate = DateTime.Parse("2024-06-15")
            },
            new EventMerchandise
            {
                EventMerchandiseId = Guid.NewGuid(),
                EventId = Event1Id,
                MerchandiseId = MerchandiseSeeder.Merch3Id,
                TenantId = TenantSeeder.Tenant1Id,
                EventPrice = 129.00m,
                EventStockQuantity = 50,
                IsVisible = true,
                CreatedDate = DateTime.Parse("2024-06-15")
            }
        };

        modelBuilder.Entity<EventMerchandise>().HasData(eventMerchandise);
    }
}
