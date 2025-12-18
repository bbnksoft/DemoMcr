using Demo.Application.DTOs.Common;
using Demo.Application.DTOs.Venue;
using Demo.Application.Queries.Venue;
using Demo.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Demo.Application.Handlers.Venue;

public class GetSectionsQueryHandler : IRequestHandler<GetSectionsQuery, ApiResponse<List<SectionDto>>>
{
    private readonly ApplicationDbContext _context;

    public GetSectionsQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse<List<SectionDto>>> Handle(GetSectionsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var sections = await _context.Sections
                .Where(s => s.VenueId == request.VenueId)
                .OrderBy(s => s.DisplayOrder)
                .ThenBy(s => s.SectionName)
                .ToListAsync(cancellationToken);

            var sectionDtos = sections.Select(s => new SectionDto
            {
                SectionId = s.SectionId,
                VenueId = s.VenueId,
                SectionCode = s.SectionCode,
                SectionName = s.SectionName ?? string.Empty,
                SectionType = s.SectionType,
                Capacity = s.MaxCapacity,
                IsActive = true
            }).ToList();

            return ApiResponse<List<SectionDto>>.SuccessResponse(sectionDtos);
        }
        catch (Exception ex)
        {
            return ApiResponse<List<SectionDto>>.ErrorResponse($"Error retrieving sections: {ex.Message}");
        }
    }
}
