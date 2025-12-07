using AutoMapper;
using Inventory.Application.Features.Sections.Queries;
using Inventory.Application.Responses.Sections;
using Inventory.Core.Interfaces;
using MediatR;

namespace Inventory.Application.Features.Sections.Handlers;

public class GetAllSectionsQueryHandler : IRequestHandler<GetAllSectionsQuery, IEnumerable<SectionResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllSectionsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SectionResponse>> Handle(GetAllSectionsQuery request, CancellationToken cancellationToken)
    {
        var sections = await _unitOfWork.Sections.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<SectionResponse>>(sections);
    }
}