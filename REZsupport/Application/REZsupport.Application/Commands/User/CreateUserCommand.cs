using MediatR;
using REZsupport.Application.DTOs.Common;
using REZsupport.Application.DTOs.User;

namespace REZsupport.Application.Commands.User;

public class CreateUserCommand : IRequest<ApiResponse<UserDto>>
{
    public CreateUserDto User { get; set; } = null!;
}
