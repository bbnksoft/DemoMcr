using MediatR;
using AutoMapper;
using Inventory.Application.DTOs;
using Inventory.Core.Interfaces;

namespace Inventory.Application.Features.Sections.Queries.GetAllSections;

public class GetAllSectionsQuery : IRequest<IEnumerable<SectionDto>> { }

public class GetAllSectionsQueryHandler : IRequestHandler<GetAllSectionsQuery, IEnumerable<SectionDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllSectionsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SectionDto>> Handle(GetAllSectionsQuery request, CancellationToken cancellationToken)
    {
        var sections = await _unitOfWork.Sections.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<SectionDto>>(sections);
    }
}
