using MediatR;
using REZsupport.Application.DTOs.Common;
using REZsupport.Application.DTOs.Reservation;

namespace REZsupport.Application.Handlers.Reservation;

public class GetReservationsQueryHandler : IRequestHandler<GetReservationsQuery, ApiResponse<PagedResponse<ReservationListDto>>>
{
    private readonly ApplicationDbContext _context;

    public GetReservationsQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse<PagedResponse<ReservationListDto>>> Handle(GetReservationsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var query = _context.Reservations
                .Include(r => r.Event)
                .Include(r => r.PrimaryContact)
                .AsQueryable();

            // Apply filters
            if (request.TenantId.HasValue)
            {
                query = query.Where(r => r.TenantId == request.TenantId.Value);
            }

            if (request.EventId.HasValue)
            {
                query = query.Where(r => r.EventId == request.EventId.Value);
            }

            if (request.ContactId.HasValue)
            {
                query = query.Where(r => r.PrimaryContactId == request.ContactId.Value);
            }

            if (!string.IsNullOrWhiteSpace(request.ReservationStatus))
            {
                query = query.Where(r => r.ReservationStatus == request.ReservationStatus);
            }

            if (!string.IsNullOrWhiteSpace(request.PaymentStatus))
            {
                query = query.Where(r => r.PaymentStatus == request.PaymentStatus);
            }

            if (request.BookingDateFrom.HasValue)
            {
                query = query.Where(r => r.BookingDate >= request.BookingDateFrom.Value);
            }

            if (request.BookingDateTo.HasValue)
            {
                query = query.Where(r => r.BookingDate <= request.BookingDateTo.Value);
            }

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var searchTerm = request.SearchTerm.ToLower();
                query = query.Where(r =>
                    r.ReservationNumber.ToLower().Contains(searchTerm) ||
                    (r.PrimaryContact!.FirstName + " " + r.PrimaryContact.LastName).ToLower().Contains(searchTerm) ||
                    r.Event!.EventName.ToLower().Contains(searchTerm)
                );
            }

            // Get total count
            var totalCount = await query.CountAsync(cancellationToken);

            // Apply sorting
            query = ApplySorting(query, request.SortBy, request.SortOrder);

            // Apply pagination
            var reservations = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(r => new ReservationListDto
                {
                    ReservationId = r.ReservationId,
                    ReservationNumber = r.ReservationNumber,
                    EventName = r.Event != null ? r.Event.EventName : string.Empty,
                    PrimaryContactName = r.PrimaryContact != null ? $"{r.PrimaryContact.FirstName} {r.PrimaryContact.LastName}" : string.Empty,
                    ReservationStatus = r.ReservationStatus,
                    BookingDate = r.BookingDate,
                    TotalAmount = r.TotalAmount,
                    PaymentStatus = r.PaymentStatus,
                    TotalGuests = r.TotalGuests
                })
                .ToListAsync(cancellationToken);

            var pagedResponse = new PagedResponse<ReservationListDto>
            {
                Items = reservations,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalCount = totalCount
            };

            return ApiResponse<PagedResponse<ReservationListDto>>.SuccessResponse(pagedResponse, "Reservations retrieved successfully");
        }
        catch (Exception ex)
        {
            return ApiResponse<PagedResponse<ReservationListDto>>.ErrorResponse("Failed to retrieve reservations", new List<string> { ex.Message });
        }
    }

    private IQueryable<Infrastructure.Persistence.Entities.Reservation> ApplySorting(
        IQueryable<Infrastructure.Persistence.Entities.Reservation> query,
        string? sortBy,
        string sortOrder)
    {
        var isDescending = sortOrder.ToLower() == "desc";

        return sortBy?.ToLower() switch
        {
            "number" => isDescending ? query.OrderByDescending(r => r.ReservationNumber) : query.OrderBy(r => r.ReservationNumber),
            "bookingdate" => isDescending ? query.OrderByDescending(r => r.BookingDate) : query.OrderBy(r => r.BookingDate),
            "totalamount" => isDescending ? query.OrderByDescending(r => r.TotalAmount) : query.OrderBy(r => r.TotalAmount),
            "status" => isDescending ? query.OrderByDescending(r => r.ReservationStatus) : query.OrderBy(r => r.ReservationStatus),
            _ => query.OrderByDescending(r => r.BookingDate)
        };
    }
}
