using Demo.Application.Commands.Venue;
using Demo.Application.DTOs.Common;
using Demo.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Demo.Application.Handlers.Venue;

public class DeleteVenueCommandHandler : IRequestHandler<DeleteVenueCommand, ApiResponse<bool>>
{
    private readonly ApplicationDbContext _context;

    public DeleteVenueCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse<bool>> Handle(DeleteVenueCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var venue = await _context.Venues
                .FirstOrDefaultAsync(v => v.VenueId == request.VenueId, cancellationToken);

            if (venue == null)
            {
                return ApiResponse<bool>.ErrorResponse("Venue not found.");
            }

            // Check for dependencies
            var hasProducts = await _context.Products
                .AnyAsync(p => p.VenueId == request.VenueId, cancellationToken);

            if (hasProducts)
            {
                return ApiResponse<bool>.ErrorResponse("Cannot delete venue with existing products. Consider deactivating instead.");
            }

            var hasEvents = await _context.Events
                .AnyAsync(e => e.VenueId == request.VenueId, cancellationToken);

            if (hasEvents)
            {
                return ApiResponse<bool>.ErrorResponse("Cannot delete venue with existing events. Consider deactivating instead.");
            }

            var hasSections = await _context.Sections
                .AnyAsync(s => s.VenueId == request.VenueId, cancellationToken);

            if (hasSections)
            {
                return ApiResponse<bool>.ErrorResponse("Cannot delete venue with existing sections. Consider deactivating instead.");
            }

            _context.Venues.Remove(venue);
            await _context.SaveChangesAsync(cancellationToken);

            return ApiResponse<bool>.SuccessResponse(true, "Venue deleted successfully.");
        }
        catch (Exception ex)
        {
            return ApiResponse<bool>.ErrorResponse($"Error deleting venue: {ex.Message}");
        }
    }
}
