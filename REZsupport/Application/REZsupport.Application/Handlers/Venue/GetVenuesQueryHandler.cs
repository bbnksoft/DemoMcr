using Demo.Application.DTOs.Common;
using Demo.Application.DTOs.Venue;
using Demo.Application.Queries.Venue;
using Demo.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Demo.Application.Handlers.Venue;

public class GetVenuesQueryHandler : IRequestHandler<GetVenuesQuery, ApiResponse<PagedResponse<VenueListDto>>>
{
    private readonly ApplicationDbContext _context;

    public GetVenuesQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse<PagedResponse<VenueListDto>>> Handle(GetVenuesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var query = _context.Venues.AsQueryable();

            // Apply filters
            if (request.TenantId.HasValue)
            {
                query = query.Where(v => v.TenantId == request.TenantId.Value);
            }

            if (!string.IsNullOrWhiteSpace(request.VenueType))
            {
                query = query.Where(v => v.VenueType == request.VenueType);
            }

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var searchLower = request.SearchTerm.ToLower();
                query = query.Where(v => 
                    v.VenueName.ToLower().Contains(searchLower) ||
                    v.VenueCode.ToLower().Contains(searchLower) ||
                    (v.City != null && v.City.ToLower().Contains(searchLower)));
            }

            // Get total count
            var totalRecords = await query.CountAsync(cancellationToken);

            // Apply sorting
            query = request.SortBy.ToLower() switch
            {
                "code" => request.SortOrder.ToLower() == "desc" 
                    ? query.OrderByDescending(v => v.VenueCode) 
                    : query.OrderBy(v => v.VenueCode),
                "type" => request.SortOrder.ToLower() == "desc" 
                    ? query.OrderByDescending(v => v.VenueType) 
                    : query.OrderBy(v => v.VenueType),
                "city" => request.SortOrder.ToLower() == "desc" 
                    ? query.OrderByDescending(v => v.City) 
                    : query.OrderBy(v => v.City),
                _ => request.SortOrder.ToLower() == "desc" 
                    ? query.OrderByDescending(v => v.VenueName) 
                    : query.OrderBy(v => v.VenueName)
            };

            // Apply pagination
            var venues = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            var venueDtos = venues.Select(v => new VenueListDto
            {
                VenueId = v.VenueId,
                VenueCode = v.VenueCode,
                VenueName = v.VenueName,
                VenueType = v.VenueType,
                City = v.City,
                Country = v.Country,
                TotalCapacity = v.MaxCapacity,
                IsActive = v.IsActive
            }).ToList();

            var pagedResponse = new PagedResponse<VenueListDto>
            {
                Items = venueDtos,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalCount = totalRecords
            };

            return ApiResponse<PagedResponse<VenueListDto>>.SuccessResponse(pagedResponse);
        }
        catch (Exception ex)
        {
            return ApiResponse<PagedResponse<VenueListDto>>.ErrorResponse($"Error retrieving venues: {ex.Message}");
        }
    }
}
