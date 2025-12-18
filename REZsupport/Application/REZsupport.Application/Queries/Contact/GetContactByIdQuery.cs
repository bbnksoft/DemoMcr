using MediatR;
using REZsupport.Application.DTOs.Common;
using REZsupport.Application.DTOs.Contact;

namespace REZsupport.Application.Queries.Contact;

public class GetContactByIdQuery : IRequest<ApiResponse<ContactDto>>
{
    public Guid ContactId { get; set; }
    public Guid? TenantId { get; set; }
}
