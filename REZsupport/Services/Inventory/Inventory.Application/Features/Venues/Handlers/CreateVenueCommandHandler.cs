using AutoMapper;
using FluentValidation;
using Inventory.Application.Features.Venues.Commands;
using Inventory.Application.Responses.Venues;
using Inventory.Core.Entities;
using Inventory.Core.Interfaces;
using MediatR;

namespace Inventory.Application.Features.Venues.Handlers;

public class CreateVenueCommandHandler : IRequestHandler<CreateVenueCommand, VenueResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateVenueCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<VenueResponse> Handle(CreateVenueCommand request, CancellationToken cancellationToken)
    {
        var venue = new Venue
        {
            //VenueName = request.VenueName,
            //VenueType = request.VenueType,
            //Operator = request.Operator,
            //YearBuilt = request.YearBuilt,
            //Capacity = request.Capacity,
            //LocationData = request.LocationData
        };

        await _unitOfWork.Venues.AddAsync(venue, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<VenueResponse>(venue);
    }
}

public class CreateVenueCommandValidator : AbstractValidator<CreateVenueCommand>
{
    public CreateVenueCommandValidator()
    {
        RuleFor(x => x.VenueName).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Capacity).GreaterThanOrEqualTo(0);
    }
}
