using MediatR;
using AutoMapper;
using Inventory.Application.DTOs;
using Inventory.Core.Interfaces;
using Inventory.Core.Exceptions;

namespace Inventory.Application.Features.Sections.Queries.GetSectionById;

public class GetSectionByIdQuery : IRequest<SectionDto>
{
    public Guid Id { get; set; }
    public GetSectionByIdQuery(Guid id) { Id = id; }
}

public class GetSectionByIdQueryHandler : IRequestHandler<GetSectionByIdQuery, SectionDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetSectionByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<SectionDto> Handle(GetSectionByIdQuery request, CancellationToken cancellationToken)
    {
        var section = await _unitOfWork.Sections.GetByIdAsync(request.Id, cancellationToken);
        if (section == null) throw new NotFoundException(nameof(Core.Entities.Section), request.Id);

        return _mapper.Map<SectionDto>(section);
    }
}
