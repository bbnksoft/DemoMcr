using MediatR;
using REZsupport.Application.DTOs.Common;

namespace REZsupport.Application.Commands.User;

public class DeleteUserCommand : IRequest<ApiResponse<bool>>
{
    public Guid UserId { get; set; }
}
