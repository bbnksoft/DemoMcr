namespace REZsupport.Application.DTOs.Tenant;
/// <summary>
/// Data Transfer Object for creating a new tenant.
/// </summary>
public class CreateTenantDto
{
    /// <summary>
    /// Gets or sets the unique code identifying the tenant.
    /// </summary>
    public string TenantCode { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the name of the tenant's company.
    /// </summary>
    public string CompanyName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the contact email for the tenant.
    /// </summary>
    public string? ContactEmail { get; set; }

    /// <summary>
    /// Gets or sets the contact phone number for the tenant.
    /// </summary>
    public string? ContactPhone { get; set; }

    /// <summary>
    /// Gets or sets the subscription tier of the tenant.
    /// </summary>
    public string? SubscriptionTier { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the tenant is active.
    /// </summary>
    public bool? IsActive { get; set; }

    /// <summary>
    /// Gets or sets the maximum number of users allowed for the tenant.
    /// </summary>
    public int? MaxUsers { get; set; }

    /// <summary>
    /// Gets or sets the maximum number of events allowed for the tenant.
    /// </summary>
    public int? MaxEvents { get; set; }

    /// <summary>
    /// Gets or sets the storage quota in GB for the tenant.
    /// </summary>
    public int? StorageQuotaGB { get; set; }

    /// <summary>
    /// Gets or sets the Primary vertical of the tenant.
    /// </summary>
    public string? PrimaryVertical { get; set; }

    /// <summary>
    /// Gets or sets the extended attributes for the tenant.
    /// </summary>
    public string? ExtendedAttributes { get; set; }

    /// <summary>
    /// Gets or sets the brand color for the tenant's branding.
    /// </summary>
    public string? BrandColor { get; set; }

    /// <summary>
    /// Gets or sets the time zone of the tenant.
    /// </summary>
    public string? TimeZone { get; set; }

    /// <summary>
    /// Gets or sets the currency used by the tenant.
    /// </summary>
    public string? Currency { get; set; }
}
