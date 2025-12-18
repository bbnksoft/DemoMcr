
namespace REZsupport.Application.DTOs.User;

public class CreateUserDto
{
    public Guid TenantId { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; }
    public List<Guid> RoleIds { get; set; } = new();
}
