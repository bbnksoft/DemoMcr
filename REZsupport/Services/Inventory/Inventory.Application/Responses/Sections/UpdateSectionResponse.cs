namespace Inventory.Application.Responses.Sections;

/// <summary>
/// Represents the response data for updating an existing section in a venue.
/// </summary>
public class UpdateSectionResponse : CreateSectionResponse
{
    /// <summary>
    /// Gets or sets the unique identifier of the section.
    /// </summary>
    public Guid SectionId { get; set; }
}
