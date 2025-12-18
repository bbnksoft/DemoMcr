using Microsoft.EntityFrameworkCore;
using REZsupport.Core.Entities;

namespace REZsupport.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // Multi-Tenant Foundation
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantSetting> TenantSettings { get; set; }
    public DbSet<TenantFeature> TenantFeatures { get; set; }

    // User Management
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }

    // Companies & Contacts
    public DbSet<Company> Companies { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<GroupMember> GroupMembers { get; set; }

    // Generalized Inventory Hierarchy
    public DbSet<Venue> Venues { get; set; }
    public DbSet<Section> Sections { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<Product> Products { get; set; }

    // Merchandise Catalog
    public DbSet<MerchandiseCategory> MerchandiseCategories { get; set; }
    public DbSet<Merchandise> Merchandises { get; set; }
    public DbSet<MerchandiseVariant> MerchandiseVariants { get; set; }

    // Events
    public DbSet<Event> Events { get; set; }
    public DbSet<EventInventory> EventInventories { get; set; }
    public DbSet<EventMerchandise> EventMerchandises { get; set; }

    // Participants
    public DbSet<Participant> Participants { get; set; }
    public DbSet<EventParticipant> EventParticipants { get; set; }

    // Reservations & Bookings
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<ReservationProduct> ReservationProducts { get; set; }
    public DbSet<ReservationGuest> ReservationGuests { get; set; }
    public DbSet<ReservationMerchandise> ReservationMerchandises { get; set; }

    // Payments & Promo Codes
    public DbSet<Payment> Payments { get; set; }
    public DbSet<PromotionalCode> PromotionalCodes { get; set; }

    // Audit & Notifications
    public DbSet<AuditLog> AuditLogs { get; set; }
    public DbSet<NotificationTemplate> NotificationTemplates { get; set; }
    public DbSet<NotificationQueue> NotificationQueues { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure unique constraints
        modelBuilder.Entity<Tenant>()
            .HasIndex(t => t.TenantCode)
            .IsUnique();

        modelBuilder.Entity<TenantSetting>()
            .HasIndex(ts => new { ts.TenantId, ts.SettingKey })
            .IsUnique();

        modelBuilder.Entity<User>()
            .HasIndex(u => new { u.TenantId, u.Email })
            .IsUnique();

        modelBuilder.Entity<Role>()
            .HasIndex(r => new { r.TenantId, r.RoleName })
            .IsUnique();

        modelBuilder.Entity<UserRole>()
            .HasIndex(ur => new { ur.UserId, ur.RoleId })
            .IsUnique();

        modelBuilder.Entity<Company>()
            .HasIndex(c => new { c.TenantId, c.CompanyCode })
            .IsUnique();

        modelBuilder.Entity<Contact>()
            .HasIndex(c => new { c.TenantId, c.Email })
            .IsUnique();

        modelBuilder.Entity<GroupMember>()
            .HasIndex(gm => new { gm.GroupId, gm.ContactId })
            .IsUnique();

        modelBuilder.Entity<Venue>()
            .HasIndex(v => new { v.TenantId, v.VenueCode })
            .IsUnique();

        modelBuilder.Entity<Section>()
            .HasIndex(s => new { s.VenueId, s.SectionCode })
            .IsUnique();

        modelBuilder.Entity<ProductType>()
            .HasIndex(pt => new { pt.TenantId, pt.ProductTypeCode })
            .IsUnique();

        modelBuilder.Entity<ProductCategory>()
            .HasIndex(pc => new { pc.TenantId, pc.VenueId, pc.CategoryCode })
            .IsUnique();

        modelBuilder.Entity<Product>()
            .HasIndex(p => new { p.VenueId, p.ProductCode })
            .IsUnique();

        modelBuilder.Entity<MerchandiseCategory>()
            .HasIndex(mc => new { mc.TenantId, mc.CategoryCode })
            .IsUnique();

        modelBuilder.Entity<Merchandise>()
            .HasIndex(m => new { m.TenantId, m.SKU })
            .IsUnique();

        modelBuilder.Entity<MerchandiseVariant>()
            .HasIndex(mv => new { mv.TenantId, mv.VariantSKU })
            .IsUnique();

        modelBuilder.Entity<Event>()
            .HasIndex(e => new { e.TenantId, e.EventCode })
            .IsUnique();

        modelBuilder.Entity<EventInventory>()
            .HasIndex(ei => new { ei.EventId, ei.ProductId })
            .IsUnique();

        modelBuilder.Entity<EventMerchandise>()
            .HasIndex(em => new { em.EventId, em.MerchandiseId })
            .IsUnique();

        modelBuilder.Entity<Participant>()
            .HasIndex(p => p.ContactId)
            .IsUnique();

        modelBuilder.Entity<EventParticipant>()
            .HasIndex(ep => new { ep.EventId, ep.ParticipantId })
            .IsUnique();

        modelBuilder.Entity<Reservation>()
            .HasIndex(r => new { r.TenantId, r.ReservationNumber })
            .IsUnique();

        modelBuilder.Entity<PromotionalCode>()
            .HasIndex(pc => new { pc.TenantId, pc.PromoCode })
            .IsUnique();

        modelBuilder.Entity<NotificationTemplate>()
            .HasIndex(nt => new { nt.TenantId, nt.TemplateCode })
            .IsUnique();

        // Configure cascade delete behaviors where needed
        modelBuilder.Entity<TenantSetting>()
            .HasOne(ts => ts.Tenant)
            .WithMany(t => t.TenantSettings)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<TenantFeature>()
            .HasOne(tf => tf.Tenant)
            .WithMany(t => t.TenantFeatures)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.User)
            .WithMany(u => u.UserRoles)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.Role)
            .WithMany(r => r.UserRoles)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<GroupMember>()
            .HasOne(gm => gm.Group)
            .WithMany(g => g.GroupMembers)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Section>()
            .HasOne(s => s.Venue)
            .WithMany(v => v.Sections)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<EventInventory>()
            .HasOne(ei => ei.Event)
            .WithMany(e => e.EventInventories)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<EventMerchandise>()
            .HasOne(em => em.Event)
            .WithMany(e => e.EventMerchandises)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<EventParticipant>()
            .HasOne(ep => ep.Event)
            .WithMany(e => e.EventParticipants)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ReservationProduct>()
            .HasOne(rp => rp.Reservation)
            .WithMany(r => r.ReservationProducts)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ReservationGuest>()
            .HasOne(rg => rg.Reservation)
            .WithMany(r => r.ReservationGuests)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ReservationMerchandise>()
            .HasOne(rm => rm.Reservation)
            .WithMany(r => r.ReservationMerchandises)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<MerchandiseVariant>()
            .HasOne(mv => mv.Merchandise)
            .WithMany(m => m.MerchandiseVariants)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Participant>()
            .HasOne(p => p.Contact)
            .WithMany()
            .OnDelete(DeleteBehavior.Cascade);

        // Configure self-referencing relationships
        modelBuilder.Entity<Section>()
            .HasOne(s => s.ParentSection)
            .WithMany(s => s.ChildSections)
            .HasForeignKey(s => s.ParentSectionId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<ProductCategory>()
            .HasOne(pc => pc.ParentCategory)
            .WithMany(pc => pc.ChildCategories)
            .HasForeignKey(pc => pc.ParentCategoryId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<MerchandiseCategory>()
            .HasOne(mc => mc.ParentCategory)
            .WithMany(mc => mc.ChildCategories)
            .HasForeignKey(mc => mc.ParentCategoryId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Product>()
            .HasOne(p => p.ConnectsToProduct)
            .WithMany()
            .HasForeignKey(p => p.ConnectsToProductId)
            .OnDelete(DeleteBehavior.NoAction);

        // Configure Company PrimaryContact relationship to avoid cycles
        modelBuilder.Entity<Company>()
            .HasOne(c => c.PrimaryContact)
            .WithMany()
            .HasForeignKey(c => c.PrimaryContactId)
            .OnDelete(DeleteBehavior.NoAction);

        // Configure Group PrimaryContact relationship
        modelBuilder.Entity<Group>()
            .HasOne(g => g.PrimaryContact)
            .WithMany()
            .HasForeignKey(g => g.PrimaryContactId)
            .OnDelete(DeleteBehavior.NoAction);

        // Configure Contact relationships to avoid multiple cascade paths
        modelBuilder.Entity<Contact>()
            .HasOne(c => c.Company)
            .WithMany(co => co.Contacts)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Contact>()
            .HasOne(c => c.LinkedUser)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);

        // Configure additional indexes for performance
        modelBuilder.Entity<Tenant>().HasIndex(t => t.IsActive);
        modelBuilder.Entity<User>().HasIndex(u => u.Email);
        modelBuilder.Entity<Company>().HasIndex(c => c.CompanyName);
        modelBuilder.Entity<Company>().HasIndex(c => c.CompanyType);
        modelBuilder.Entity<Company>().HasIndex(c => c.AccountStatus);
        modelBuilder.Entity<Contact>().HasIndex(c => c.LastName);
        modelBuilder.Entity<Contact>().HasIndex(c => c.ContactType);
        modelBuilder.Entity<Venue>().HasIndex(v => v.VenueType);
        modelBuilder.Entity<Event>().HasIndex(e => e.StartDate);
        modelBuilder.Entity<Event>().HasIndex(e => e.Status);
        modelBuilder.Entity<EventInventory>().HasIndex(ei => ei.ReservationStatus);
        modelBuilder.Entity<Reservation>().HasIndex(r => r.ReservationStatus);
        modelBuilder.Entity<AuditLog>().HasIndex(al => al.EntityType);
        modelBuilder.Entity<AuditLog>().HasIndex(al => al.EventTimestamp);
        modelBuilder.Entity<NotificationQueue>().HasIndex(nq => nq.Status);


        // See SEED_DATA_SUMMARY.md for complete details
        SeedData.DatabaseSeeder.SeedAll(modelBuilder);
    }
}
