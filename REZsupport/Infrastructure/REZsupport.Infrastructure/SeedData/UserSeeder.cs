using Microsoft.EntityFrameworkCore;
using REZsupport.Core.Entities;

namespace REZsupport.Infrastructure.SeedData;

public static class UserSeeder
{
    public static readonly Guid Admin1Id = Guid.Parse("a1111111-1111-1111-1111-111111111111");
    public static readonly Guid Admin2Id = Guid.Parse("a2222222-2222-2222-2222-222222222222");
    public static readonly Guid User1Id = Guid.Parse("b1111111-1111-1111-1111-111111111111");
    public static readonly Guid User2Id = Guid.Parse("b2222222-2222-2222-2222-222222222222");
    public static readonly Guid User3Id = Guid.Parse("b3333333-3333-3333-3333-333333333333");

    public static readonly Guid AdminRoleId = Guid.Parse("r1111111-1111-1111-1111-111111111111");
    public static readonly Guid ManagerRoleId = Guid.Parse("r2222222-2222-2222-2222-222222222222");
    public static readonly Guid UserRoleId = Guid.Parse("r3333333-3333-3333-3333-333333333333");

    public static void Seed(ModelBuilder modelBuilder)
    {
        var users = new[]
        {
            new User
            {
                UserId = Admin1Id,
                TenantId = TenantSeeder.Tenant1Id,
                Username = "admin@oceanic",
                Email = "admin@oceaniccruises.com",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEDummyHashForSeedData1234567890==",
                FirstName = "James",
                LastName = "Wilson",
                DisplayName = "James Wilson",
                IsActive = true,
                CreatedDate = DateTime.Parse("2024-01-15")
            },
            new User
            {
                UserId = Admin2Id,
                TenantId = TenantSeeder.Tenant2Id,
                Username = "admin@grand",
                Email = "admin@grandhotels.com",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEDummyHashForSeedData1234567891==",
                FirstName = "Sarah",
                LastName = "Johnson",
                DisplayName = "Sarah Johnson",
                IsActive = true,
                CreatedDate = DateTime.Parse("2024-02-01")
            },
            new User
            {
                UserId = User1Id,
                TenantId = TenantSeeder.Tenant1Id,
                Username = "manager@oceanic",
                Email = "manager@oceaniccruises.com",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEDummyHashForSeedData1234567892==",
                FirstName = "Michael",
                LastName = "Chen",
                DisplayName = "Michael Chen",
                IsActive = true,
                CreatedDate = DateTime.Parse("2024-01-20")
            },
            new User
            {
                UserId = User2Id,
                TenantId = TenantSeeder.Tenant2Id,
                Username = "agent@grand",
                Email = "agent@grandhotels.com",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEDummyHashForSeedData1234567893==",
                FirstName = "Emily",
                LastName = "Martinez",
                DisplayName = "Emily Martinez",
                IsActive = true,
                CreatedDate = DateTime.Parse("2024-02-05")
            },
            new User
            {
                UserId = User3Id,
                TenantId = TenantSeeder.Tenant3Id,
                Username = "coordinator@global",
                Email = "coordinator@globalconferences.com",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEDummyHashForSeedData1234567894==",
                FirstName = "David",
                LastName = "Lee",
                DisplayName = "David Lee",
                IsActive = true,
                CreatedDate = DateTime.Parse("2024-03-10")
            }
        };

        modelBuilder.Entity<User>().HasData(users);

        // Seed Roles
        var roles = new[]
        {
            new Role
            {
                RoleId = AdminRoleId,
                TenantId = TenantSeeder.Tenant1Id,
                RoleName = "Administrator",
                Description = "Full system access",
                IsSystemRole = true,
                CreatedDate = DateTime.Parse("2024-01-15")
            },
            new Role
            {
                RoleId = ManagerRoleId,
                TenantId = TenantSeeder.Tenant1Id,
                RoleName = "Manager",
                Description = "Manage events and bookings",
                IsSystemRole = false,
                CreatedDate = DateTime.Parse("2024-01-15")
            },
            new Role
            {
                RoleId = UserRoleId,
                TenantId = TenantSeeder.Tenant2Id,
                RoleName = "Agent",
                Description = "Booking agent",
                IsSystemRole = false,
                CreatedDate = DateTime.Parse("2024-02-01")
            }
        };

        modelBuilder.Entity<Role>().HasData(roles);

        // Seed UserRoles
        var userRoles = new[]
        {
            new UserRole
            {
                UserRoleId = Guid.NewGuid(),
                UserId = Admin1Id,
                RoleId = AdminRoleId,
                AssignedDate = DateTime.Parse("2024-01-15")
            },
            new UserRole
            {
                UserRoleId = Guid.NewGuid(),
                UserId = User1Id,
                RoleId = ManagerRoleId,
                AssignedDate = DateTime.Parse("2024-01-20")
            },
            new UserRole
            {
                UserRoleId = Guid.NewGuid(),
                UserId = User2Id,
                RoleId = UserRoleId,
                AssignedDate = DateTime.Parse("2024-02-05")
            }
        };

        modelBuilder.Entity<UserRole>().HasData(userRoles);
    }
}
