using MediatR;
using Inventory.Application.Responses.Sections;

namespace Inventory.Application.Features.Sections.Queries;

public class GetSectionByIdQuery : IRequest<SectionResponse>
{
    public Guid Id { get; set; }
    public GetSectionByIdQuery(Guid id) { Id = id; }
}

