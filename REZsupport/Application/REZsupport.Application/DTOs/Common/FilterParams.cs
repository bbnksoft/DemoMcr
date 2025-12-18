namespace REZsupport.Application.DTOs.Common;
public class FilterParams
{
    public Guid? TenantId { get; set; }
    public bool? IsActive { get; set; }
    public string? Status { get; set; }
}