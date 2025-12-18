namespace REZsupport.Application.DTOs.Company;

public class CompanyListDto
{
    public Guid CompanyId { get; set; }
    public string CompanyCode { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
    public string? CompanyType { get; set; }
    public string? IndustryVertical { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? AccountStatus { get; set; }
    public bool IsActive { get; set; }
}
