using MediatR;
using REZsupport.Application.DTOs.Common;
using REZsupport.Application.DTOs.Event;

namespace REZsupport.Application.Commands.Event;

public class CreateEventCommand : IRequest<ApiResponse<EventDto>>
{
    public CreateEventDto Event { get; set; } = null!;

    public CreateEventCommand(CreateEventDto eventDto)
    {
        Event = eventDto;
    }
}
