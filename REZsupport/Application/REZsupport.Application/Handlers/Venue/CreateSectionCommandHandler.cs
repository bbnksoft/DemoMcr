using Demo.Application.Commands.Venue;
using Demo.Application.DTOs.Common;
using Demo.Application.DTOs.Venue;
using Demo.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Demo.Application.Handlers.Venue;

public class CreateSectionCommandHandler : IRequestHandler<CreateSectionCommand, ApiResponse<SectionDto>>
{
    private readonly ApplicationDbContext _context;

    public CreateSectionCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse<SectionDto>> Handle(CreateSectionCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // Validate venue exists
            var venueExists = await _context.Venues
                .AnyAsync(v => v.VenueId == request.Section.VenueId, cancellationToken);

            if (!venueExists)
            {
                return ApiResponse<SectionDto>.ErrorResponse("Venue not found.");
            }

            // Check if section code already exists for the venue
            var existingSection = await _context.Sections
                .FirstOrDefaultAsync(s => s.VenueId == request.Section.VenueId 
                    && s.SectionCode == request.Section.SectionCode, cancellationToken);

            if (existingSection != null)
            {
                return ApiResponse<SectionDto>.ErrorResponse("Section code already exists for this venue.");
            }

            // Validate parent section if provided
            if (request.Section.ParentSectionId.HasValue)
            {
                var parentExists = await _context.Sections
                    .AnyAsync(s => s.SectionId == request.Section.ParentSectionId.Value, cancellationToken);

                if (!parentExists)
                {
                    return ApiResponse<SectionDto>.ErrorResponse("Parent section not found.");
                }
            }

            var section = new Demo.Infrastructure.Persistence.Entities.Section
            {
                SectionId = Guid.NewGuid(),
                VenueId = request.Section.VenueId,
                TenantId = request.Section.TenantId,
                ParentSectionId = request.Section.ParentSectionId,
                SectionCode = request.Section.SectionCode,
                SectionName = request.Section.SectionName ?? string.Empty,
                SectionType = request.Section.SectionType,
                MaxCapacity = request.Section.Capacity,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow
            };

            _context.Sections.Add(section);
            await _context.SaveChangesAsync(cancellationToken);

            var sectionDto = new SectionDto
            {
                SectionId = section.SectionId,
                VenueId = section.VenueId,
                SectionCode = section.SectionCode,
                SectionName = section.SectionName ?? string.Empty,
                SectionType = section.SectionType,
                Capacity = section.MaxCapacity,
                IsActive = true
            };

            return ApiResponse<SectionDto>.SuccessResponse(sectionDto, "Section created successfully.");
        }
        catch (Exception ex)
        {
            return ApiResponse<SectionDto>.ErrorResponse($"Error creating section: {ex.Message}");
        }
    }
}
