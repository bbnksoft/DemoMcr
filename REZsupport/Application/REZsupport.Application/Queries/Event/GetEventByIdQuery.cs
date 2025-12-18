using MediatR;
using REZsupport.Application.DTOs.Common;
using REZsupport.Application.DTOs.Event;

namespace REZsupport.Application.Queries.Event;

public class GetEventByIdQuery : IRequest<ApiResponse<EventDto>>
{
    public Guid EventId { get; set; }
    public Guid? TenantId { get; set; }

    public GetEventByIdQuery(Guid eventId, Guid? tenantId = null)
    {
        EventId = eventId;
        TenantId = tenantId;
    }
}
