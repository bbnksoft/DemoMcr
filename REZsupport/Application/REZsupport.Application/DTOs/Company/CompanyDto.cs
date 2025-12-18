namespace REZsupport.Application.DTOs.Company;

public class CompanyDto
{
    public Guid CompanyId { get; set; }
    public Guid TenantId { get; set; }
    public string CompanyCode { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
    public string? CompanyType { get; set; }
    public string? IndustryVertical { get; set; }
    public string? Website { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? AddressLine1 { get; set; }
    public string? City { get; set; }
    public string? StateProvince { get; set; }
    public string? Country { get; set; }
    public string? PostalCode { get; set; }
    public string? AccountStatus { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedDate { get; set; }
}