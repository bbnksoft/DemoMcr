using Microsoft.EntityFrameworkCore;
using REZsupport.Core.Entities;

namespace REZsupport.Infrastructure.SeedData;

public static class TenantSeeder
{
    public static readonly Guid Tenant1Id = Guid.Parse("11111111-1111-1111-1111-111111111111");
    public static readonly Guid Tenant2Id = Guid.Parse("22222222-2222-2222-2222-222222222222");
    public static readonly Guid Tenant3Id = Guid.Parse("33333333-3333-3333-3333-333333333333");
    public static readonly Guid Tenant4Id = Guid.Parse("44444444-4444-4444-4444-444444444444");
    public static readonly Guid Tenant5Id = Guid.Parse("55555555-5555-5555-5555-555555555555");

    public static void Seed(ModelBuilder modelBuilder)
    {
        var tenants = new[]
        {
            new Tenant
            {
                TenantId = Tenant1Id,
                TenantCode = "CRUISE001",
                CompanyName = "Oceanic Cruises Inc.",
                ContactEmail = "admin@oceaniccruises.com",
                ContactPhone = "+1-555-0101",
                SubscriptionTier = "Enterprise",
                IsActive = true,
                MaxUsers = 100,
                MaxEvents = 500,
                StorageQuotaGB = 100,
                PrimaryVertical = "CRUISE",
                CreatedDate = DateTime.Parse("2024-01-15"),
                ModifiedDate = DateTime.Parse("2024-01-15")
            },
            new Tenant
            {
                TenantId = Tenant2Id,
                TenantCode = "HOTEL001",
                CompanyName = "Grand Hotels Group",
                ContactEmail = "contact@grandhotels.com",
                ContactPhone = "+1-555-0202",
                SubscriptionTier = "Professional",
                IsActive = true,
                MaxUsers = 50,
                MaxEvents = 200,
                StorageQuotaGB = 50,
                PrimaryVertical = "HOTEL",
                CreatedDate = DateTime.Parse("2024-02-01"),
                ModifiedDate = DateTime.Parse("2024-02-01")
            },
            new Tenant
            {
                TenantId = Tenant3Id,
                TenantCode = "CONF001",
                CompanyName = "Global Conference Centers",
                ContactEmail = "info@globalconferences.com",
                ContactPhone = "+1-555-0303",
                SubscriptionTier = "Professional",
                IsActive = true,
                MaxUsers = 75,
                MaxEvents = 300,
                StorageQuotaGB = 75,
                PrimaryVertical = "CONFERENCE",
                CreatedDate = DateTime.Parse("2024-03-10"),
                ModifiedDate = DateTime.Parse("2024-03-10")
            },
            new Tenant
            {
                TenantId = Tenant4Id,
                TenantCode = "CONCERT001",
                CompanyName = "Live Events Productions",
                ContactEmail = "bookings@liveevents.com",
                ContactPhone = "+1-555-0404",
                SubscriptionTier = "Basic",
                IsActive = true,
                MaxUsers = 25,
                MaxEvents = 100,
                StorageQuotaGB = 25,
                PrimaryVertical = "CONCERT",
                CreatedDate = DateTime.Parse("2024-04-05"),
                ModifiedDate = DateTime.Parse("2024-04-05")
            },
            new Tenant
            {
                TenantId = Tenant5Id,
                TenantCode = "TOUR001",
                CompanyName = "Adventure Tours International",
                ContactEmail = "support@adventuretours.com",
                ContactPhone = "+1-555-0505",
                SubscriptionTier = "Professional",
                IsActive = true,
                MaxUsers = 40,
                MaxEvents = 250,
                StorageQuotaGB = 40,
                PrimaryVertical = "TOUR",
                CreatedDate = DateTime.Parse("2024-05-20"),
                ModifiedDate = DateTime.Parse("2024-05-20")
            }
        };

        modelBuilder.Entity<Tenant>().HasData(tenants);

        // Seed TenantSettings
        var settings = new List<TenantSetting>();
        foreach (var tenant in tenants)
        {
            settings.AddRange(new[]
            {
                new TenantSetting
                {
                    SettingId = Guid.NewGuid(),
                    TenantId = tenant.TenantId,
                    SettingKey = "DefaultCurrency",
                    SettingValue = "USD",
                    SettingType = "String",
                    Category = "Financial",
                    CreatedDate = tenant.CreatedDate
                },
                new TenantSetting
                {
                    SettingId = Guid.NewGuid(),
                    TenantId = tenant.TenantId,
                    SettingKey = "TimeZone",
                    SettingValue = "America/New_York",
                    SettingType = "String",
                    Category = "General",
                    CreatedDate = tenant.CreatedDate
                }
            });
        }
        modelBuilder.Entity<TenantSetting>().HasData(settings);

        // Seed TenantFeatures
        var features = new List<TenantFeature>();
        foreach (var tenant in tenants)
        {
            features.AddRange(new[]
            {
                new TenantFeature
                {
                    FeatureId = Guid.NewGuid(),
                    TenantId = tenant.TenantId,
                    FeatureCode = "ONLINE_BOOKING",
                    IsEnabled = true,
                    CreatedDate = tenant.CreatedDate
                },
                new TenantFeature
                {
                    FeatureId = Guid.NewGuid(),
                    TenantId = tenant.TenantId,
                    FeatureCode = "MOBILE_APP",
                    IsEnabled = tenant.SubscriptionTier != "Basic",
                    CreatedDate = tenant.CreatedDate
                }
            });
        }
        modelBuilder.Entity<TenantFeature>().HasData(features);
    }
}
