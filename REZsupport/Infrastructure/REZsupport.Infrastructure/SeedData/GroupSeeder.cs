using Microsoft.EntityFrameworkCore;
using REZsupport.Core.Entities;

namespace REZsupport.Infrastructure.SeedData;

public static class GroupSeeder
{
    public static readonly Guid Group1Id = Guid.Parse("g1111111-1111-1111-1111-111111111111");
    public static readonly Guid Group2Id = Guid.Parse("g2222222-2222-2222-2222-222222222222");
    public static readonly Guid Group3Id = Guid.Parse("g3333333-3333-3333-3333-333333333333");
    public static readonly Guid Group4Id = Guid.Parse("g4444444-4444-4444-4444-444444444444");
    public static readonly Guid Group5Id = Guid.Parse("g5555555-5555-5555-5555-555555555555");

    public static void Seed(ModelBuilder modelBuilder)
    {
        var groups = new[]
        {
            new Group
            {
                GroupId = Group1Id,
                TenantId = TenantSeeder.Tenant1Id,
                GroupType = "Corporate",
                GroupName = "Tech Innovations Executive Team",
                GroupCode = "GRP001",
                Description = "Executive leadership team for annual retreat",
                CompanyId = CompanySeeder.Company1Id,
                PrimaryContactId = ContactSeeder.Contact1Id,
                IsActive = true,
                GroupStatus = "Active",
                TotalMembers = 12,
                TotalBookings = 3,
                CreatedDate = DateTime.Parse("2024-02-01")
            },
            new Group
            {
                GroupId = Group2Id,
                TenantId = TenantSeeder.Tenant1Id,
                GroupType = "Corporate",
                GroupName = "Global Finance Sales Team",
                GroupCode = "GRP002",
                Description = "Regional sales managers conference group",
                CompanyId = CompanySeeder.Company2Id,
                PrimaryContactId = ContactSeeder.Contact2Id,
                IsActive = true,
                GroupStatus = "Active",
                TotalMembers = 25,
                TotalBookings = 5,
                CreatedDate = DateTime.Parse("2024-02-15")
            },
            new Group
            {
                GroupId = Group3Id,
                TenantId = TenantSeeder.Tenant2Id,
                GroupType = "Family",
                GroupName = "Garcia Family Reunion",
                GroupCode = "GRP003",
                Description = "Annual family reunion",
                PrimaryContactId = ContactSeeder.Contact3Id,
                IsActive = true,
                GroupStatus = "Active",
                TotalMembers = 8,
                TotalBookings = 1,
                CreatedDate = DateTime.Parse("2024-03-10")
            },
            new Group
            {
                GroupId = Group4Id,
                TenantId = TenantSeeder.Tenant3Id,
                GroupType = "Corporate",
                GroupName = "Healthcare Partners Conference Attendees",
                GroupCode = "GRP004",
                Description = "Medical conference delegation",
                CompanyId = CompanySeeder.Company3Id,
                PrimaryContactId = ContactSeeder.Contact4Id,
                IsActive = true,
                GroupStatus = "Active",
                TotalMembers = 45,
                TotalBookings = 2,
                CreatedDate = DateTime.Parse("2024-03-20")
            },
            new Group
            {
                GroupId = Group5Id,
                TenantId = TenantSeeder.Tenant5Id,
                GroupType = "Tour",
                GroupName = "Rocky Mountain Adventure Group",
                GroupCode = "GRP005",
                Description = "Adventure tour group",
                PrimaryContactId = ContactSeeder.Contact8Id,
                IsActive = true,
                GroupStatus = "Active",
                TotalMembers = 15,
                TotalBookings = 1,
                CreatedDate = DateTime.Parse("2024-06-01")
            }
        };

        modelBuilder.Entity<Group>().HasData(groups);

        // Seed GroupMembers
        var groupMembers = new[]
        {
            new GroupMember
            {
                GroupMemberId = Guid.NewGuid(),
                GroupId = Group1Id,
                ContactId = ContactSeeder.Contact1Id,
                TenantId = TenantSeeder.Tenant1Id,
                RoleInGroup = "Group Leader",
                IsPrimaryContact = true,
                JoinDate = DateTime.Parse("2024-02-01"),
                IsActive = true,
                CreatedDate = DateTime.Parse("2024-02-01")
            },
            new GroupMember
            {
                GroupMemberId = Guid.NewGuid(),
                GroupId = Group2Id,
                ContactId = ContactSeeder.Contact2Id,
                TenantId = TenantSeeder.Tenant1Id,
                RoleInGroup = "Organizer",
                IsPrimaryContact = true,
                JoinDate = DateTime.Parse("2024-02-15"),
                IsActive = true,
                CreatedDate = DateTime.Parse("2024-02-15")
            },
            new GroupMember
            {
                GroupMemberId = Guid.NewGuid(),
                GroupId = Group3Id,
                ContactId = ContactSeeder.Contact3Id,
                TenantId = TenantSeeder.Tenant2Id,
                RoleInGroup = "Organizer",
                IsPrimaryContact = true,
                JoinDate = DateTime.Parse("2024-03-10"),
                IsActive = true,
                CreatedDate = DateTime.Parse("2024-03-10")
            },
            new GroupMember
            {
                GroupMemberId = Guid.NewGuid(),
                GroupId = Group4Id,
                ContactId = ContactSeeder.Contact4Id,
                TenantId = TenantSeeder.Tenant3Id,
                RoleInGroup = "Conference Coordinator",
                IsPrimaryContact = true,
                JoinDate = DateTime.Parse("2024-03-20"),
                IsActive = true,
                CreatedDate = DateTime.Parse("2024-03-20")
            },
            new GroupMember
            {
                GroupMemberId = Guid.NewGuid(),
                GroupId = Group5Id,
                ContactId = ContactSeeder.Contact8Id,
                TenantId = TenantSeeder.Tenant5Id,
                RoleInGroup = "Tour Leader",
                IsPrimaryContact = true,
                JoinDate = DateTime.Parse("2024-06-01"),
                IsActive = true,
                CreatedDate = DateTime.Parse("2024-06-01")
            }
        };

        modelBuilder.Entity<GroupMember>().HasData(groupMembers);
    }
}
