using MediatR;
using REZsupport.Application.DTOs.Common;

namespace REZsupport.Application.Commands.Contact;

public class DeleteContactCommand : IRequest<ApiResponse<bool>>
{
    public Guid ContactId { get; set; }
}
