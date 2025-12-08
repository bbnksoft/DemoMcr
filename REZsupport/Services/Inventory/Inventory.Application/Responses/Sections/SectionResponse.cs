namespace Inventory.Application.Responses.Sections;

/// <summary>
/// Represents a response model containing section details and related data.
/// </summary>
public class SectionResponse
{
    /// <summary>
    /// Unique identifier for the section.
    /// </summary>
    public Guid SectionId { get; set; }

    /// <summary>
    /// Unique identifier for the venue associated with the section.
    /// </summary>
    public Guid VenueId { get; set; }

    /// <summary>
    /// Unique identifier for the tenant.
    /// </summary>
    public Guid TenantId { get; set; }

    /// <summary>
    /// Name of the section.
    /// </summary>
    public string SectionName { get; set; } = string.Empty;

    /// <summary>
    /// Optional code for the section.
    /// </summary>
    public string? SectionCode { get; set; }

    /// <summary>
    /// Number assigned to the section.
    /// </summary>
    public int SectionNumber { get; set; }

    /// <summary>
    /// Optional type of the section.
    /// </summary>
    public string? SectionType { get; set; }

    /// <summary>
    /// Status of the section.
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// Capacity of the section.
    /// </summary>
    public int Capacity { get; set; }

    /// <summary>
    /// Total number of products in the section.
    /// </summary>
    public int TotalProducts { get; set; }

    /// <summary>
    /// Optional description of the section.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Date and time when the section was created.
    /// </summary>
    public DateTime CreatedDate { get; set; }

    // Related Data

    /// <summary>
    /// Optional name of the venue associated with the section.
    /// </summary>
    public string? VenueName { get; set; }

    /// <summary>
    /// Number of available products in the section.
    /// </summary>
    public int AvailableProducts { get; set; }
}
