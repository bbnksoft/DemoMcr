using MediatR;
using AutoMapper;
using Inventory.Application.DTOs;
using Inventory.Core.Interfaces;
using Inventory.Core.Exceptions;

namespace Inventory.Application.Features.Venues.Queries.GetVenueById;

public class GetVenueByIdQuery : IRequest<VenueDto>
{
    public Guid Id { get; set; }
    public GetVenueByIdQuery(Guid id) { Id = id; }
}

public class GetVenueByIdQueryHandler : IRequestHandler<GetVenueByIdQuery, VenueDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetVenueByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<VenueDto> Handle(GetVenueByIdQuery request, CancellationToken cancellationToken)
    {
        var venue = await _unitOfWork.Venues.GetByIdAsync(request.Id, cancellationToken);
        if (venue == null) throw new NotFoundException(nameof(Core.Entities.Venue), request.Id);

        return _mapper.Map<VenueDto>(venue);
    }
}
