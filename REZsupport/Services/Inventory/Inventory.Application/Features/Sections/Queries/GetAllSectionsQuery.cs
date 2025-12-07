using MediatR;
using Inventory.Application.Responses.Sections;

namespace Inventory.Application.Features.Sections.Queries;

public class GetAllSectionsQuery : IRequest<IEnumerable<SectionResponse>> { }

