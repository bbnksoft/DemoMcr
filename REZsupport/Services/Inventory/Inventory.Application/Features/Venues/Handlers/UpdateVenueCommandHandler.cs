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
        // Validate the request
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        // Retrieve the existing venue
        var venue = await _context.Venues
            .Include(v => v.Tenant)
            .FirstOrDefaultAsync(v => v.VenueId == request.VenueId, cancellationToken);

        if (venue == null)
            throw new NotFoundException($"Venue with ID {request.VenueId} not found.");

        // Check tenant authorization
        if (venue.TenantId != request.TenantId)
            throw new UnauthorizedAccessException("You do not have permission to update this venue.");

        // Update basic properties
        venue.VenueName = request.VenueName;
        venue.VenueCode = request.VenueCode;
        venue.VenueType = request.VenueType;
        venue.Status = request.Status ?? venue.Status;

        // Update specifications
        venue.PassengerCapacity = request.PassengerCapacity;
        venue.CrewCapacity = request.CrewCapacity;
        venue.TotalDecks = request.TotalDecks;
        venue.TotalCabins = request.TotalCabins;

        // Update physical details
        venue.GrossTonnage = request.GrossTonnage;
        venue.Length = request.Length;
        venue.Width = request.Width;
        venue.Draft = request.Draft;

        // Update registration details
        venue.RegistryPort = request.RegistryPort;
        venue.IMONumber = request.IMONumber;
        venue.FlagCountry = request.FlagCountry;
        venue.BuildYear = request.BuildYear;
        venue.RefurbishmentYear = request.RefurbishmentYear;

        // Update location and operational details
        venue.HomePort = request.HomePort;
        venue.CurrentLocation = request.CurrentLocation;
        venue.LogoUrl = request.LogoUrl;
        venue.ImageUrl = request.ImageUrl;
        venue.OperationalStatus = request.OperationalStatus ?? venue.OperationalStatus;
        venue.AvailableForBooking = request.AvailableForBooking;

        // Update additional information
        venue.Description = request.Description;
        venue.Notes = request.Notes;
        venue.ExtendedAttributes = request.ExtendedAttributes;

        // Update audit fields (inherited from BaseEntity)
        venue.ModifiedBy = _currentUserService.UserId;
        venue.ModifiedDate = DateTime.UtcNow;

        // Save changes
        _context.Venues.Update(venue);
        await _context.SaveChangesAsync(cancellationToken);

        // Map to response
        var response = _mapper.Map<VenueResponse>(venue);

        return response;
    }
    public async Task<VenueResponse> Handle(UpdateVenueCommand request, CancellationToken cancellationToken)
    {
        var venue = await _unitOfWork.Venues.GetByIdAsync(request.Id, cancellationToken);
        
        if (venue == null) throw new NotFoundException(nameof(Core.Entities.Venue), request.Id);

         venue.TenantId = venue.TenantId;
         venue.VenueName = request.Name;
         venue.VenueCode = venue.VenueCode;
         venue.VenueType = venue.VenueType;
         

        //venue.Name = request.Name;
        //venue.Description = request.Description;
        //venue.Address = request.Address;
        //venue.City = request.City;
        //venue.State = request.State;
        //venue.ZipCode = request.ZipCode;
        //venue.Country = request.Country;
        //venue.Capacity = request.Capacity;
        //venue.IsActive = request.IsActive;
        //venue.UpdatedAt = DateTime.UtcNow;

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
