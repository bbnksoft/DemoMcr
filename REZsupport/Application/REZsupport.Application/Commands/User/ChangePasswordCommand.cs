using MediatR;
using REZsupport.Application.DTOs.Common;
using REZsupport.Application.DTOs.User;

namespace REZsupport.Application.Commands.User;

public class ChangePasswordCommand : IRequest<ApiResponse<bool>>
{
    public Guid UserId { get; set; }
    public ChangePasswordDto PasswordData { get; set; } = null!;
}
