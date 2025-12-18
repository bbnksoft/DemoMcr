using Microsoft.EntityFrameworkCore;
using REZsupport.Core.Entities;

namespace REZsupport.Infrastructure.SeedData;

public static class ContactSeeder
{
    public static readonly Guid Contact1Id = Guid.Parse("d1111111-1111-1111-1111-111111111111");
    public static readonly Guid Contact2Id = Guid.Parse("d2222222-2222-2222-2222-222222222222");
    public static readonly Guid Contact3Id = Guid.Parse("d3333333-3333-3333-3333-333333333333");
    public static readonly Guid Contact4Id = Guid.Parse("d4444444-4444-4444-4444-444444444444");
    public static readonly Guid Contact5Id = Guid.Parse("d5555555-5555-5555-5555-555555555555");
    public static readonly Guid Contact6Id = Guid.Parse("d6666666-6666-6666-6666-666666666666");
    public static readonly Guid Contact7Id = Guid.Parse("d7777777-7777-7777-7777-777777777777");
    public static readonly Guid Contact8Id = Guid.Parse("d8888888-8888-8888-8888-888888888888");

    public static void Seed(ModelBuilder modelBuilder)
    {
        var contacts = new[]
        {
            new Contact
            {
                ContactId = Contact1Id,
                TenantId = TenantSeeder.Tenant1Id,
                CompanyId = CompanySeeder.Company1Id,
                ContactCode = "CNT001",
                ContactType = "Corporate",
                FirstName = "John",
                LastName = "Anderson",
                Email = "john.anderson@techinnovations.com",
                Phone = "+1-555-2001",
                JobTitle = "Event Manager",
                Department = "Corporate Events",
                IsPrimaryContact = true,
                CustomerStatus = "Active",
                CustomerSince = DateTime.Parse("2024-01-20"),
                TotalBookings = 8,
                LifetimeValue = 65000.00m,
                MarketingOptIn = true,
                AddressLine1 = "123 Innovation Drive",
                City = "San Francisco",
                StateProvince = "CA",
                PostalCode = "94105",
                Country = "USA",
                CreatedDate = DateTime.Parse("2024-01-20")
            },
            new Contact
            {
                ContactId = Contact2Id,
                TenantId = TenantSeeder.Tenant1Id,
                CompanyId = CompanySeeder.Company2Id,
                ContactCode = "CNT002",
                ContactType = "Corporate",
                FirstName = "Lisa",
                LastName = "Thompson",
                Email = "lisa.thompson@globalfinance.com",
                Phone = "+1-555-2002",
                JobTitle = "Senior VP Events",
                Department = "Marketing",
                IsPrimaryContact = true,
                CustomerStatus = "Active",
                CustomerSince = DateTime.Parse("2024-02-01"),
                TotalBookings = 12,
                LifetimeValue = 180000.00m,
                MarketingOptIn = true,
                AddressLine1 = "456 Wall Street",
                City = "New York",
                StateProvince = "NY",
                PostalCode = "10005",
                Country = "USA",
                CreatedDate = DateTime.Parse("2024-02-01")
            },
            new Contact
            {
                ContactId = Contact3Id,
                TenantId = TenantSeeder.Tenant1Id,
                ContactType = "Individual",
                FirstName = "Robert",
                LastName = "Garcia",
                Email = "robert.garcia@email.com",
                Phone = "+1-555-2003",
                PreferredContactMethod = "Email",
                DateOfBirth = DateTime.Parse("1985-06-15"),
                Gender = "Male",
                PassportNumber = "US123456789",
                PassportExpiry = DateTime.Parse("2028-06-15"),
                PassportCountry = "USA",
                CustomerStatus = "Active",
                CustomerSince = DateTime.Parse("2024-03-01"),
                TotalBookings = 3,
                LifetimeValue = 12500.00m,
                MarketingOptIn = true,
                AddressLine1 = "789 Ocean View Blvd",
                City = "Miami",
                StateProvince = "FL",
                PostalCode = "33101",
                Country = "USA",
                CreatedDate = DateTime.Parse("2024-03-01")
            },
            new Contact
            {
                ContactId = Contact4Id,
                TenantId = TenantSeeder.Tenant2Id,
                CompanyId = CompanySeeder.Company3Id,
                ContactCode = "CNT004",
                ContactType = "Corporate",
                FirstName = "Maria",
                LastName = "Rodriguez",
                Email = "maria.rodriguez@healthcarepartners.com",
                Phone = "+1-555-2004",
                JobTitle = "Conference Coordinator",
                Department = "Human Resources",
                IsPrimaryContact = true,
                CustomerStatus = "Active",
                CustomerSince = DateTime.Parse("2024-03-15"),
                TotalBookings = 5,
                LifetimeValue = 42000.00m,
                MarketingOptIn = true,
                AddressLine1 = "789 Medical Plaza",
                City = "Chicago",
                StateProvince = "IL",
                PostalCode = "60601",
                Country = "USA",
                CreatedDate = DateTime.Parse("2024-03-15")
            },
            new Contact
            {
                ContactId = Contact5Id,
                TenantId = TenantSeeder.Tenant2Id,
                ContactType = "Individual",
                FirstName = "Jennifer",
                LastName = "White",
                Email = "jennifer.white@email.com",
                Phone = "+1-555-2005",
                PreferredContactMethod = "Phone",
                DateOfBirth = DateTime.Parse("1990-09-22"),
                Gender = "Female",
                CustomerStatus = "Active",
                CustomerSince = DateTime.Parse("2024-04-01"),
                TotalBookings = 2,
                LifetimeValue = 8500.00m,
                MarketingOptIn = false,
                AddressLine1 = "321 Harbor Street",
                City = "Boston",
                StateProvince = "MA",
                PostalCode = "02101",
                Country = "USA",
                CreatedDate = DateTime.Parse("2024-04-01")
            },
            new Contact
            {
                ContactId = Contact6Id,
                TenantId = TenantSeeder.Tenant3Id,
                ContactType = "Staff",
                FirstName = "David",
                LastName = "Brown",
                Email = "david.brown@globalconferences.com",
                Phone = "+1-555-2006",
                JobTitle = "Event Coordinator",
                Department = "Operations",
                CustomerStatus = "Active",
                CustomerSince = DateTime.Parse("2024-03-10"),
                CreatedDate = DateTime.Parse("2024-03-10")
            },
            new Contact
            {
                ContactId = Contact7Id,
                TenantId = TenantSeeder.Tenant4Id,
                ContactType = "Artist",
                FirstName = "Taylor",
                LastName = "Swift",
                Email = "taylor@startalent.com",
                Phone = "+1-555-2007",
                CompanyId = CompanySeeder.Company6Id,
                CustomerStatus = "Active",
                CustomerSince = DateTime.Parse("2024-04-15"),
                CreatedDate = DateTime.Parse("2024-04-15")
            },
            new Contact
            {
                ContactId = Contact8Id,
                TenantId = TenantSeeder.Tenant5Id,
                ContactType = "Individual",
                FirstName = "Christopher",
                LastName = "Davis",
                Email = "chris.davis@email.com",
                Phone = "+1-555-2008",
                PreferredContactMethod = "Email",
                DateOfBirth = DateTime.Parse("1988-12-10"),
                Gender = "Male",
                PassportNumber = "US987654321",
                PassportExpiry = DateTime.Parse("2027-12-10"),
                PassportCountry = "USA",
                CustomerStatus = "Active",
                CustomerSince = DateTime.Parse("2024-05-25"),
                TotalBookings = 1,
                LifetimeValue = 3500.00m,
                MarketingOptIn = true,
                AddressLine1 = "654 Mountain Road",
                City = "Denver",
                StateProvince = "CO",
                PostalCode = "80201",
                Country = "USA",
                CreatedDate = DateTime.Parse("2024-05-25")
            }
        };

        modelBuilder.Entity<Contact>().HasData(contacts);
    }
}
