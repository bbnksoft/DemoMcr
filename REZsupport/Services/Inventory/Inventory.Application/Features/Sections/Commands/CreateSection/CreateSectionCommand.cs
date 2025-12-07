using MediatR;
using AutoMapper;
using FluentValidation;
using Inventory.Application.DTOs;
using Inventory.Core.Interfaces;

namespace Inventory.Application.Features.Sections.Commands.CreateSection;

public class CreateSectionCommand : IRequest<SectionDto>
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Guid VenueId { get; set; }
    public int Capacity { get; set; }
    public int RowCount { get; set; }
    public string? SectionType { get; set; }
    public bool IsActive { get; set; } = true;
}

public class CreateSectionCommandValidator : AbstractValidator<CreateSectionCommand>
{
    public CreateSectionCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
        RuleFor(x => x.VenueId).NotEmpty();
        RuleFor(x => x.Capacity).GreaterThanOrEqualTo(0);
        RuleFor(x => x.RowCount).GreaterThanOrEqualTo(0);
    }
}

public class CreateSectionCommandHandler : IRequestHandler<CreateSectionCommand, SectionDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateSectionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<SectionDto> Handle(CreateSectionCommand request, CancellationToken cancellationToken)
    {
        var section = new Core.Entities.Section
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            VenueId = request.VenueId,
            Capacity = request.Capacity,
            RowCount = request.RowCount,
            SectionType = request.SectionType,
            IsActive = request.IsActive,
            CreatedAt = DateTime.UtcNow
        };

        await _unitOfWork.Sections.AddAsync(section, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<SectionDto>(section);
    }
}
