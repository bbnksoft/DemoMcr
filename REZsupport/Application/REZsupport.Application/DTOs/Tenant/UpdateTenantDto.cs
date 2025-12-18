namespace REZsupport.Application.DTOs.Tenant;

/// <summary>
/// Data Transfer Object for updating tenant information.
/// </summary>
public class UpdateTenantDto
{
    /// <summary>
    /// Gets or sets the name of the tenant.
    /// </summary>
    public string TenantName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the domain associated with the tenant.
    /// </summary>
    public string? TenantDomain { get; set; }

    /// <summary>
    /// Gets or sets the contact email address for the tenant.
    /// </summary>
    public string? ContactEmail { get; set; }

    /// <summary>
    /// Gets or sets the contact phone number for the tenant.
    /// </summary>
    public string? ContactPhone { get; set; }

    /// <summary>
    /// Gets or sets the URL of the tenant's logo.
    /// </summary>
    public string? LogoUrl { get; set; }

    /// <summary>
    /// Gets or sets the primary color for the tenant's branding.
    /// </summary>
    public string? PrimaryColor { get; set; }

    /// <summary>
    /// Gets or sets the secondary color for the tenant's branding.
    /// </summary>
    public string? SecondaryColor { get; set; }

    /// <summary>
    /// Gets or sets the time zone of the tenant.
    /// </summary>
    public string? TimeZone { get; set; }

    /// <summary>
    /// Gets or sets the currency used by the tenant.
    /// </summary>
    public string? Currency { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the tenant is active.
    /// </summary>
    public bool IsActive { get; set; }
}
