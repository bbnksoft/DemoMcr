namespace REZsupport.Application.DTOs.User;

public class UserLoginDto
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string? TenantCode { get; set; }
}