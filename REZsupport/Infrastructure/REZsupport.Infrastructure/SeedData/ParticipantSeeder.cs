using Microsoft.EntityFrameworkCore;
using REZsupport.Core.Entities;

namespace REZsupport.Infrastructure.SeedData;

public static class ParticipantSeeder
{
    public static readonly Guid Participant1Id = Guid.Parse("pp111111-1111-1111-1111-111111111111");
    public static readonly Guid Participant2Id = Guid.Parse("pp222222-2222-2222-2222-222222222222");
    public static readonly Guid Participant3Id = Guid.Parse("pp333333-3333-3333-3333-333333333333");
    public static readonly Guid Participant4Id = Guid.Parse("pp444444-4444-4444-4444-444444444444");
    public static readonly Guid Participant5Id = Guid.Parse("pp555555-5555-5555-5555-555555555555");

    public static void Seed(ModelBuilder modelBuilder)
    {
        var participants = new[]
        {
            new Participant
            {
                ParticipantId = Participant1Id,
                ContactId = ContactSeeder.Contact6Id,
                TenantId = TenantSeeder.Tenant3Id,
                ParticipantType = "Staff",
                Department = "Operations",
                JobTitle = "Event Coordinator",
                StandardRate = 35.00m,
                Currency = "USD",
                ContractType = "Annual",
                ParticipantStatus = "Active",
                IsActive = true,
                TotalEventsWorked = 15,
                RatingAverage = 4.85m,
                CreatedDate = DateTime.Parse("2024-03-10")
            },
            new Participant
            {
                ParticipantId = Participant2Id,
                ContactId = ContactSeeder.Contact7Id,
                TenantId = TenantSeeder.Tenant4Id,
                ParticipantType = "Artist",
                CompanyId = CompanySeeder.Company6Id,
                StageName = "Taylor S.",
                Specialty = "Pop Music",
                StandardRate = 50000.00m,
                Currency = "USD",
                ContractType = "PerEvent",
                ParticipantStatus = "Active",
                IsActive = true,
                TotalEventsWorked = 3,
                RatingAverage = 4.95m,
                CreatedDate = DateTime.Parse("2024-04-15")
            },
            new Participant
            {
                ParticipantId = Participant3Id,
                ContactId = ContactSeeder.Contact4Id,
                TenantId = TenantSeeder.Tenant3Id,
                ParticipantType = "Vendor",
                CompanyId = CompanySeeder.Company4Id,
                Specialty = "Catering Services",
                StandardRate = 5000.00m,
                Currency = "USD",
                ContractType = "Contract",
                ParticipantStatus = "Active",
                IsActive = true,
                TotalEventsWorked = 8,
                RatingAverage = 4.70m,
                CreatedDate = DateTime.Parse("2024-03-20")
            },
            new Participant
            {
                ParticipantId = Participant4Id,
                ContactId = ContactSeeder.Contact5Id,
                TenantId = TenantSeeder.Tenant3Id,
                ParticipantType = "Vendor",
                CompanyId = CompanySeeder.Company5Id,
                Specialty = "Audio Visual Equipment",
                StandardRate = 3500.00m,
                Currency = "USD",
                ContractType = "PerEvent",
                ParticipantStatus = "Active",
                IsActive = true,
                TotalEventsWorked = 6,
                RatingAverage = 4.60m,
                CreatedDate = DateTime.Parse("2024-04-01")
            },
            new Participant
            {
                ParticipantId = Participant5Id,
                ContactId = ContactSeeder.Contact1Id,
                TenantId = TenantSeeder.Tenant1Id,
                ParticipantType = "Staff",
                Department = "Guest Services",
                JobTitle = "Guest Relations Manager",
                StandardRate = 45.00m,
                Currency = "USD",
                ContractType = "Annual",
                ParticipantStatus = "Active",
                IsActive = true,
                TotalEventsWorked = 20,
                RatingAverage = 4.90m,
                CreatedDate = DateTime.Parse("2024-01-20")
            }
        };

        modelBuilder.Entity<Participant>().HasData(participants);

        // Seed EventParticipants
        var eventParticipants = new[]
        {
            new EventParticipant
            {
                EventParticipantId = Guid.NewGuid(),
                EventId = EventSeeder.Event4Id,
                ParticipantId = Participant1Id,
                TenantId = TenantSeeder.Tenant3Id,
                RoleOnEvent = "Event Coordinator",
                AssignmentStartDate = DateTime.Parse("2025-03-19"),
                AssignmentEndDate = DateTime.Parse("2025-03-23"),
                CompensationAmount = 2800.00m,
                CompensationType = "Fixed",
                PaymentStatus = "Pending",
                ParticipationStatus = "Confirmed",
                IsActive = true,
                CreatedDate = DateTime.Parse("2024-11-01")
            },
            new EventParticipant
            {
                EventParticipantId = Guid.NewGuid(),
                EventId = EventSeeder.Event5Id,
                ParticipantId = Participant2Id,
                TenantId = TenantSeeder.Tenant4Id,
                RoleOnEvent = "Headliner",
                AssignmentStartDate = DateTime.Parse("2025-06-15T18:00:00"),
                AssignmentEndDate = DateTime.Parse("2025-06-15T23:30:00"),
                CompensationAmount = 50000.00m,
                CompensationType = "Fixed",
                PaymentStatus = "Deposit Paid",
                ParticipationStatus = "Confirmed",
                IsActive = true,
                CreatedDate = DateTime.Parse("2024-11-15")
            },
            new EventParticipant
            {
                EventParticipantId = Guid.NewGuid(),
                EventId = EventSeeder.Event4Id,
                ParticipantId = Participant3Id,
                TenantId = TenantSeeder.Tenant3Id,
                RoleOnEvent = "Catering Vendor",
                AssignmentStartDate = DateTime.Parse("2025-03-20"),
                AssignmentEndDate = DateTime.Parse("2025-03-22"),
                CompensationAmount = 15000.00m,
                CompensationType = "Fixed",
                PaymentStatus = "Pending",
                ParticipationStatus = "Confirmed",
                IsActive = true,
                CreatedDate = DateTime.Parse("2024-11-05")
            }
        };

        modelBuilder.Entity<EventParticipant>().HasData(eventParticipants);
    }
}
