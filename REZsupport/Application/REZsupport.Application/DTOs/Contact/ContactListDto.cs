namespace REZsupport.Application.DTOs.Contact;
public class ContactListDto
{
    public Guid ContactId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? CompanyName { get; set; }
    public string? ContactType { get; set; }
    public string? CustomerStatus { get; set; }
}