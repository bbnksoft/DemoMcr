namespace Inventory.Application.Responses.Venues;

/// <summary>
/// Represents the response returned after updating a venue, including the venue's unique identifier and details.
/// </summary>
public class UpdateVenueResponse : CreateVenueResponse
{
    /// <summary>
    /// The unique identifier of the venue.
    /// </summary>
    public Guid VenueId { get; set; }
}
