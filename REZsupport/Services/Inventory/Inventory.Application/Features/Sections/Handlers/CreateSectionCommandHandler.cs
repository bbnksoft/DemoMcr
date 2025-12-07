using AutoMapper;
using FluentValidation;
using Inventory.Application.Features.Sections.Commands;
using Inventory.Application.Responses.Sections;
using Inventory.Core.Interfaces;
using MediatR;

namespace Inventory.Application.Features.Sections.Handlers;

public class CreateSectionCommandHandler : IRequestHandler<CreateSectionCommand, SectionResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateSectionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<SectionResponse> Handle(CreateSectionCommand request, CancellationToken cancellationToken)
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

        return _mapper.Map<SectionResponse>(section);
    }
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
