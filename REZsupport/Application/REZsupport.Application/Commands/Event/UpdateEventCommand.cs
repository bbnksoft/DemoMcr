using MediatR;
using REZsupport.Application.DTOs.Common;
using REZsupport.Application.DTOs.Event;

namespace Demo.Application.Commands.Event;
public class UpdateEventCommand : IRequest<ApiResponse<EventDto>>
{
    public Guid EventId { get; set; }
    public UpdateEventDto Event { get; set; } = null!;

    public UpdateEventCommand(Guid eventId, UpdateEventDto eventDto)
    {
        EventId = eventId;
        Event = eventDto;
    }
}
