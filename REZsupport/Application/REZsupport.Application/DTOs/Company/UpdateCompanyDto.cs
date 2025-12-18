namespace REZsupport.Application.DTOs.Company;

public class UpdateCompanyDto
{
    public string CompanyName { get; set; } = string.Empty;
    public string? CompanyType { get; set; }
    public string? Website { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string? City { get; set; }
    public string? StateProvince { get; set; }
    public string? Country { get; set; }
    public string? PostalCode { get; set; }
    public string? AccountStatus { get; set; }
    public bool IsActive { get; set; }
}
