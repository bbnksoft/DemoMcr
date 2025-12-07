namespace Inventory.Application.Responses.Venues;
public class UpdateVenueResponse
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? ZipCode { get; set; }
    public string? Country { get; set; }
    public int Capacity { get; set; }
    public bool IsActive { get; set; }
}
