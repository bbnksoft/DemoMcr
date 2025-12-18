using MediatR;
using REZsupport.Application.DTOs.Common;
using REZsupport.Application.DTOs.Event;
using REZsupport.Application.Queries.Event;
using REZsupport.Core.Interfaces;

namespace Demo.Application.Handlers.Event;

public class GetEventsQueryHandler : IRequestHandler<GetEventsQuery, ApiResponse<PagedResponse<EventListDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetEventsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse<PagedResponse<EventListDto>>> Handle(GetEventsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var query = await _unitOfWork.Events.GetQueryAsync(null, cancellationToken);

            // Apply filters
            if (request.TenantId.HasValue)
            {
                query = query.Where(e => e.TenantId == request.TenantId.Value);
            }

            if (request.VenueId.HasValue)
            {
                query = query.Where(e => e.VenueId == request.VenueId.Value);
            }

            if (!string.IsNullOrWhiteSpace(request.EventType))
            {
                query = query.Where(e => e.EventType == request.EventType);
            }

            if (!string.IsNullOrWhiteSpace(request.Status))
            {
                query = query.Where(e => e.Status == request.Status);
            }

            if (request.StartDateFrom.HasValue)
            {
                query = query.Where(e => e.StartDate >= request.StartDateFrom.Value);
            }

            if (request.StartDateTo.HasValue)
            {
                query = query.Where(e => e.StartDate <= request.StartDateTo.Value);
            }

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var searchTerm = request.SearchTerm.ToLower();
                query = query.Where(e =>
                    e.EventName.ToLower().Contains(searchTerm) ||
                    e.EventCode.ToLower().Contains(searchTerm)
                );
            }

            // IsActive not in entity, skip this filter

            // Get total count
            var totalCount = query.Count();

            // Apply sorting
            query = ApplySorting(query, request.SortBy, request.SortOrder);

            // Apply pagination
            var events = query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(e => new EventListDto
                {
                    EventId = e.EventId,
                    EventCode = e.EventCode,
                    EventName = e.EventName,
                    EventType = e.EventType,
                    VenueName = e.Venue != null ? e.Venue.VenueName : null,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate,
                    Status = e.Status
                })
                .ToList();

            var pagedResponse = new PagedResponse<EventListDto>
            {
                Items = events,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalCount = totalCount
            };

            return ApiResponse<PagedResponse<EventListDto>>.SuccessResponse(pagedResponse, "Events retrieved successfully");
        }
        catch (Exception ex)
        {
            return ApiResponse<PagedResponse<EventListDto>>.ErrorResponse("Failed to retrieve events", new List<string> { ex.Message });
        }
    }

    private IQueryable<REZsupport.Core.Entities.Event> ApplySorting(IQueryable<REZsupport.Core.Entities.Event> query,
        string? sortBy, string sortOrder)
    {
        var isDescending = sortOrder.ToLower() == "desc";

        return sortBy?.ToLower() switch
        {
            "name" => isDescending ? query.OrderByDescending(e => e.EventName) : query.OrderBy(e => e.EventName),
            "code" => isDescending ? query.OrderByDescending(e => e.EventCode) : query.OrderBy(e => e.EventCode),
            "startdate" => isDescending ? query.OrderByDescending(e => e.StartDate) : query.OrderBy(e => e.StartDate),
            "enddate" => isDescending ? query.OrderByDescending(e => e.EndDate) : query.OrderBy(e => e.EndDate),
            "status" => isDescending ? query.OrderByDescending(e => e.Status) : query.OrderBy(e => e.Status),
            _ => query.OrderBy(e => e.StartDate)
        };
    }
}
