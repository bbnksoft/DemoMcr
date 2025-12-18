using Microsoft.EntityFrameworkCore;
using REZsupport.Core.Entities;

namespace REZsupport.Infrastructure.SeedData;

public static class NotificationSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        // Seed NotificationTemplates
        var templates = new[]
        {
            new NotificationTemplate
            {
                TemplateId = Guid.NewGuid(),
                TenantId = TenantSeeder.Tenant1Id,
                TemplateCode = "BOOKING_CONFIRMATION",
                TemplateName = "Booking Confirmation",
                TemplateType = "Email",
                Subject = "Your Booking Confirmation - {{ReservationNumber}}",
                HtmlBody = "<h1>Booking Confirmed!</h1><p>Dear {{CustomerName}},</p><p>Your reservation {{ReservationNumber}} has been confirmed.</p>",
                IsActive = true,
                CreatedDate = DateTime.Parse("2024-01-15")
            },
            new NotificationTemplate
            {
                TemplateId = Guid.NewGuid(),
                TenantId = TenantSeeder.Tenant1Id,
                TemplateCode = "PAYMENT_RECEIPT",
                TemplateName = "Payment Receipt",
                TemplateType = "Email",
                Subject = "Payment Receipt - {{PaymentNumber}}",
                HtmlBody = "<h1>Payment Received</h1><p>Dear {{CustomerName}},</p><p>We have received your payment of {{Amount}}.</p>",
                IsActive = true,
                CreatedDate = DateTime.Parse("2024-01-15")
            },
            new NotificationTemplate
            {
                TemplateId = Guid.NewGuid(),
                TenantId = TenantSeeder.Tenant2Id,
                TemplateCode = "EVENT_REMINDER",
                TemplateName = "Event Reminder",
                TemplateType = "Email",
                Subject = "Reminder: {{EventName}} - {{EventDate}}",
                HtmlBody = "<h1>Event Reminder</h1><p>Dear {{CustomerName}},</p><p>This is a reminder about your upcoming event.</p>",
                IsActive = true,
                CreatedDate = DateTime.Parse("2024-02-01")
            },
            new NotificationTemplate
            {
                TemplateId = Guid.NewGuid(),
                TenantId = TenantSeeder.Tenant3Id,
                TemplateCode = "REGISTRATION_CONFIRMATION",
                TemplateName = "Conference Registration Confirmation",
                TemplateType = "Email",
                Subject = "Registration Confirmed - {{EventName}}",
                HtmlBody = "<h1>Registration Confirmed</h1><p>Dear {{CustomerName}},</p><p>You are registered for {{EventName}}.</p>",
                IsActive = true,
                CreatedDate = DateTime.Parse("2024-03-10")
            },
            new NotificationTemplate
            {
                TemplateId = Guid.NewGuid(),
                TenantId = TenantSeeder.Tenant4Id,
                TemplateCode = "TICKET_DELIVERY",
                TemplateName = "Concert Ticket Delivery",
                TemplateType = "Email",
                Subject = "Your Tickets for {{EventName}}",
                HtmlBody = "<h1>Your Tickets Are Ready!</h1><p>Dear {{CustomerName}},</p><p>Please find your tickets attached.</p>",
                IsActive = true,
                CreatedDate = DateTime.Parse("2024-04-05")
            }
        };

        modelBuilder.Entity<NotificationTemplate>().HasData(templates);

        // Seed NotificationQueue
        var notifications = new[]
        {
            new NotificationQueue
            {
                QueueId = Guid.NewGuid(),
                TenantId = TenantSeeder.Tenant1Id,
                TemplateId = templates[0].TemplateId,
                RecipientType = "Email",
                RecipientAddress = "robert.garcia@email.com",
                Subject = "Your Booking Confirmation - RES-2024-001234",
                HtmlBody = "<h1>Booking Confirmed!</h1><p>Dear Robert Garcia,</p><p>Your reservation RES-2024-001234 has been confirmed.</p>",
                Status = "Sent",
                ScheduledSendDate = DateTime.Parse("2024-08-15T14:25:00"),
                ActualSendDate = DateTime.Parse("2024-08-15T14:25:30"),
                CreatedDate = DateTime.Parse("2024-08-15T14:24:00")
            },
            new NotificationQueue
            {
                QueueId = Guid.NewGuid(),
                TenantId = TenantSeeder.Tenant1Id,
                TemplateId = templates[1].TemplateId,
                RecipientType = "Email",
                RecipientAddress = "robert.garcia@email.com",
                Subject = "Payment Receipt - PAY-2024-001234-01",
                HtmlBody = "<h1>Payment Received</h1><p>Dear Robert Garcia,</p><p>We have received your payment of $500.00.</p>",
                Status = "Sent",
                ScheduledSendDate = DateTime.Parse("2024-08-15T14:24:00"),
                ActualSendDate = DateTime.Parse("2024-08-15T14:24:15"),
                CreatedDate = DateTime.Parse("2024-08-15T14:23:30")
            },
            new NotificationQueue
            {
                QueueId = Guid.NewGuid(),
                TenantId = TenantSeeder.Tenant2Id,
                TemplateId = templates[2].TemplateId,
                RecipientType = "Email",
                RecipientAddress = "jennifer.white@email.com",
                Subject = "Reminder: New Year's Eve Gala 2024 - December 31, 2024",
                HtmlBody = "<h1>Event Reminder</h1><p>Dear Jennifer White,</p><p>This is a reminder about your upcoming event on December 31, 2024.</p>",
                Status = "Queued",
                ScheduledSendDate = DateTime.Parse("2024-12-28T10:00:00"),
                CreatedDate = DateTime.Parse("2024-12-10T09:00:00")
            },
            new NotificationQueue
            {
                QueueId = Guid.NewGuid(),
                TenantId = TenantSeeder.Tenant4Id,
                TemplateId = templates[4].TemplateId,
                RecipientType = "Email",
                RecipientAddress = "taylor@startalent.com",
                Subject = "Your Tickets for Summer Music Festival 2025",
                HtmlBody = "<h1>Your Tickets Are Ready!</h1><p>Dear Taylor,</p><p>Please find your VIP tickets attached.</p>",
                Status = "Queued",
                ScheduledSendDate = DateTime.Parse("2025-06-10T12:00:00"),
                CreatedDate = DateTime.Parse("2024-11-20T19:35:00")
            },
            new NotificationQueue
            {
                QueueId = Guid.NewGuid(),
                TenantId = TenantSeeder.Tenant5Id,
                RecipientType = "SMS",
                RecipientAddress = "+1-555-2008",
                Subject = "Tour Reminder",
                HtmlBody = "Rocky Mountain Adventure Tour starts July 10, 2025. Get ready for an amazing adventure!",
                Status = "Queued",
                ScheduledSendDate = DateTime.Parse("2025-07-05T10:00:00"),
                CreatedDate = DateTime.Parse("2024-12-05T15:00:00")
            }
        };

        modelBuilder.Entity<NotificationQueue>().HasData(notifications);
    }
}
