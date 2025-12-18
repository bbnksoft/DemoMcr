using MediatR;
using REZsupport.Application.Commands.Event;
using REZsupport.Application.DTOs.Common;
using REZsupport.Application.DTOs.Event;
using REZsupport.Core.Interfaces;

namespace Demo.Application.Handlers.Event;

public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, ApiResponse<EventDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    public CreateEventCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse<EventDto>> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        try
        {

            // Check if event code already exists for tenant

            var codeExists = await _unitOfWork.Events.AnyAsync(e => e.TenantId == request.Event.TenantId
                                        && e.EventCode == request.Event.EventCode, cancellationToken);

            if (codeExists)
            {
                return ApiResponse<EventDto>.ErrorResponse("Event code already exists", new List<string> { $"Event code '{request.Event.EventCode}' is already in use" });
            }

            var eventEntity = new REZsupport.Core.Entities.Event
            {
                EventId = Guid.NewGuid(),
                TenantId = request.Event.TenantId,
                VenueId = request.Event.VenueId ?? Guid.Empty,
                EventCode = request.Event.EventCode,
                EventName = request.Event.EventName,
                EventType = request.Event.EventType ?? "General",
                StartDate = request.Event.StartDate,
                EndDate = request.Event.EndDate,
                TimeZone = request.Event.TimeZone,
                Status = "Draft",
                MinParticipants = request.Event.MinAttendees,
                MaxParticipants = request.Event.MaxAttendees,
                CreatedDate = DateTime.UtcNow
            };

            await _unitOfWork.Events.AddAsync(eventEntity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);


            // Fetch created event with related data
            var createdEvent = await _unitOfWork.Events.GetByIdAsync(eventEntity.EventId, cancellationToken);
            //.Include(e => e.Venue)
            //.FirstOrDefaultAsync(e => e.EventId == eventEntity.EventId, cancellationToken);

            var eventDto = new EventDto
            {
                EventId = createdEvent!.EventId,
                TenantId = createdEvent.TenantId,
                VenueId = createdEvent.VenueId,
                VenueName = createdEvent.Venue?.VenueName,
                EventCode = createdEvent.EventCode,
                EventName = createdEvent.EventName,
                EventType = createdEvent.EventType,
                StartDate = createdEvent.StartDate,
                EndDate = createdEvent.EndDate,
                Status = createdEvent.Status,
                CreatedDate = createdEvent.CreatedDate,
                Inventory = new List<EventInventoryDto>()
            };

            return ApiResponse<EventDto>.SuccessResponse(eventDto, "Event created successfully");
        }
        catch (Exception ex)
        {
            return ApiResponse<EventDto>.ErrorResponse("Failed to create event", new List<string> { ex.Message });
        }
    }
}
