namespace REZsupport.Application.DTOs.Venue;

public class VenueListDto
{
    public Guid VenueId { get; set; }
    public string VenueCode { get; set; } = string.Empty;
    public string VenueName { get; set; } = string.Empty;
    public string? VenueType { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public int? TotalCapacity { get; set; }
    public bool IsActive { get; set; }
}
