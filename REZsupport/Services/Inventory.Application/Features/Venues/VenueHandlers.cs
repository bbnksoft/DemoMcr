using MediatR;
using AutoMapper;
using FluentValidation;
using Inventory.Application.DTOs;
using Inventory.Core.Interfaces;
using Inventory.Core.Exceptions;

namespace Inventory.Application.Features.Venues;

// Update Command
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

// Delete Command
public class DeleteVenueCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public DeleteVenueCommand(Guid id) { Id = id; }
}

public class DeleteVenueCommandHandler : IRequestHandler<DeleteVenueCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVenueCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteVenueCommand request, CancellationToken cancellationToken)
    {
        var venue = await _unitOfWork.Venues.GetByIdAsync(request.Id, cancellationToken);
        if (venue == null) throw new NotFoundException(nameof(Core.Entities.Venue), request.Id);

        await _unitOfWork.Venues.DeleteAsync(venue, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}

// Get By Id Query
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

// Get All Query
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
