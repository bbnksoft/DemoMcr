namespace REZsupport.Application.DTOs.Contact;

public class ContactDto
{
    public Guid ContactId { get; set; }
    public Guid TenantId { get; set; }
    public string? ContactType { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? MobilePhone { get; set; }
    public Guid? CompanyId { get; set; }
    public string? CompanyName { get; set; }
    public string? JobTitle { get; set; }
    public string? Department { get; set; }
    public string? AddressLine1 { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public string? CustomerStatus { get; set; }
    public DateTime? CustomerSince { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedDate { get; set; }
}