using MediatR;
using REZsupport.Application.DTOs.Common;
using REZsupport.Application.DTOs.Contact;

namespace REZsupport.Application.Commands.Contact;

public class CreateContactCommand : IRequest<ApiResponse<ContactDto>>
{
    public CreateContactDto Contact { get; set; } = null!;
}
