namespace REZsupport.Application.DTOs.Venue;

public class CreateVenueDto
{
    public Guid TenantId { get; set; }
    public string VenueCode { get; set; } = string.Empty;
    public string VenueName { get; set; } = string.Empty;
    public string? VenueType { get; set; }
    public string? Description { get; set; }
    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string? City { get; set; }
    public string? StateProvince { get; set; }
    public string? Country { get; set; }
    public string? PostalCode { get; set; }
    public decimal? Latitude { get; set; }
    public decimal? Longitude { get; set; }
    public int? TotalCapacity { get; set; }
    public string? ContactPhone { get; set; }
    public string? ContactEmail { get; set; }
}