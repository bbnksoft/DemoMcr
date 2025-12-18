using MediatR;
using REZsupport.Application.DTOs.Common;

namespace Demo.Application.Commands.Event;

public class DeleteEventCommand : IRequest<ApiResponse<bool>>
{
    public Guid EventId { get; set; }

    public DeleteEventCommand(Guid eventId)
    {
        EventId = eventId;
    }
}
