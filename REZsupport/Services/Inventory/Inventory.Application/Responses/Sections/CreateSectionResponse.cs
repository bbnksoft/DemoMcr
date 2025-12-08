namespace Inventory.Application.Responses.Sections;

/// <summary>
/// Represents the response data for creating a new section in a venue.
/// </summary>
public class CreateSectionResponse
{
    /// <summary>
    /// Gets or sets the unique identifier of the venue.
    /// </summary>
    public Guid VenueId { get; set; }

    /// <summary>
    /// Gets or sets the name of the section.
    /// </summary>
    public string SectionName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the code of the section.
    /// </summary>
    public string? SectionCode { get; set; }

    /// <summary>
    /// Gets or sets the number of the section.
    /// </summary>
    public int SectionNumber { get; set; }

    /// <summary>
    /// Gets or sets the type of the section.
    /// </summary>
    public string? SectionType { get; set; }

    /// <summary>
    /// Gets or sets the status of the section.
    /// </summary>
    public string Status { get; set; } = "Active";

    /// <summary>
    /// Gets or sets the capacity of the section.
    /// </summary>
    public int Capacity { get; set; }

    /// <summary>
    /// Gets or sets the description of the section.
    /// </summary>
    public string? Description { get; set; }
}
