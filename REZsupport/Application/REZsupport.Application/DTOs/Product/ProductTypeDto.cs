namespace REZsupport.Application.DTOs.Product;

public class ProductTypeDto
{
    public Guid ProductTypeId { get; set; }
    public Guid TenantId { get; set; }
    public string ProductTypeCode { get; set; } = string.Empty;
    public string ProductTypeName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsActive { get; set; }
}
