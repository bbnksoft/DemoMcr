namespace REZsupport.Application.DTOs.Tenant;
/// <summary>
/// Data Transfer Object representing a tenant setting.
/// </summary>
public class TenantSettingDto
{
    /// <summary>
    /// Gets or sets the unique identifier for the setting.
    /// </summary>
    public Guid SettingId { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier for the tenant.
    /// </summary>
    public Guid TenantId { get; set; }

    /// <summary>
    /// Gets or sets the key of the setting.
    /// </summary>
    public string SettingKey { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the value of the setting.
    /// </summary>
    public string? SettingValue { get; set; }

    /// <summary>
    /// Gets or sets the data type of the setting value.
    /// </summary>
    public string? DataType { get; set; }
}
