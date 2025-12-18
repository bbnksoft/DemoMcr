using Demo.Application.Commands.Venue;
using Demo.Application.DTOs.Common;
using Demo.Application.DTOs.Venue;
using Demo.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Demo.Application.Handlers.Venue;

public class CreateVenueCommandHandler : IRequestHandler<CreateVenueCommand, ApiResponse<VenueDto>>
{
    private readonly ApplicationDbContext _context;

    public CreateVenueCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse<VenueDto>> Handle(CreateVenueCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // Check if venue code already exists for the tenant
            var existingVenue = await _context.Venues
                .FirstOrDefaultAsync(v => v.TenantId == request.Venue.TenantId 
                    && v.VenueCode == request.Venue.VenueCode, cancellationToken);

            if (existingVenue != null)
            {
                return ApiResponse<VenueDto>.ErrorResponse("Venue code already exists for this tenant.");
            }

            var venue = new Demo.Infrastructure.Persistence.Entities.Venue
            {
                VenueId = Guid.NewGuid(),
                TenantId = request.Venue.TenantId,
                VenueCode = request.Venue.VenueCode,
                VenueName = request.Venue.VenueName,
                VenueType = request.Venue.VenueType ?? "General",
                AddressLine1 = request.Venue.AddressLine1,
                AddressLine2 = request.Venue.AddressLine2,
                City = request.Venue.City,
                StateProvince = request.Venue.StateProvince,
                PostalCode = request.Venue.PostalCode,
                Country = request.Venue.Country,
                Latitude = request.Venue.Latitude,
                Longitude = request.Venue.Longitude,
                MaxCapacity = request.Venue.TotalCapacity,
                ContactPhone = request.Venue.ContactPhone,
                ContactEmail = request.Venue.ContactEmail,
                IsActive = true,
                Status = "Active",
                CreatedBy = request.Venue.TenantId.ToString(),
                CreatedDate = DateTime.UtcNow,
                ModifiedBy = request.Venue.TenantId.ToString(),
                ModifiedDate = DateTime.UtcNow
            };

            _context.Venues.Add(venue);
            await _context.SaveChangesAsync(cancellationToken);

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
                CreatedDate = venue.CreatedDate
            };

            return ApiResponse<VenueDto>.SuccessResponse(venueDto, "Venue created successfully.");
        }
        catch (Exception ex)
        {
            return ApiResponse<VenueDto>.ErrorResponse($"Error creating venue: {ex.Message}");
        }
    }
}
