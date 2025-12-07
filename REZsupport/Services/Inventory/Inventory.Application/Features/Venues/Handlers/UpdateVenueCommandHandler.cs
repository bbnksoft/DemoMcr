using AutoMapper;
using FluentValidation;
using Inventory.Application.Features.Venues.Commands;
using Inventory.Application.Responses.Venues;
using Inventory.Core.Exceptions;
using Inventory.Core.Interfaces;
using MediatR;

namespace Inventory.Application.Features.Venues.Handlers;
public class UpdateVenueCommandHandler : IRequestHandler<UpdateVenueCommand, VenueResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateVenueCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<VenueResponse> Handle(UpdateVenueCommand request, CancellationToken cancellationToken)
    {
        var venue = await _unitOfWork.Venues.GetByIdAsync(request.Id, cancellationToken);
        if (venue == null) throw new NotFoundException(nameof(Core.Entities.Venue), request.Id);

        venue.Name = request.Name;
        venue.Description = request.Description;
        venue.Address = request.Address;
        venue.City = request.City;
        venue.State = request.State;
        venue.ZipCode = request.ZipCode;
        venue.Country = request.Country;
        venue.Capacity = request.Capacity;
        venue.IsActive = request.IsActive;
        venue.UpdatedAt = DateTime.UtcNow;

        await _unitOfWork.Venues.UpdateAsync(venue, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<VenueResponse>(venue);
    }
}
public class UpdateVenueCommandValidator : AbstractValidator<UpdateVenueCommand>
{
    public UpdateVenueCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Capacity).GreaterThanOrEqualTo(0);
    }
}
