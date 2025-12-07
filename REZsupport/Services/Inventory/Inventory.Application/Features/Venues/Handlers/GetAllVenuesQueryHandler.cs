using AutoMapper;
using Inventory.Application.Features.Venues.Queries;
using Inventory.Application.Responses.Venues;
using Inventory.Core.Interfaces;
using MediatR;

namespace Inventory.Application.Features.Venues.Handlers;

public class GetAllVenuesQueryHandler : IRequestHandler<GetAllVenuesQuery, IEnumerable<VenueResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetAllVenuesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<IEnumerable<VenueResponse>> Handle(GetAllVenuesQuery request, CancellationToken cancellationToken)
    {
        var venues = await _unitOfWork.Venues.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<VenueResponse>>(venues);
    }
}
