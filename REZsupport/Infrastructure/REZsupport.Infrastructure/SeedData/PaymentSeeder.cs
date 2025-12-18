using Microsoft.EntityFrameworkCore;
using REZsupport.Core.Entities;

namespace REZsupport.Infrastructure.SeedData;

public static class PaymentSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var payments = new[]
        {
            new Payment
            {
                PaymentId = Guid.NewGuid(),
                ReservationId = ReservationSeeder.Reservation1Id,
                TenantId = TenantSeeder.Tenant1Id,
                PaymentNumber = "PAY-2024-001234-01",
                PaymentType = "CreditCard",
                PaymentDate = DateTime.Parse("2024-08-15T14:23:00"),
                Amount = 500.00m,
                Currency = "USD",
                PaymentStatus = "Completed",
                TransactionId = "TXN-CC-2024081514230001",
                ProcessorName = "Stripe",
                CreatedDate = DateTime.Parse("2024-08-15T14:23:00")
            },
            new Payment
            {
                PaymentId = Guid.NewGuid(),
                ReservationId = ReservationSeeder.Reservation2Id,
                TenantId = TenantSeeder.Tenant1Id,
                PaymentNumber = "PAY-2024-001235-01",
                PaymentType = "WireTransfer",
                PaymentDate = DateTime.Parse("2024-09-05T10:15:00"),
                Amount = 10000.00m,
                Currency = "USD",
                PaymentStatus = "Completed",
                TransactionId = "TXN-WIRE-2024090510150001",
                ProcessorName = "Bank Transfer",
                CreatedDate = DateTime.Parse("2024-09-05T10:15:00")
            },
            new Payment
            {
                PaymentId = Guid.NewGuid(),
                ReservationId = ReservationSeeder.Reservation3Id,
                TenantId = TenantSeeder.Tenant2Id,
                PaymentNumber = "PAY-2024-002001-01",
                PaymentType = "CreditCard",
                PaymentDate = DateTime.Parse("2024-10-15T16:45:00"),
                Amount = 674.00m,
                Currency = "USD",
                PaymentStatus = "Completed",
                TransactionId = "TXN-CC-2024101516450001",
                ProcessorName = "Stripe",
                CreatedDate = DateTime.Parse("2024-10-15T16:45:00")
            },
            new Payment
            {
                PaymentId = Guid.NewGuid(),
                ReservationId = ReservationSeeder.Reservation4Id,
                TenantId = TenantSeeder.Tenant4Id,
                PaymentNumber = "PAY-2024-003001-01",
                PaymentType = "CreditCard",
                PaymentDate = DateTime.Parse("2024-11-20T19:30:00"),
                Amount = 575.00m,
                Currency = "USD",
                PaymentStatus = "Completed",
                TransactionId = "TXN-CC-2024112019300001",
                ProcessorName = "Square",
                CreatedDate = DateTime.Parse("2024-11-20T19:30:00")
            }
        };

        modelBuilder.Entity<Payment>().HasData(payments);

        // Seed PromotionalCodes
        var promoCodes = new[]
        {
            new PromotionalCode
            {
                PromoCodeId = Guid.NewGuid(),
                TenantId = TenantSeeder.Tenant1Id,
                EventId = EventSeeder.Event1Id,
                PromoCode = "SUMMER2025",
                Description = "Summer 2025 Early Booking Discount",
                DiscountType = "Percentage",
                DiscountValue = 10.00m,
                ValidFrom = DateTime.Parse("2024-06-01"),
                ValidTo = DateTime.Parse("2024-12-31"),
                IsActive = true,
                UsageLimitTotal = 100,
                TimesUsed = 23,
                CreatedDate = DateTime.Parse("2024-06-01")
            },
            new PromotionalCode
            {
                PromoCodeId = Guid.NewGuid(),
                TenantId = TenantSeeder.Tenant1Id,
                PromoCode = "FIRSTTIME",
                Description = "First Time Customer Discount",
                DiscountType = "Fixed",
                DiscountValue = 100.00m,
                ValidFrom = DateTime.Parse("2024-01-01"),
                ValidTo = DateTime.Parse("2025-12-31"),
                IsActive = true,
                UsageLimitTotal = 500,
                TimesUsed = 87,
                CreatedDate = DateTime.Parse("2024-01-01")
            },
            new PromotionalCode
            {
                PromoCodeId = Guid.NewGuid(),
                TenantId = TenantSeeder.Tenant2Id,
                EventId = EventSeeder.Event3Id,
                PromoCode = "NYE2024",
                Description = "New Year's Eve Special",
                DiscountType = "Percentage",
                DiscountValue = 15.00m,
                ValidFrom = DateTime.Parse("2024-09-01"),
                ValidTo = DateTime.Parse("2024-12-20"),
                IsActive = true,
                UsageLimitTotal = 50,
                TimesUsed = 42,
                CreatedDate = DateTime.Parse("2024-09-01")
            },
            new PromotionalCode
            {
                PromoCodeId = Guid.NewGuid(),
                TenantId = TenantSeeder.Tenant4Id,
                EventId = EventSeeder.Event5Id,
                PromoCode = "EARLYBIRD",
                Description = "Early Bird Concert Tickets",
                DiscountType = "Percentage",
                DiscountValue = 20.00m,
                ValidFrom = DateTime.Parse("2024-11-01"),
                ValidTo = DateTime.Parse("2024-12-31"),
                IsActive = true,
                UsageLimitTotal = 200,
                TimesUsed = 156,
                CreatedDate = DateTime.Parse("2024-11-01")
            },
            new PromotionalCode
            {
                PromoCodeId = Guid.NewGuid(),
                TenantId = TenantSeeder.Tenant3Id,
                PromoCode = "GROUP10",
                Description = "Group Discount - 10+ Attendees",
                DiscountType = "Percentage",
                DiscountValue = 15.00m,
                ValidFrom = DateTime.Parse("2024-01-01"),
                ValidTo = DateTime.Parse("2025-12-31"),
                IsActive = true,
                TimesUsed = 34,
                CreatedDate = DateTime.Parse("2024-01-01")
            }
        };

        modelBuilder.Entity<PromotionalCode>().HasData(promoCodes);

        // Seed AuditLogs
        var auditLogs = new[]
        {
            new AuditLog
            {
                AuditId = Guid.NewGuid(),
                TenantId = TenantSeeder.Tenant1Id,
                EventType = "ReservationCreated",
                EntityType = "Reservation",
                EntityId = ReservationSeeder.Reservation1Id,
                UserId = UserSeeder.User1Id,
                Username = "manager@oceanic",
                NewValuesJson = "{\"ReservationNumber\": \"RES-2024-001234\", \"Status\": \"Confirmed\"}",
                EventTimestamp = DateTime.Parse("2024-08-15T14:20:00")
            },
            new AuditLog
            {
                AuditId = Guid.NewGuid(),
                TenantId = TenantSeeder.Tenant1Id,
                EventType = "PaymentProcessed",
                EntityType = "Payment",
                EntityId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                UserId = UserSeeder.User1Id,
                Username = "manager@oceanic",
                NewValuesJson = "{\"Amount\": 500.00, \"Status\": \"Completed\"}",
                EventTimestamp = DateTime.Parse("2024-08-15T14:23:00")
            },
            new AuditLog
            {
                AuditId = Guid.NewGuid(),
                TenantId = TenantSeeder.Tenant2Id,
                EventType = "EventCreated",
                EntityType = "Event",
                EntityId = EventSeeder.Event3Id,
                UserId = UserSeeder.Admin2Id,
                Username = "admin@grand",
                NewValuesJson = "{\"EventCode\": \"NYE-2024\", \"EventName\": \"New Year's Eve Gala 2024\"}",
                EventTimestamp = DateTime.Parse("2024-08-15T09:00:00")
            }
        };

        modelBuilder.Entity<AuditLog>().HasData(auditLogs);
    }
}
