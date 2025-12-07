using MediatR;
using AutoMapper;
using Inventory.Application.DTOs;
using Inventory.Core.Interfaces;

namespace Inventory.Application.Features.Venues.Queries.GetAllVenues;

public class GetAllVenuesQuery : IRequest<IEnumerable<VenueDto>> { }

public class GetAllVenuesQueryHandler : IRequestHandler<GetAllVenuesQuery, IEnumerable<VenueDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllVenuesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<VenueDto>> Handle(GetAllVenuesQuery request, CancellationToken cancellationToken)
    {
        var venues = await _unitOfWork.Venues.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<VenueDto>>(venues);
    }
}
