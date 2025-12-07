using AutoMapper;
using Inventory.Application.Features.Sections.Queries;
using Inventory.Application.Responses.Sections;
using Inventory.Core.Exceptions;
using Inventory.Core.Interfaces;
using MediatR;

namespace Inventory.Application.Features.Sections.Handlers;

public class GetSectionByIdQueryHandler : IRequestHandler<GetSectionByIdQuery, SectionResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetSectionByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<SectionResponse> Handle(GetSectionByIdQuery request, CancellationToken cancellationToken)
    {
        var section = await _unitOfWork.Sections.GetByIdAsync(request.Id, cancellationToken);
        if (section == null) throw new NotFoundException(nameof(Core.Entities.Section), request.Id);

        return _mapper.Map<SectionResponse>(section);
    }
}