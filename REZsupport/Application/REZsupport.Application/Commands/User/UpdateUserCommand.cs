using MediatR;
using REZsupport.Application.DTOs.Common;
using REZsupport.Application.DTOs.User;

namespace Demo.Application.Commands.User;
public class UpdateUserCommand : IRequest<ApiResponse<UserDto>>
{
    public Guid UserId { get; set; }
    public UpdateUserDto User { get; set; } = null!;
}
