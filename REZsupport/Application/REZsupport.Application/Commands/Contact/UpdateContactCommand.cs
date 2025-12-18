using MediatR;
using REZsupport.Application.DTOs.Common;
using REZsupport.Application.DTOs.Contact;

namespace REZsupport.Application.Commands.Contact;

public class UpdateContactCommand : IRequest<ApiResponse<ContactDto>>
{
    public Guid ContactId { get; set; }
    public UpdateContactDto Contact { get; set; } = null!;
}
