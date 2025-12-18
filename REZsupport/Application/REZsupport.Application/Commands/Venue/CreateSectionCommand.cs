using MediatR;
using REZsupport.Application.DTOs.Common;
using REZsupport.Application.DTOs.Section;

namespace Demo.Application.Commands.Venue;

public class CreateSectionCommand : IRequest<ApiResponse<SectionDto>>
{
    public CreateSectionDto Section { get; set; } = null!;
}
