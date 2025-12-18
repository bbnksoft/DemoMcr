namespace REZsupport.Application.DTOs.Tenant;

/// <summary>
/// Data Transfer Object representing a tenant in the system.
/// </summary>
public class TenantDto
{
    /// <summary>
    /// Gets or sets the unique identifier for the tenant.
    /// </summary>
    public Guid TenantId { get; set; }

    /// <summary>
    /// Gets or sets the code that uniquely identifies the tenant.
    /// </summary>
    public string TenantCode { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the name of the tenant.
    /// </summary>
    public string TenantName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the domain associated with the tenant.
    /// </summary>
    public string? TenantDomain { get; set; }

    /// <summary>
    /// Gets or sets the business vertical of the tenant.
    /// </summary>
    public string? BusinessVertical { get; set; }

    /// <summary>
    /// Gets or sets the contact email address for the tenant.
    /// </summary>
    public string? ContactEmail { get; set; }

    /// <summary>
    /// Gets or sets the contact phone number for the tenant.
    /// </summary>
    public string? ContactPhone { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the tenant is active.
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the tenant was created.
    /// </summary>
    public DateTime CreatedDate { get; set; }
}
