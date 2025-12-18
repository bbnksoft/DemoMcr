using Microsoft.EntityFrameworkCore;
using REZsupport.Core.Entities;

namespace REZsupport.Infrastructure.SeedData;

public static class ReservationSeeder
{
    public static readonly Guid Reservation1Id = Guid.Parse("rv111111-1111-1111-1111-111111111111");
    public static readonly Guid Reservation2Id = Guid.Parse("rv222222-2222-2222-2222-222222222222");
    public static readonly Guid Reservation3Id = Guid.Parse("rv333333-3333-3333-3333-333333333333");
    public static readonly Guid Reservation4Id = Guid.Parse("rv444444-4444-4444-4444-444444444444");
    public static readonly Guid Reservation5Id = Guid.Parse("rv555555-5555-5555-5555-555555555555");

    public static void Seed(ModelBuilder modelBuilder)
    {
        var reservations = new[]
        {
            new Reservation
            {
                ReservationId = Reservation1Id,
                TenantId = TenantSeeder.Tenant1Id,
                EventId = EventSeeder.Event1Id,
                PrimaryContactId = ContactSeeder.Contact3Id,
                ReservationNumber = "RES-2024-001234",
                ReservationStatus = "Confirmed",
                BookingDate = DateTime.Parse("2024-08-15"),
                ConfirmationDate = DateTime.Parse("2024-08-16"),
                SubtotalAmount = 3798.00m,
                TaxAmount = 300.00m,
                FeesAmount = 150.00m,
                DiscountAmount = 0.00m,
                TotalAmount = 4248.00m,
                Currency = "USD",
                AmountPaid = 500.00m,
                AmountDue = 3748.00m,
                PaymentStatus = "PartiallyPaid",
                TotalGuests = 2,
                AdultCount = 2,
                ChildCount = 0,
                BookingSource = "Website",
                CreatedDate = DateTime.Parse("2024-08-15")
            },
            new Reservation
            {
                ReservationId = Reservation2Id,
                TenantId = TenantSeeder.Tenant1Id,
                EventId = EventSeeder.Event1Id,
                PrimaryContactId = ContactSeeder.Contact1Id,
                CompanyId = CompanySeeder.Company1Id,
                GroupId = GroupSeeder.Group1Id,
                ReservationNumber = "RES-2024-001235",
                ReservationStatus = "Confirmed",
                BookingDate = DateTime.Parse("2024-09-01"),
                ConfirmationDate = DateTime.Parse("2024-09-01"),
                SubtotalAmount = 22788.00m,
                TaxAmount = 1800.00m,
                FeesAmount = 900.00m,
                DiscountAmount = 1000.00m,
                TotalAmount = 24488.00m,
                Currency = "USD",
                AmountPaid = 10000.00m,
                AmountDue = 14488.00m,
                PaymentStatus = "PartiallyPaid",
                TotalGuests = 12,
                AdultCount = 12,
                ChildCount = 0,
                BookingSource = "Corporate",
                CreatedDate = DateTime.Parse("2024-09-01")
            },
            new Reservation
            {
                ReservationId = Reservation3Id,
                TenantId = TenantSeeder.Tenant2Id,
                EventId = EventSeeder.Event3Id,
                PrimaryContactId = ContactSeeder.Contact5Id,
                ReservationNumber = "RES-2024-002001",
                ReservationStatus = "Confirmed",
                BookingDate = DateTime.Parse("2024-10-15"),
                ConfirmationDate = DateTime.Parse("2024-10-15"),
                SubtotalAmount = 599.00m,
                TaxAmount = 75.00m,
                FeesAmount = 0.00m,
                DiscountAmount = 0.00m,
                TotalAmount = 674.00m,
                Currency = "USD",
                AmountPaid = 674.00m,
                AmountDue = 0.00m,
                PaymentStatus = "Paid",
                TotalGuests = 2,
                AdultCount = 2,
                ChildCount = 0,
                BookingSource = "Phone",
                CreatedDate = DateTime.Parse("2024-10-15")
            },
            new Reservation
            {
                ReservationId = Reservation4Id,
                TenantId = TenantSeeder.Tenant4Id,
                EventId = EventSeeder.Event5Id,
                PrimaryContactId = ContactSeeder.Contact7Id,
                ReservationNumber = "RES-2024-003001",
                ReservationStatus = "Confirmed",
                BookingDate = DateTime.Parse("2024-11-20"),
                ConfirmationDate = DateTime.Parse("2024-11-20"),
                SubtotalAmount = 500.00m,
                TaxAmount = 50.00m,
                FeesAmount = 25.00m,
                DiscountAmount = 0.00m,
                TotalAmount = 575.00m,
                Currency = "USD",
                AmountPaid = 575.00m,
                AmountDue = 0.00m,
                PaymentStatus = "Paid",
                TotalGuests = 2,
                AdultCount = 2,
                ChildCount = 0,
                BookingSource = "Website",
                CreatedDate = DateTime.Parse("2024-11-20")
            },
            new Reservation
            {
                ReservationId = Reservation5Id,
                TenantId = TenantSeeder.Tenant5Id,
                EventId = EventSeeder.Event6Id,
                PrimaryContactId = ContactSeeder.Contact8Id,
                ReservationNumber = "RES-2024-004001",
                ReservationStatus = "Pending",
                BookingDate = DateTime.Parse("2024-12-05"),
                SubtotalAmount = 2500.00m,
                TaxAmount = 250.00m,
                FeesAmount = 100.00m,
                DiscountAmount = 0.00m,
                TotalAmount = 2850.00m,
                Currency = "USD",
                AmountPaid = 0.00m,
                AmountDue = 2850.00m,
                PaymentStatus = "Pending",
                TotalGuests = 1,
                AdultCount = 1,
                ChildCount = 0,
                BookingSource = "Website",
                CreatedDate = DateTime.Parse("2024-12-05")
            }
        };

        modelBuilder.Entity<Reservation>().HasData(reservations);

        // Seed ReservationProducts
        var reservationProducts = new[]
        {
            new ReservationProduct
            {
                ReservationProductId = Guid.NewGuid(),
                ReservationId = Reservation1Id,
                ProductId = ProductSeeder.Product1Id,
                TenantId = TenantSeeder.Tenant1Id,
                Occupancy = 2,
                UnitPrice = 1899.00m,
                SubtotalAmount = 3798.00m,
                TaxAmount = 300.00m,
                TotalAmount = 4098.00m,
                Status = "Confirmed",
                CreatedDate = DateTime.Parse("2024-08-15")
            },
            new ReservationProduct
            {
                ReservationProductId = Guid.NewGuid(),
                ReservationId = Reservation3Id,
                ProductId = ProductSeeder.Product3Id,
                TenantId = TenantSeeder.Tenant2Id,
                Occupancy = 2,
                UnitPrice = 599.00m,
                SubtotalAmount = 599.00m,
                TaxAmount = 75.00m,
                TotalAmount = 674.00m,
                Status = "Confirmed",
                CreatedDate = DateTime.Parse("2024-10-15")
            },
            new ReservationProduct
            {
                ReservationProductId = Guid.NewGuid(),
                ReservationId = Reservation4Id,
                ProductId = ProductSeeder.Product5Id,
                TenantId = TenantSeeder.Tenant4Id,
                Occupancy = 1,
                UnitPrice = 250.00m,
                SubtotalAmount = 500.00m,
                TaxAmount = 50.00m,
                TotalAmount = 550.00m,
                Status = "Confirmed",
                CreatedDate = DateTime.Parse("2024-11-20")
            }
        };

        modelBuilder.Entity<ReservationProduct>().HasData(reservationProducts);

        // Seed ReservationGuests
        var reservationGuests = new[]
        {
            new ReservationGuest
            {
                GuestId = Guid.NewGuid(),
                ReservationId = Reservation1Id,
                ContactId = ContactSeeder.Contact3Id,
                TenantId = TenantSeeder.Tenant1Id,
                GuestType = "Adult",
                FirstName = "Robert",
                LastName = "Garcia",
                Email = "robert.garcia@email.com",
                Phone = "+1-555-2003",
                DateOfBirth = DateTime.Parse("1985-06-15"),
                PassportNumber = "US123456789",
                PassportExpiry = DateTime.Parse("2028-06-15"),
                CheckInStatus = "NotCheckedIn",
                CreatedDate = DateTime.Parse("2024-08-15")
            },
            new ReservationGuest
            {
                GuestId = Guid.NewGuid(),
                ReservationId = Reservation1Id,
                TenantId = TenantSeeder.Tenant1Id,
                GuestType = "Adult",
                FirstName = "Maria",
                LastName = "Garcia",
                Email = "maria.garcia@email.com",
                Phone = "+1-555-2009",
                DateOfBirth = DateTime.Parse("1987-08-20"),
                PassportNumber = "US987654322",
                PassportExpiry = DateTime.Parse("2029-08-20"),
                CheckInStatus = "NotCheckedIn",
                CreatedDate = DateTime.Parse("2024-08-15")
            },
            new ReservationGuest
            {
                GuestId = Guid.NewGuid(),
                ReservationId = Reservation3Id,
                ContactId = ContactSeeder.Contact5Id,
                TenantId = TenantSeeder.Tenant2Id,
                GuestType = "Adult",
                FirstName = "Jennifer",
                LastName = "White",
                Email = "jennifer.white@email.com",
                Phone = "+1-555-2005",
                DateOfBirth = DateTime.Parse("1990-09-22"),
                CheckInStatus = "NotCheckedIn",
                CreatedDate = DateTime.Parse("2024-10-15")
            }
        };

        modelBuilder.Entity<ReservationGuest>().HasData(reservationGuests);

        // Seed ReservationMerchandise
        var reservationMerchandise = new[]
        {
            new ReservationMerchandise
            {
                ReservationMerchandiseId = Guid.NewGuid(),
                ReservationId = Reservation1Id,
                MerchandiseId = MerchandiseSeeder.Merch2Id,
                TenantId = TenantSeeder.Tenant1Id,
                ProductName = "Classic Beverage Package",
                ProductSKU = "BEV-CLASS-001",
                Quantity = 2,
                UnitPrice = 269.00m,
                SubtotalAmount = 538.00m,
                TaxAmount = 50.00m,
                TotalAmount = 588.00m,
                FulfillmentStatus = "Pending",
                CreatedDate = DateTime.Parse("2024-08-15")
            }
        };

        modelBuilder.Entity<ReservationMerchandise>().HasData(reservationMerchandise);
    }
}
