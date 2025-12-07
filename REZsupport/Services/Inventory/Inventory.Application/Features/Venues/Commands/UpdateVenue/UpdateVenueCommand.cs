using MediatR;
using AutoMapper;
using FluentValidation;
using Inventory.Application.DTOs;
using Inventory.Core.Interfaces;
using Inventory.Core.Exceptions;

namespace Inventory.Application.Features.Venues.Commands.UpdateVenue;

public class UpdateVenueCommand : IRequest<VenueDto>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? ZipCode { get; set; }
    public string? Country { get; set; }
    public int Capacity { get; set; }
    public bool IsActive { get; set; }
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

public class UpdateVenueCommandHandler : IRequestHandler<UpdateVenueCommand, VenueDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateVenueCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<VenueDto> Handle(UpdateVenueCommand request, CancellationToken cancellationToken)
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

        return _mapper.Map<VenueDto>(venue);
    }
}
