using Demo.Application.Commands.Venue;
using Demo.Application.DTOs.Common;
using Demo.Application.DTOs.Venue;
using Demo.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Demo.Application.Handlers.Venue;

public class UpdateVenueCommandHandler : IRequestHandler<UpdateVenueCommand, ApiResponse<VenueDto>>
{
    private readonly ApplicationDbContext _context;

    public UpdateVenueCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse<VenueDto>> Handle(UpdateVenueCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var venue = await _context.Venues
                .FirstOrDefaultAsync(v => v.VenueId == request.VenueId, cancellationToken);

            if (venue == null)
            {
                return ApiResponse<VenueDto>.ErrorResponse("Venue not found.");
            }

            // Update venue properties
            venue.VenueName = request.Venue.VenueName;
            venue.AddressLine1 = request.Venue.AddressLine1;
            venue.AddressLine2 = request.Venue.AddressLine2;
            venue.City = request.Venue.City;
            venue.StateProvince = request.Venue.StateProvince;
            venue.PostalCode = request.Venue.PostalCode;
            venue.Country = request.Venue.Country;
            venue.MaxCapacity = request.Venue.TotalCapacity;
            venue.ContactPhone = request.Venue.ContactPhone;
            venue.ContactEmail = request.Venue.ContactEmail;
            venue.IsActive = request.Venue.IsActive;
            venue.Status = request.Venue.IsActive ? "Active" : "Inactive";
            venue.ModifiedDate = DateTime.UtcNow;

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

            return ApiResponse<VenueDto>.SuccessResponse(venueDto, "Venue updated successfully.");
        }
        catch (Exception ex)
        {
            return ApiResponse<VenueDto>.ErrorResponse($"Error updating venue: {ex.Message}");
        }
    }
}
