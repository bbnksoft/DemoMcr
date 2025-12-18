namespace REZsupport.Application.DTOs.Tenant;
/// <summary>
/// Data Transfer Object representing a feature assigned to a tenant.
/// </summary>
public class TenantFeatureDto
{
    /// <summary>
    /// Gets or sets the unique identifier of the feature.
    /// </summary>
    public Guid FeatureId { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the tenant.
    /// </summary>
    public Guid TenantId { get; set; }

    /// <summary>
    /// Gets or sets the name of the feature.
    /// </summary>
    public string FeatureName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a value indicating whether the feature is enabled for the tenant.
    /// </summary>
    public bool IsEnabled { get; set; }

    /// <summary>
    /// Gets or sets the date when the feature was enabled for the tenant, if applicable.
    /// </summary>
    public DateTime? EnabledDate { get; set; }
}
