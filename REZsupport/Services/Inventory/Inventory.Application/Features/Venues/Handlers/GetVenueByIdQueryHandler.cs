using AutoMapper;
using Inventory.Application.Features.Venues.Queries;
using Inventory.Application.Responses.Venues;
using Inventory.Core.Exceptions;
using Inventory.Core.Interfaces;
using MediatR;

namespace Inventory.Application.Features.Venues.Handlers;
public class GetVenueByIdQueryHandler : IRequestHandler<GetVenueByIdQuery, VenueResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetVenueByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<VenueResponse> Handle(GetVenueByIdQuery request, CancellationToken cancellationToken)
    {
        var venue = await _unitOfWork.Venues.GetByIdAsync(request.Id, cancellationToken);
        if (venue == null) throw new NotFoundException(nameof(Core.Entities.Venue), request.Id);

        return _mapper.Map<VenueResponse>(venue);
    }
}
