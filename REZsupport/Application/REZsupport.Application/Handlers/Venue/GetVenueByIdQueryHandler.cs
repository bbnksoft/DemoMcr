using Demo.Application.DTOs.Common;
using Demo.Application.DTOs.Venue;
using Demo.Application.Queries.Venue;
using Demo.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Demo.Application.Handlers.Venue;

public class GetVenueByIdQueryHandler : IRequestHandler<GetVenueByIdQuery, ApiResponse<VenueDto>>
{
    private readonly ApplicationDbContext _context;

    public GetVenueByIdQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse<VenueDto>> Handle(GetVenueByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var query = _context.Venues.AsQueryable();

            if (request.TenantId.HasValue)
            {
                query = query.Where(v => v.TenantId == request.TenantId.Value);
            }

            var venue = await query
                .FirstOrDefaultAsync(v => v.VenueId == request.VenueId, cancellationToken);

            if (venue == null)
            {
                return ApiResponse<VenueDto>.ErrorResponse("Venue not found.");
            }

            var venueDto = new VenueDto
            {
                VenueId = venue.VenueId,
                TenantId = venue.TenantId,
                VenueCode = venue.VenueCode,
                VenueName = venue.VenueName,
                VenueType = venue.VenueType,
                AddressLine1 = venue.AddressLine1,
                City = venue.City,
                StateProvince = venue.StateProvince,
                Country = venue.Country,
                PostalCode = venue.PostalCode,
                TotalCapacity = venue.MaxCapacity,
                ContactPhone = venue.ContactPhone,
                ContactEmail = venue.ContactEmail,
                IsActive = venue.IsActive,
                CreatedDate = venue.CreatedDate,
                Sections = new List<SectionDto>()
            };

            return ApiResponse<VenueDto>.SuccessResponse(venueDto);
        }
        catch (Exception ex)
        {
            return ApiResponse<VenueDto>.ErrorResponse($"Error retrieving venue: {ex.Message}");
        }
    }
}
