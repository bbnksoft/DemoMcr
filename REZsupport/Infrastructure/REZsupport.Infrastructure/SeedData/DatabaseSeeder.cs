using Microsoft.EntityFrameworkCore;

namespace REZsupport.Infrastructure.SeedData;

public static class DatabaseSeeder
{
    public static void SeedAll(ModelBuilder modelBuilder)
    {
        TenantSeeder.Seed(modelBuilder);
        UserSeeder.Seed(modelBuilder);
        CompanySeeder.Seed(modelBuilder);
        ContactSeeder.Seed(modelBuilder);
        GroupSeeder.Seed(modelBuilder);
        VenueSeeder.Seed(modelBuilder);
        ProductSeeder.Seed(modelBuilder);
        MerchandiseSeeder.Seed(modelBuilder);
        EventSeeder.Seed(modelBuilder);
        ParticipantSeeder.Seed(modelBuilder);
        ReservationSeeder.Seed(modelBuilder);
        PaymentSeeder.Seed(modelBuilder);
        NotificationSeeder.Seed(modelBuilder);
    }
}
